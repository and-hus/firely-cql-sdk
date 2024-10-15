﻿/*
 * Copyright (c) 2023, NCQA and contributors
 * See the file CONTRIBUTORS for details.
 *
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/cql-sdk/main/LICENSE
 */

using Hl7.Cql.Compiler.Expressions;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using Hl7.Cql.Abstractions.Infrastructure;

namespace Hl7.Cql.CodeGeneration.NET
{
    internal class ExpressionToCSharpConverter(
        TypeToCSharpConverter typeToCSharpConverter,
        string libraryName)
    {
        internal readonly record struct Args(
            int Indent = 0,
            bool UseIndent = true)
        {
            public int Indent { get; } = Indent;
            public bool UseIndent { get; } = UseIndent;
            public string IndentString => UseIndent ? StringExtensions.IndentString(Indent) : string.Empty;

            public Args With(Func<int, int>? indentFn = null, Func<bool, bool>? useIndentFn = null) =>
                new(indentFn?.Invoke(Indent) ?? Indent, useIndentFn?.Invoke(UseIndent) ?? UseIndent);

            public Args DontUseIndent() => With(useIndentFn: _ => false);

            public Args DoUseIndent() => With(useIndentFn: _ => true);
        }

        public Args NewArgs(int indent = 0, bool useIndent = true) => new(indent, useIndent);

        public string LibraryName { get; } = libraryName;

        private readonly TypeToCSharpConverter _typeToCSharpConverter = typeToCSharpConverter;

        public string ConvertExpression(
            Expression expression,
            Args args)
        {
            try
            {
                var result = expression switch
                {
                    ConstantExpression constant           => ConvertConstantExpression(constant, args),
                    NewExpression @new                    => ConvertNewExpression(@new, args),
                    MethodCallExpression call             => ConvertMethodCallExpression(call, args),
                    LambdaExpression lambda               => ConvertLambdaExpression(lambda, args),
                    BinaryExpression binary               => ConvertBinaryExpression(binary, args),
                    UnaryExpression unary                 => ConvertUnaryExpression(unary, args),
                    NewArrayExpression newArray           => ConvertNewArrayExpression(newArray, args),
                    MemberExpression me                   => ConvertMemberExpression(me, args),
                    MemberInitExpression memberInit       => ConvertMemberInitExpression(memberInit, args),
                    ConditionalExpression ce              => ConvertConditionalExpression(ce, args),
                    TypeBinaryExpression typeBinary       => ConvertTypeBinaryExpression(typeBinary, args),
                    ParameterExpression pe                => ConvertParameterExpression(pe, args),
                    DefaultExpression de                  => ConvertDefaultExpression(de, args),
                    NullConditionalMemberExpression nullp => ConvertNullConditionalMemberExpression(nullp, args),
                    BlockExpression block                 => ConvertBlockExpression(block, args),
                    InvocationExpression invocation       => ConvertInvocationExpression(invocation, args),
                    CaseWhenThenExpression cwt            => ConvertCaseWhenThenExpression(cwt, args),
                    FunctionCallExpression fce            => ConvertFunctionCallExpression(fce, args),
                    DefinitionCallExpression dce          => ConvertDefinitionCallExpression(dce, args),
                    ElmAsExpression ea                    => ConvertExpression(ea.Reduce(), args),
                    _                                     => throw new NotSupportedException($"Don't know how to convert an expression of type {expression.GetType()} into C#."),
                };
                return result;
            }
            catch (Exception e)
            {
                _ = e;
                return
                    $$"""
                    ((Func<dynamic>)(() => throw new NotImplementedException()))()
                    /* Generator Error:
                    {{
                        string.Concat(
                           e.ToString()
                               .Split([Environment.NewLine], StringSplitOptions.None)
                               .Select(line => $"    {line}{Environment.NewLine}")
                        )
                    }}
                    */
                    """;
            }
        }

        private string ConvertDefinitionCallExpression(
            DefinitionCallExpression dce,
            Args args)
        {
            var sb = new StringBuilder();
            sb.Append(args.IndentString);
            var targetMember = GetTargetedMemberName(dce.LibraryName, dce.DefinitionName);
            sb.Append(targetMember);
            sb.Append("(context)");
            return sb.ToString();
        }

        private string ConvertFunctionCallExpression(
            FunctionCallExpression fce,
            Args args)
        {
            var sb = new StringBuilder();
            sb.Append(args.IndentString);
            var targetMember = GetTargetedMemberName(fce.LibraryName, fce.FunctionName);
            sb.Append(targetMember);
            sb.Append(ConvertArguments(fce.Arguments, args));
            return sb.ToString();
        }

        private string GetTargetedMemberName(
            string targetName,
            string memberName)
        {
            var target = targetName == LibraryName ? "this" : $"{VariableNameGenerator.NormalizeIdentifier(targetName)}.Instance";
            var member = VariableNameGenerator.NormalizeIdentifier(memberName);
            return $"{target}.{member}";
        }

        private string ConvertBlockExpression(
            BlockExpression block,
            Args args)
        {
            var sb = new StringBuilder();

            sb.AppendLine(args.Indent, "{");

            var lastExpression = block.Expressions.LastOrDefault();
            var isFirstStatement = true;

            var nextArgsUseIndentTrue = args.With(indent => indent + 1, _ => true);
            var nextArgsUseIndentFalse = args.With(indent => indent + 1, _ => false);
            foreach (var childStatement in block.Expressions)
            {
                if (ReferenceEquals(childStatement, lastExpression))
                {
                    if (childStatement is not
                        (CaseWhenThenExpression or UnaryExpression { NodeType: ExpressionType.Throw }))
                    {
                        if (!isFirstStatement) sb.AppendLine();
                        sb.Append(args.Indent + 1, "return ");
                    }

                    sb.Append(ConvertExpression(childStatement, nextArgsUseIndentFalse));
                }
                else
                {
                    sb.Append(ConvertExpression(childStatement, nextArgsUseIndentTrue));
                }

                switch (childStatement)
                {
                    case CaseWhenThenExpression:
                        sb.AppendLine("");
                        break;
                    default:
                        sb.AppendLine(";");
                        break;
                }
                isFirstStatement = false;
            }

            sb.Append(args.Indent, "}");

            return sb.ToString();
        }

        private string ConvertNullConditionalMemberExpression(
            NullConditionalMemberExpression nullp,
            Args args)
        {
            var @object = ConvertExpression(nullp.MemberExpression.Expression!, new Args(0));
            @object = @object.ParenthesizeIfNeeded();
            return $"{args.IndentString}{@object}?.{nullp.MemberExpression.Member.Name}";
        }

        private string ConvertConstantExpression(
            ConstantExpression constant,
            Args args)
        {
            string text;
            var type = constant.Value?.GetType() ?? constant.Type;
            type = Nullable.GetUnderlyingType(type) ?? type;

            if (type.IsValueType)
            {
                // Value Types
                text = constant.Value switch
                {
                    // Value Types
                    Enum e when Enum.IsDefined(e.GetType(), e) => $"{e.GetType().FullName}.{e}", // 'e' will be the name of the defined enum
                    Enum e => $"({e.GetType().FullName}){e}", // 'e' will be the numeric value of the undefined enum
                    bool b => b ? "true" : "false",
                    decimal d => FormattableString.Invariant($"{d}m"),
                    int i => FormattableString.Invariant($"{i}"),
                    var v when v.IsObjectNullOrDefault() => DefaultExpressionForType(),
                    var v => FormattableString.Invariant($"{v}"),
                };
            }
            else
            {
                // Reference Types
                text = constant.Value switch
                {
                    null when type == typeof(object) => "null",
                    null                             => DefaultExpressionForType(),
                    Type t                           => $"typeof({_typeToCSharpConverter.ToCSharp(t)})",
                    Uri u                            => $"new Uri(\"{u}\")",
                    string s                         => s.QuoteString(),
                    var v                                => FormattableString.Invariant($"{v}")
                };
            }

            return $"{args.IndentString}{text}";

            string DefaultExpressionForType()
            {
                // NOTE: Be careful changing this to include the type name,
                // there are cases in this file where an exact match on "null"
                // or "default" is expected, and this will break it.
                //
                // return $"default({typeToCSharpConverter.ToCSharp(type)})";
                return "default";
            }
        }

        private static string ConvertParameterExpression(
            ParameterExpression pe,
            Args args)
        {
            return $"{args.IndentString}{StringExtensions.GetOrCreateName(pe)}";
        }

        private static string ConvertInvocationExpression(
            InvocationExpression invoc,
            Args args)
        {
            if (invoc.Expression is ParameterExpression pe && !invoc.Arguments.Any())
                return $"{args.IndentString}{pe.Name}()";
            else
                throw new NotImplementedException();
        }

        private string ConvertMethodCallExpression(
            MethodCallExpression call,
            Args args)
        {
            var sb = new StringBuilder();
            sb.Append(args.IndentString);

            var @object = call switch
            {
                { Object: not null } => $"{ConvertExpression(call.Object, new Args(args.Indent, false))}.",
                { Method.IsStatic: true } ext when ext.Method.IsExtensionMethod() =>
                        $"{ConvertExpression(call.Arguments[0], new Args(args.Indent, false))}.",
                { Method.IsStatic: true } => $"{_typeToCSharpConverter.ToCSharp(call.Method.DeclaringType!)}.",
                _                         => throw new InvalidOperationException("Calls should be either static or have a non-null object.")
            };

            sb.Append(CultureInfo.InvariantCulture, $"{@object}{PrettyMethodName(call.Method)}");

            var paramList = call.Method.IsExtensionMethod() ? call.Arguments.Skip(1) : call.Arguments;

            sb.Append(ConvertArguments(paramList, args));
            return sb.ToString();
        }

        private string ConvertArguments(
            IEnumerable<Expression> paramList,
            Args args)
        {
            var sb = new StringBuilder();
            sb.Append("(");

            bool firstArg = true;
            var argsForArgument = args.With(indent => indent+1, _ => false);
            foreach (var argument in paramList)
            {
                var argAsCode = ConvertExpression(argument, argsForArgument);
                if (firstArg)
                {
                    sb.Append(argAsCode);
                    firstArg = false;
                }
                else
                {
                    sb.Append(", ");
                    sb.Append(argAsCode);
                }
            }

            sb.Append(')');

            return sb.ToString();
        }

        private string ConvertDefaultExpression(
            DefaultExpression de,
            Args args)
        {
            var isNullableType = !de.Type.IsValueType || Nullable.GetUnderlyingType(de.Type) is not null;
            var defaultExpression = isNullableType ? "null" : $"default({_typeToCSharpConverter.ToCSharp(de.Type)})";
            return $"{args.IndentString}{defaultExpression}";
        }

        private string ConvertTypeBinaryExpression(
            TypeBinaryExpression typeBinary,
            Args args)
        {
            if (typeBinary.NodeType == ExpressionType.TypeIs)
            {
                var left = ConvertExpression(typeBinary.Expression, args.DontUseIndent());
                var type = _typeToCSharpConverter.ToCSharp(typeBinary.TypeOperand);
                var @is = $"{left} is {type}";
                return @is;
            }
            else
                throw new NotSupportedException($"Don't know how to convert a type binary operator {typeBinary.NodeType} into C#.");
        }

        private string ConvertConditionalExpression(
            ConditionalExpression ce,
            Args args)
        {
            var conditionalSb = new StringBuilder();
            conditionalSb.Append(args.IndentString);
            conditionalSb.Append('(');
            var nextArgs = args.DontUseIndent();
            var test = ConvertExpression(ce.Test, nextArgs);
            conditionalSb.AppendLine(CultureInfo.InvariantCulture, $"{test}");

            var nextArgs2 = nextArgs.With(indent => indent + 2);
            var ifTrue = $"{ConvertExpression(ce.IfTrue, nextArgs2)}";
            var ifFalse = $"{ConvertExpression(ce.IfFalse, nextArgs2)}";
            conditionalSb.AppendLine(CultureInfo.InvariantCulture, $"{StringExtensions.IndentString(args.Indent + 1)}? {ifTrue}");
            conditionalSb.Append(CultureInfo.InvariantCulture, $"{StringExtensions.IndentString(args.Indent + 1)}: {ifFalse})");

            if (ce.IfTrue.Type != ce.Type || ce.IfFalse.Type != ce.Type)
                return $"({_typeToCSharpConverter.ToCSharp(ce.Type)}){conditionalSb}";
            else
                return conditionalSb.ToString();
        }

        private string ConvertCaseWhenThenExpression(
            CaseWhenThenExpression conditional,
            Args args)
        {
            var sb = new StringBuilder();

            bool firstCase = true;
            var nextArgs = args.With(indent => indent + 1, _ => false);
            foreach (var c in conditional.WhenThenCases)
            {
                if (firstCase)
                    sb.Append(args.Indent, "if (");
                else
                    sb.Append(args.Indent, "else if (");

                sb.Append(ConvertExpression(c.When, nextArgs));
                sb.AppendLine(")");
                sb.AppendLine(ConvertConditionalStatementBlock(c.Then, args));
                firstCase = false;
            }

            sb.AppendLine(args.Indent, "else");
            sb.Append(ConvertConditionalStatementBlock(conditional.ElseCase, args));

            return sb.ToString();
        }

        private string ConvertConditionalStatementBlock(
            Expression conditionalActionBlock,
            Args args)
        {
            var nextArgs = args.With(indent => indent+1, _ => false);
            if (conditionalActionBlock is BlockExpression)
            {
                return ConvertExpression(conditionalActionBlock, args.DoUseIndent());
            }
            else
            {
                var sb = new StringBuilder();
                sb.AppendLine(args.Indent, "{");
                sb.Append(nextArgs.Indent, "return ");
                sb.Append(ConvertExpression(conditionalActionBlock, nextArgs));
                sb.AppendLine(";");
                sb.Append(args.Indent, "}");

                return sb.ToString();
            }
        }

        private string ConvertMemberInitExpression(
            MemberInitExpression memberInit,
            Args args)
        {
            if (_typeToCSharpConverter.ShouldUseTupleType(memberInit.Type))
            {
                var memberAssignmentsByMemberName = memberInit.Bindings
                                           .Cast<MemberAssignment>()
                                           .ToDictionary(
                                               ma => ma.Member.Name,
                                               ma => ConvertExpression(ma.Expression, new Args(0, false)));

                var memberValues = _typeToCSharpConverter
                                   .GetTupleProperties(memberInit.Type)
                                   .Select(p => memberAssignmentsByMemberName.GetValueOrDefault(p.Name, "default"))
                                   .ToArray();

                var tupleAssignmentCode = $"({string.Join(", ", memberValues)})";
                return tupleAssignmentCode;
            }

            var memberInitSb = new StringBuilder();
            memberInitSb.Append(args.IndentString);
            var typeName = _typeToCSharpConverter.ToCSharp(memberInit.Type);
#pragma warning disable CA1305 // Specify IFormatProvider
            memberInitSb.AppendLine($"new {typeName}");
#pragma warning restore CA1305 // Specify IFormatProvider
            var braceIndent = StringExtensions.IndentString(args.Indent);
            memberInitSb.Append(braceIndent);
            memberInitSb.AppendLine("{");
            var braceIndentPlusOne = StringExtensions.IndentString(args.Indent + 1);

            foreach (var binding in memberInit.Bindings)
            {
                if (binding is MemberAssignment assignment)
                {
                    var memberName = assignment.Member.Name;
                    int indent1 = args.Indent + 1;
                    var assignmentCode = ConvertExpression(assignment.Expression, new Args(indent1, false));
                    memberInitSb.Append(braceIndentPlusOne);
#pragma warning disable CA1305 // Specify IFormatProvider
                    memberInitSb.Append($"{memberName} = {assignmentCode}");
#pragma warning restore CA1305 // Specify IFormatProvider
                    memberInitSb.AppendLine(",");
                }
                else
                    throw new NotSupportedException($"Don't know how to convert a new member init of type {binding.GetType()} into C#.");
            }

            memberInitSb.Append(braceIndent);
            memberInitSb.Append("}");

            return memberInitSb.ToString();
        }

        private string ConvertNewArrayExpression(
            NewArrayExpression newArray,
            Args args)
        {
            switch (newArray.NodeType)
            {
                case ExpressionType.NewArrayInit:
                    {
                        var newArraySb = new StringBuilder();
                        var braceIndent = StringExtensions.IndentString(args.Indent);
                        newArraySb.AppendLine("[");

                        foreach (var expr in newArray.Expressions)
                        {
                            int indent1 = args.Indent + 1;
                            var exprCode = ConvertExpression(expr, new Args(indent1));
                            newArraySb.Append(exprCode);
                            newArraySb.AppendLine(",");
                        }

                        newArraySb.Append(braceIndent);
                        newArraySb.Append(']');
                        return newArraySb.ToString();
                    }
                case ExpressionType.NewArrayBounds:
                    {
                        var newArraySb = new StringBuilder();
                        newArraySb.Append(args.IndentString);
                        // var arrayType = _typeToCSharpConverter.ToCSharp(newArray.Type.GetElementType()!);
                        // var size = ConvertExpression(0, newArray.Expressions[0], false);
#pragma warning disable CA1305 // Specify IFormatProvider
                        newArraySb.AppendLine("[]");
#pragma warning restore CA1305 // Specify IFormatProvider
                        return newArraySb.ToString();
                    }

                default:
                    throw new NotSupportedException($"Don't know how to convert new array operator {newArray.NodeType} into C#.");
            }
        }

        private string ConvertNewExpression(
            NewExpression @new,
            Args args)
        {
            var arguments = @new.Arguments.Select(a => ConvertExpression(a, new Args(0)));
            var argString = string.Join(", ", arguments);
            var newSb = new StringBuilder();
            newSb.Append(CultureInfo.InvariantCulture, $"{args.IndentString}new {_typeToCSharpConverter.ToCSharp(@new.Type)}");
            newSb.Append(CultureInfo.InvariantCulture, $"({argString})");
            return newSb.ToString();
        }

        private string ConvertMemberExpression(
            MemberExpression me,
            Args args)
        {
            var nullProp = _typeToCSharpConverter.GetMemberAccessNullabilityOperator(me.Expression?.Type);
            var @object = me.Expression is not null ? ConvertExpression(me.Expression, new Args(0)) : _typeToCSharpConverter.ToCSharp(me.Member.DeclaringType!);
            @object = @object.ParenthesizeIfNeeded();
            var memberName = me.Member.Name.EscapeKeywords();
            return $"{args.IndentString}{@object}{nullProp}.{memberName}";
        }

        private string ConvertLambdaExpression(
            LambdaExpression lambda,
            Args args,
            bool functionMode = false)
        {
            var lambdaSb = new StringBuilder();
            lambdaSb.Append(args.IndentString);

            var parameters = lambda.Parameters.Select(p => $"{_typeToCSharpConverter.ToCSharp(p.Type)} {p.Name!.EscapeKeywords()}").ToList();
            // inserts the context parameter in the start of the lambda expression
            if (args.Indent == 1)
                parameters.Insert(0, "CqlContext context");

            var lambdaParameters = $"({string.Join(", ", parameters)})";
            lambdaSb.Append(lambdaParameters);

            if (lambda.Body is BlockExpression)
            {
                if (!functionMode)
                    lambdaSb.AppendLine(" =>");
                else
                    lambdaSb.AppendLine();

                var lambdaBody = ConvertExpression(lambda.Body, new Args(args.Indent));
                lambdaSb.Append(lambdaBody);
            }
            else
            {
                lambdaSb.AppendLine(" => ");
                int indent1 = args.Indent + 1;
                var lambdaBody = ConvertExpression(lambda.Body, new Args(indent1));
                lambdaSb.Append(lambdaBody);
            }

            return lambdaSb.ToString();
        }

        private string ConvertLocalFunctionDefinition(
            LambdaExpression function,
            Args args,
            string name)
        {
            var funcSb = new StringBuilder();
            funcSb.Append(args.IndentString);
            funcSb.Append(_typeToCSharpConverter.ToCSharp(function.ReturnType) + " ");
            funcSb.Append(name);

            var lambda = ConvertLambdaExpression(function, args, functionMode: true);
            funcSb.Append(lambda);

            return funcSb.ToString();
        }

        public string ConvertTopLevelFunctionDefinition(
            LambdaExpression function,
            Args args,
            string name,
            string specifiers)
        {
            var funcSb = new StringBuilder();

            funcSb.Append(args.Indent, specifiers + " ");
            funcSb.Append(_typeToCSharpConverter.ToCSharp(function.ReturnType) + " ");
            funcSb.Append(name);

            var lambda = ConvertLambdaExpression(function, args, functionMode: true);
            funcSb.Append(lambda);

            if (function.Body is not BlockExpression)
                funcSb.AppendLine(";");
            else
                funcSb.AppendLine();

            return funcSb.ToString();
        }

        // Linq.Expressions needs an explicit conversion from a value type
        // type to object, but the C# compiler will insert that boxing,
        // so we can remove those casts.
        private static Expression StripBoxing(Expression node)
        {
            // (x as object) => x
            // ((object)x) => x
            if (node is UnaryExpression
                {
                    NodeType: ExpressionType.ConvertChecked or
                            ExpressionType.Convert or
                            ExpressionType.TypeAs
                } cast &&
                cast.Type == typeof(object) &&
                cast.Operand.Type.IsValueType)
            {
                return StripBoxing(cast.Operand);
            }
            else
            {
                return node;
            }
        }

        private string ConvertUnaryExpression(
            UnaryExpression unary,
            Args args)
        {
            var stripped = StripBoxing(unary);

            if (stripped is not UnaryExpression strippedUnary)
                return ConvertExpression(stripped, new Args(args.Indent, false));

            switch (strippedUnary.NodeType)
            {
                case ExpressionType.ConvertChecked:
                case ExpressionType.Convert:
                case ExpressionType.TypeAs:
                    {
                        var operand = ConvertExpression(strippedUnary.Operand, new Args(args.Indent, false));
                        operand = operand.ParenthesizeIfNeeded();
                        var typeName = _typeToCSharpConverter.ToCSharp(strippedUnary.Type);
                        var code = strippedUnary.NodeType == ExpressionType.TypeAs ?
                            $"{args.IndentString}{operand} as {typeName}" :
                            $"{args.IndentString}({typeName}){operand}";
                        return code;
                    }
                    case ExpressionType.Throw:
                    {
                        var operand = ConvertExpression(strippedUnary.Operand, new Args(args.Indent, false));
                        return $"{args.IndentString}throw ({operand})";
                    }
                default:
                    throw new NotSupportedException($"Don't know how to convert unary operator {strippedUnary.NodeType} into C#.");
            }
        }

        private string ConvertBinaryExpression(
            BinaryExpression binary,
            Args args)
        {
            var nextArgs = args.DontUseIndent();
            var left = StripBoxing(binary.Left);
            var right = StripBoxing(binary.Right);

            if (binary.NodeType == ExpressionType.Assign &&
                left is ParameterExpression parameter)
            {
                if (right is LambdaExpression le)
                    return ConvertLocalFunctionDefinition(le, args, parameter.Name!);

                var rightCode = ConvertExpression(right, nextArgs);
                var typeDeclaration = _typeToCSharpConverter.ToCSharp(left.Type);
                var assignment = $"{args.IndentString}{typeDeclaration} {StringExtensions.GetOrCreateName(parameter)} = {rightCode}";
                return assignment;
            }
            else
            {
                var @operator = binary.NodeType == ExpressionType.Equal && right is ConstantExpression
                    ? "is"
                    : BinaryOperatorFor(binary.NodeType);

                var leftCode =  ConvertExpression(left, nextArgs);
                leftCode = leftCode.ParenthesizeIfNeeded();
                var rightCode = ConvertExpression(right, nextArgs);
                var binaryString = $"{args.IndentString}{leftCode} {@operator} {rightCode}";
                return binaryString;
            }
        }

        private static string BinaryOperatorFor(ExpressionType nodeType) => nodeType switch
        {
            ExpressionType.Add => "+",
            ExpressionType.AddAssign or ExpressionType.AddAssignChecked or ExpressionType.AddChecked => "+=",
            ExpressionType.And => "&",
            ExpressionType.AndAlso => "&&",
            ExpressionType.AndAssign => "&=",
            ExpressionType.Assign => "=",
            ExpressionType.Coalesce => "??",
            ExpressionType.Divide => "/",
            ExpressionType.DivideAssign => "/=",
            ExpressionType.Equal => "==",
            ExpressionType.ExclusiveOr => "^^",
            ExpressionType.ExclusiveOrAssign => "^^=",
            ExpressionType.GreaterThan => ">",
            ExpressionType.GreaterThanOrEqual => ">=",
            ExpressionType.LeftShift => "<<",
            ExpressionType.LeftShiftAssign => "<<=",
            ExpressionType.LessThan => "<",
            ExpressionType.LessThanOrEqual => "<=",
            ExpressionType.Modulo => "%",
            ExpressionType.ModuloAssign => "%=",
            ExpressionType.Multiply or ExpressionType.MultiplyChecked => "*",
            ExpressionType.MultiplyAssign or ExpressionType.MultiplyAssignChecked => "*=",
            ExpressionType.NotEqual => "!=",
            ExpressionType.Or => "|",
            ExpressionType.OrAssign => "|=",
            ExpressionType.OrElse => "||",
            ExpressionType.RightShift => ">>",
            ExpressionType.RightShiftAssign => ">>=",
            ExpressionType.Subtract or ExpressionType.SubtractChecked => "-",
            ExpressionType.SubtractAssign or ExpressionType.SubtractAssignChecked => "-=",
            ExpressionType.TypeAs => "as",
            ExpressionType.TypeIs => "is",
            _ => throw new NotSupportedException($"Don't know how to convert operator {nodeType} into C#."),
        };

        private string PrettyMethodName(MethodBase method)
        {
            if (method.IsGenericMethod)
            {
                var genericArgs = string.Join(", ", method.GetGenericArguments().Select(type => _typeToCSharpConverter.ToCSharp(type)));
                return $"{method.Name}<{genericArgs}>";
            }
            else
                return method.Name;
        }
    }

