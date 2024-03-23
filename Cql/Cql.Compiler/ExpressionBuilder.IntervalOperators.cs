﻿#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
/* 
 * Copyright (c) 2023, NCQA and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/firely-cql-sdk/main/LICENSE
 */

using Hl7.Cql.Abstractions;
using System;
using System.Linq.Expressions;
using Hl7.Cql.Runtime;
using elm = Hl7.Cql.Elm;

namespace Hl7.Cql.Compiler
{
    internal partial class ExpressionBuilderContext
    {
        private Expression Collapse(elm.Collapse e)
        {
            ExpressionBuilderContext ctx = this;
            var operand = ctx.TranslateExpression(e.operand![0]!);
            if (IsOrImplementsIEnumerableOfT(operand.Type))
            {
                var elementType = _typeManager.Resolver.GetListElementType(operand.Type, @throw: true)!;
                if (IsInterval(elementType, out var pointType))
                {
                    var precision = Expression.Constant(null, typeof(string));
                    if (e.operand.Length > 1 && e.operand[1] is elm.Quantity quant)
                    {
                        precision = Expression.Constant(quant.unit, typeof(string));
                    }
                    return ctx.OperatorBinding.Bind(CqlOperator.Collapse, ctx.RuntimeContextParameter, operand, precision);
                }
            }
            throw new NotImplementedException().WithContext(ctx);
        }

        private Expression Contains(elm.Contains e)
        {
            ExpressionBuilderContext ctx = this;
            var left = ctx.TranslateExpression(e!.operand![0]!);
            var right = ctx.TranslateExpression(e.operand[1]!);
            var precision = Precision(e.precision, e.precisionSpecified);
            if (IsOrImplementsIEnumerableOfT(left.Type))
            {
                var elementType = _typeManager.Resolver.GetListElementType(left.Type, @throw: true)!;
                if (elementType != right.Type)
                {
                    if (elementType.IsAssignableFrom(right.Type))
                    {
                        right = ctx.ChangeType(right, elementType);
                    }
                    else throw ctx.NewExpressionBuildingException($"Cannot convert Contains target {TypeManager.PrettyTypeName(right.Type)} to {TypeManager.PrettyTypeName(elementType)}");
                }
                var call = ctx.OperatorBinding.Bind(CqlOperator.ListContains, ctx.RuntimeContextParameter, left, right);
                return call;
            }
            else if (IsInterval(left.Type, out var pointType))
            {
                var call = ctx.OperatorBinding.Bind(CqlOperator.IntervalContains, ctx.RuntimeContextParameter, left, right, precision);
                return call;
            }
            throw new NotImplementedException().WithContext(ctx);
        }

        private Expression End(elm.End e) =>
            UnaryOperator(CqlOperator.IntervalEnd, e);

        private Expression? Ends(elm.Ends e)
        {
            ExpressionBuilderContext ctx = this;
            var left = ctx.TranslateExpression(e.operand![0]);
            var right = ctx.TranslateExpression(e.operand![1]);
            var precision = Precision(e.precision, e.precisionSpecified);
            if (IsInterval(left.Type, out var leftPointType))
            {
                if (IsInterval(right.Type, out var rightPointType))
                {
                    if (leftPointType != rightPointType)
                        throw ctx.NewExpressionBuildingException();
                    return ctx.OperatorBinding.Bind(CqlOperator.Ends, ctx.RuntimeContextParameter, left, right, precision);

                }
            }
            throw new NotImplementedException().WithContext(ctx);
        }

        protected Expression Except(elm.Except e)
        {
            ExpressionBuilderContext ctx = this;
            var left = ctx.TranslateExpression(e.operand![0]);
            var right = ctx.TranslateExpression(e.operand![1]);
            if (IsOrImplementsIEnumerableOfT(left.Type) && IsOrImplementsIEnumerableOfT(right.Type))
            {
                return ctx.OperatorBinding.Bind(CqlOperator.ListExcept, ctx.RuntimeContextParameter, left, right);
            }
            else if (IsInterval(left.Type, out var leftPointType))
            {
                if (IsInterval(right.Type, out var rightPointType))
                {
                    if (leftPointType != rightPointType)
                        throw ctx.NewExpressionBuildingException();
                    return ctx.OperatorBinding.Bind(CqlOperator.IntervalExcept, ctx.RuntimeContextParameter, left, right);

                }
                else throw new NotImplementedException().WithContext(ctx);
            }
            throw new NotImplementedException().WithContext(ctx);
        }

        protected Expression? Expand(elm.Expand e)
        {
            ExpressionBuilderContext ctx = this;
            var source = ctx.TranslateExpression(e!.operand![0]!);
            var quantity = ctx.TranslateExpression(e!.operand![1]!);
            return ctx.OperatorBinding.Bind(CqlOperator.Expand, ctx.RuntimeContextParameter, source, quantity);
        }

        protected Expression In(elm.In e)
        {
            ExpressionBuilderContext ctx = this;
            var left = ctx.TranslateExpression(e.operand![0]!);
            var right = ctx.TranslateExpression(e.operand![1]!);
            if (IsOrImplementsIEnumerableOfT(right.Type))
            {
                return ctx.OperatorBinding.Bind(CqlOperator.InList, ctx.RuntimeContextParameter, left, right);
            }
            else if (IsInterval(right.Type, out var rightElementType))
            {
                var precision = Precision(e.precision, e.precisionSpecified);

                return ctx.OperatorBinding.Bind(CqlOperator.InInterval, ctx.RuntimeContextParameter, left, right, precision);

            }
            else throw new NotImplementedException().WithContext(ctx);
        }


        protected Expression? Includes(elm.Includes e)
        {
            ExpressionBuilderContext ctx = this;
            var left = ctx.TranslateExpression(e.operand![0]);
            var right = ctx.TranslateExpression(e.operand![1]);
            if (IsOrImplementsIEnumerableOfT(left.Type))
            {
                var leftElementType = _typeManager.Resolver.GetListElementType(left.Type);
                if (IsOrImplementsIEnumerableOfT(right.Type))
                {
                    var rightElementType = _typeManager.Resolver.GetListElementType(left.Type);
                    if (leftElementType != rightElementType)
                        throw ctx.NewExpressionBuildingException();
                    return ctx.OperatorBinding.Bind(CqlOperator.ListIncludesList, ctx.RuntimeContextParameter, left, right);
                }
                else
                {
                    if (leftElementType != right.Type)
                        throw ctx.NewExpressionBuildingException();
                    return ctx.OperatorBinding.Bind(CqlOperator.ListIncludesElement, ctx.RuntimeContextParameter, left, right);
                }
            }
            else if (IsInterval(left.Type, out var leftPointType))
            {
                if (IsInterval(right.Type, out var pointType))
                {
                    var precision = Precision(e.precision, e.precisionSpecified);
                    return ctx.OperatorBinding.Bind(CqlOperator.IntervalIncludesInterval, ctx.RuntimeContextParameter, left, right, precision);
                }
                else
                {
                    var precision = Precision(e.precision, e.precisionSpecified);
                    return ctx.OperatorBinding.Bind(CqlOperator.IntervalIncludesElement, ctx.RuntimeContextParameter, left, right, precision);
                }
            }
            throw new NotImplementedException().WithContext(ctx);
        }

        protected Expression IncludedIn(elm.IncludedIn e)
        {
            ExpressionBuilderContext ctx = this;
            var left = ctx.TranslateExpression(e.operand![0]);
            var right = ctx.TranslateExpression(e.operand![1]);
            if (IsOrImplementsIEnumerableOfT(left.Type))
            {
                var leftElementType = _typeManager.Resolver.GetListElementType(left.Type);
                if (IsOrImplementsIEnumerableOfT(right.Type))
                {
                    var rightElementType = _typeManager.Resolver.GetListElementType(left.Type);
                    if (leftElementType != rightElementType)
                        throw ctx.NewExpressionBuildingException();
                    return ctx.OperatorBinding.Bind(CqlOperator.ListIncludesList, ctx.RuntimeContextParameter, right, left);
                }
                else
                {
                    if (leftElementType != right.Type)
                        throw ctx.NewExpressionBuildingException();
                    return ctx.OperatorBinding.Bind(CqlOperator.ListIncludesElement, ctx.RuntimeContextParameter, right, left);
                }
            }
            else if (IsInterval(left.Type, out var leftPointType) && IsInterval(right.Type, out var rightPointType))
            {
                var precision = Precision(e.precision, e.precisionSpecified);
                return ctx.OperatorBinding.Bind(CqlOperator.IntervalIncludesInterval, ctx.RuntimeContextParameter, right, left, precision);
            }
            else if (IsInterval(right.Type, out var pointType))
            {
                var precision = Precision(e.precision, e.precisionSpecified);
                if (left.Type != pointType)
                    throw ctx.NewExpressionBuildingException();
                return ctx.OperatorBinding.Bind(CqlOperator.IntervalIncludesElement, ctx.RuntimeContextParameter, right, left, precision);

            }
            throw new NotImplementedException().WithContext(ctx);
        }