    file static class StringExtensions
    {
        public static string QuoteString(this string s) => SymbolDisplay.FormatLiteral(s, true);

        public static string EscapeKeywords(this string symbol)
        {
            var keyword = SyntaxFacts.GetKeywordKind(symbol);
            return keyword == SyntaxKind.None ? symbol : $"@{symbol}";
        }

        public static string IndentString(int indent) => new('\t', indent);


        public static string ParenthesizeIfNeeded(this string term)
        {
            term = term.Trim();

            if (IsSingleParenthesizedTerm(term))
                return term; // No need to parenthesize if already parenthesized

            // Handles cases such as:
            // 1. ((CqlInterval<CqlDate>)g_)?.lowClosed;
            //     ^-----------------------
            // 2. an_ ?? (at_ as CqlQuantity)?.value
            //    --------------------------^
            if (term.StartsWith('(') ^ term.EndsWith(')'))
                return $"({term})";

            if (term.Any(char.IsWhiteSpace))
                return $"({term})";

            return term;
        }

        // Check whether the term has matching opening and closing parentheses.
        // (so this matches "(a)" but not "(x) + (y)" nor "a + (b) + c").
        private static bool IsSingleParenthesizedTerm(string term)
        {
            var opens = 0;
            for (var index = 0; index < term.Length; index++)
            {
                opens = term[index] switch
                {
                    '(' => opens + 1,
                    ')' => opens - 1,
                    _   => opens
                };

                if (opens == 0)
                {
                    return index == term.Length - 1;
                }
            }

            throw new InvalidOperationException($"Unbalanced parentheses in expression '{term}'");
        }

#pragma warning disable SYSLIB0050 // Type or member is obsolete
        private static readonly ObjectIDGenerator Gen = new();
#pragma warning restore SYSLIB0050 // Type or member is obsolete

        public static string GetOrCreateName(ParameterExpression p) => p.Name ?? $"var{Gen.GetId(p, out _)}";
    }

    internal record CqlTupleMetadata(string[] PropertyNames)
    {
        public string[] PropertyNames { get; } = PropertyNames;
        private readonly int _hashCode = PropertyNames.Aggregate(0, HashCode.Combine);

        public virtual bool Equals(CqlTupleMetadata? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (_hashCode != other._hashCode) return false;
            return PropertyNames.SequenceEqual(other.PropertyNames);
        }

        public override int GetHashCode() => _hashCode;
    }
}