        protected Expression Intersect(elm.Intersect e)
        {
            ExpressionBuilderContext ctx = this;
            var left = ctx.TranslateExpression(e.operand![0]!);
            var right = ctx.TranslateExpression(e.operand![1]!);
            if (IsOrImplementsIEnumerableOfT(left.Type))
            {
                return ctx.OperatorBinding.Bind(CqlOperator.ListIntersect, ctx.RuntimeContextParameter, left, right);
            }
            else if (IsInterval(left.Type, out var leftPointType))
            {
                if (IsInterval(right.Type, out var rightPointType))
                {
                    return ctx.OperatorBinding.Bind(CqlOperator.IntervalIntersect, ctx.RuntimeContextParameter, left, right);
                }
                else throw new NotImplementedException().WithContext(ctx);
            }
            throw new NotImplementedException().WithContext(ctx);
        }

        protected Expression? Meets(elm.Meets e)
        {
            ExpressionBuilderContext ctx = this;
            var left = ctx.TranslateExpression(e.operand![0]);
            var right = ctx.TranslateExpression(e.operand![1]);
            if (IsInterval(left.Type, out var leftPointType))
            {
                if (IsInterval(right.Type, out var rightPointType))
                {
                    if (leftPointType != rightPointType)
                        throw ctx.NewExpressionBuildingException();
                    var precision = Precision(e.precision, e.precisionSpecified);
                    return ctx.OperatorBinding.Bind(CqlOperator.Meets, ctx.RuntimeContextParameter, left, right, precision);
                }
                else throw new NotImplementedException().WithContext(ctx);
            }
            throw new NotImplementedException().WithContext(ctx);
        }

        private Expression? MeetsAfter(elm.MeetsAfter e)
        {
            ExpressionBuilderContext ctx = this;
            var left = ctx.TranslateExpression(e.operand![0]);
            var right = ctx.TranslateExpression(e.operand![1]);
            if (IsInterval(left.Type, out var leftPointType))
            {
                if (IsInterval(right.Type, out var rightPointType))
                {
                    if (leftPointType != rightPointType)
                        throw ctx.NewExpressionBuildingException();
                    var precision = Precision(e.precision, e.precisionSpecified);
                    return ctx.OperatorBinding.Bind(CqlOperator.MeetsAfter, ctx.RuntimeContextParameter, left, right, precision);
                }
                else throw new NotImplementedException().WithContext(ctx);
            }
            throw new NotImplementedException().WithContext(ctx);
        }

        private Expression? MeetsBefore(elm.MeetsBefore e)
        {
            ExpressionBuilderContext ctx = this;
            var left = ctx.TranslateExpression(e.operand![0]);
            var right = ctx.TranslateExpression(e.operand![1]);
            if (IsInterval(left.Type, out var leftPointType))
            {
                if (IsInterval(right.Type, out var rightPointType))
                {

                    if (leftPointType != rightPointType)
                        throw ctx.NewExpressionBuildingException();
                    var precision = Precision(e.precision, e.precisionSpecified);
                    return ctx.OperatorBinding.Bind(CqlOperator.MeetsBefore, ctx.RuntimeContextParameter, left, right, precision);
                }
                else throw new NotImplementedException().WithContext(ctx);
            }
            throw new NotImplementedException().WithContext(ctx);
        }

        protected Expression Overlaps(elm.Overlaps e)
        {
            ExpressionBuilderContext ctx = this;
            var left = ctx.TranslateExpression(e.operand![0]);
            var right = ctx.TranslateExpression(e.operand![1]);
            if (IsInterval(left.Type, out var leftPointType))
            {
                if (IsInterval(right.Type, out var rightPointType))
                {
                    if (leftPointType != rightPointType)
                        throw ctx.NewExpressionBuildingException();
                    var precision = Precision(e.precision, e.precisionSpecified);
                    return ctx.OperatorBinding.Bind(CqlOperator.Overlaps, ctx.RuntimeContextParameter, left, right, precision);
                }
                else throw new NotImplementedException().WithContext(ctx);
            }
            throw new NotImplementedException().WithContext(ctx);
        }

        private Expression OverlapsBefore(elm.OverlapsBefore e)
        {
            ExpressionBuilderContext ctx = this;
            var left = ctx.TranslateExpression(e.operand![0]);
            var right = ctx.TranslateExpression(e.operand![1]);
            if (IsInterval(left.Type, out var leftPointType))
            {
                if (IsInterval(right.Type, out var rightPointType))
                {
                    if (leftPointType != rightPointType)
                        throw ctx.NewExpressionBuildingException();
                    var precision = Precision(e.precision, e.precisionSpecified);
                    return ctx.OperatorBinding.Bind(CqlOperator.OverlapsBefore, ctx.RuntimeContextParameter, left, right, precision);
                }
                else throw new NotImplementedException().WithContext(ctx);
            }
            throw new NotImplementedException().WithContext(ctx);
        }

        private Expression OverlapsAfter(elm.OverlapsAfter e)
        {
            ExpressionBuilderContext ctx = this;
            var left = ctx.TranslateExpression(e.operand![0]);
            var right = ctx.TranslateExpression(e.operand![1]);
            if (IsInterval(left.Type, out var leftPointType))
            {
                if (IsInterval(right.Type, out var rightPointType))
                {
                    if (leftPointType != rightPointType)
                        throw ctx.NewExpressionBuildingException();
                    var precision = Precision(e.precision, e.precisionSpecified);
                    return ctx.OperatorBinding.Bind(CqlOperator.OverlapsAfter, ctx.RuntimeContextParameter, left, right, precision);
                }
                else throw new NotImplementedException().WithContext(ctx);
            }
            throw new NotImplementedException().WithContext(ctx);
        }




        protected Expression? PointFrom(elm.PointFrom e) =>
            UnaryOperator(CqlOperator.PointFrom, e);

        protected Expression? ProperIncludes(elm.ProperIncludes e)
        {
            ExpressionBuilderContext ctx = this;
            var left = ctx.TranslateExpression(e.operand![0]);
            var right = ctx.TranslateExpression(e.operand![1]);
            if (IsInterval(left.Type, out var leftPointType))
            {
                var precision = Precision(e.precision, e.precisionSpecified);
                if (IsInterval(right.Type, out var rightPointType))
                {
                    return ctx.OperatorBinding.Bind(CqlOperator.IntervalProperlyIncludesInterval, ctx.RuntimeContextParameter, left, right, precision);
                }
                else
                {
                    return ctx.OperatorBinding.Bind(CqlOperator.IntervalProperlyIncludesElement, ctx.RuntimeContextParameter, left, right, precision);
                }
            }
            else if (IsOrImplementsIEnumerableOfT(left.Type))
            {
                var leftElementType = _typeManager.Resolver.GetListElementType(left.Type);
                if (IsOrImplementsIEnumerableOfT(right.Type))
                {
                    var rightElementType = _typeManager.Resolver.GetListElementType(right.Type);
                    return ctx.OperatorBinding.Bind(CqlOperator.ListProperlyIncludesList, ctx.RuntimeContextParameter, left, right);
                }
                else
                {
                    return ctx.OperatorBinding.Bind(CqlOperator.ListProperlyIncludesElement, ctx.RuntimeContextParameter, left, right);
                }
            }
            throw new NotImplementedException().WithContext(ctx);
        }


        protected Expression? ProperIncludedIn(elm.ProperIncludedIn e)
        {
            ExpressionBuilderContext ctx = this;
            var left = ctx.TranslateExpression(e.operand![0]);
            var right = ctx.TranslateExpression(e.operand![1]);
            if (IsInterval(left.Type, out var leftPointType))
            {
                if (IsInterval(right.Type, out var rightPointType))
                {
                    var precision = Precision(e.precision, e.precisionSpecified);
                    return ctx.OperatorBinding.Bind(CqlOperator.IntervalProperlyIncludesInterval, ctx.RuntimeContextParameter, right, left, precision);
                }
            }
            else if (IsOrImplementsIEnumerableOfT(left.Type))
            {
                var leftElementType = _typeManager.Resolver.GetListElementType(left.Type);
                if (IsOrImplementsIEnumerableOfT(right.Type))
                {
                    var rightElementType = _typeManager.Resolver.GetListElementType(right.Type);
                    if (leftElementType != rightElementType)
                        throw ctx.NewExpressionBuildingException();
                    return ctx.OperatorBinding.Bind(CqlOperator.ListProperlyIncludesList, ctx.RuntimeContextParameter, right, left);
                }
            }
            else if (IsInterval(right.Type, out var rightPointType))
            {
                var precision = Precision(e.precision, e.precisionSpecified);
                return ctx.OperatorBinding.Bind(CqlOperator.IntervalProperlyIncludesElement, ctx.RuntimeContextParameter, right, left, precision);
            }
            throw new NotImplementedException().WithContext(ctx);
        }

        private Expression? ProperIn(elm.ProperIn e)
        {
            ExpressionBuilderContext ctx = this;
            var element = ctx.TranslateExpression(e.operand![0]);
            var intervalOrList = ctx.TranslateExpression(e.operand![1]);
            if (IsInterval(intervalOrList.Type, out var pointType))
            {
                var precision = Precision(e.precision, e.precisionSpecified);
                return ctx.OperatorBinding.Bind(CqlOperator.IntervalProperlyIncludesElement, ctx.RuntimeContextParameter, intervalOrList, element, precision);
            }
            else if (IsOrImplementsIEnumerableOfT(intervalOrList.Type))
            {
                return ctx.OperatorBinding.Bind(CqlOperator.ListProperlyIncludesElement, ctx.RuntimeContextParameter, intervalOrList, element);
            }
            throw new NotImplementedException().WithContext(ctx);
        }

        protected Expression? ProperContains(elm.ProperContains e)
        {
            ExpressionBuilderContext ctx = this;
            var left = ctx.TranslateExpression(e.operand![0]);
            var right = ctx.TranslateExpression(e.operand![1]);
            if (IsOrImplementsIEnumerableOfT(left.Type))
            {
                var leftElementType = _typeManager.Resolver.GetListElementType(left.Type);
                if (IsOrImplementsIEnumerableOfT(right.Type))
                {
                    var rightElementType = _typeManager.Resolver.GetListElementType(right.Type);
                    if (leftElementType != rightElementType)
                        throw ctx.NewExpressionBuildingException();
                    return ctx.OperatorBinding.Bind(CqlOperator.ListProperlyIncludesList, ctx.RuntimeContextParameter, left, right);
                }
                else
                {
                    if (leftElementType != right.Type)
                        throw ctx.NewExpressionBuildingException();
                    return ctx.OperatorBinding.Bind(CqlOperator.ListProperlyIncludesElement, ctx.RuntimeContextParameter, left, right);
                }
            }
            else if (IsInterval(left.Type, out var leftPointType))
            {
                if (leftPointType != right.Type)
                    throw ctx.NewExpressionBuildingException();
                var precision = Precision(e.precision, e.precisionSpecified);
                return ctx.OperatorBinding.Bind(CqlOperator.IntervalProperlyIncludesElement, ctx.RuntimeContextParameter, left, right, precision);
            }
            throw new NotImplementedException().WithContext(ctx);
        }


        protected Expression Start(elm.Start start) =>
            UnaryOperator(CqlOperator.IntervalStart, start);


        protected Expression? Starts(elm.Starts e)
        {
            ExpressionBuilderContext ctx = this;
            var left = ctx.TranslateExpression(e.operand![0]);
            var right = ctx.TranslateExpression(e.operand![1]);
            if (IsInterval(left.Type, out var leftPointType))
            {
                if (IsInterval(right.Type, out var rightPointType))
                {
                    if (leftPointType != rightPointType)
                        throw ctx.NewExpressionBuildingException();
                    var precision = Precision(e.precision, e.precisionSpecified);
                    return ctx.OperatorBinding.Bind(CqlOperator.Starts, ctx.RuntimeContextParameter, left, right, precision);

                }
            }
            throw new NotImplementedException().WithContext(ctx);
        }


        protected Expression Union(elm.Union e)
        {
            ExpressionBuilderContext ctx = this;
            var left = ctx.TranslateExpression(e.operand![0]);
            var right = ctx.TranslateExpression(e.operand![1]);
            if (IsOrImplementsIEnumerableOfT(left.Type))
            {
                var leftElementType = _typeManager.Resolver.GetListElementType(left.Type);
                if (IsOrImplementsIEnumerableOfT(right.Type))
                {
                    var rightElementType = _typeManager.Resolver.GetListElementType(right.Type);
                    if (leftElementType != rightElementType)
                        throw ctx.NewExpressionBuildingException();
                    return ctx.OperatorBinding.Bind(CqlOperator.ListUnion, ctx.RuntimeContextParameter, left, right);
                }
            }
            else if (IsInterval(left.Type, out var leftPointType))
            {
                if (IsInterval(right.Type, out var rightPointType))
                {
                    if (leftPointType != rightPointType)
                        throw ctx.NewExpressionBuildingException();
                    return ctx.OperatorBinding.Bind(CqlOperator.IntervalUnion, ctx.RuntimeContextParameter, left, right);
                }
            }
            throw new NotImplementedException().WithContext(ctx);
        }

        protected Expression? Width(elm.Width e) =>
            UnaryOperator(CqlOperator.Width, e);

    }
}
