﻿/*
 * Copyright (c) 2023, NCQA and contributors
 * See the file CONTRIBUTORS for details.
 *
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/firely-cql-sdk/main/LICENSE
 */

using Hl7.Cql.Runtime;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Diagnostics.CodeAnalysis;
using Hl7.Cql.Conversion;
using Hl7.Cql.Abstractions;

namespace Hl7.Cql.Compiler
{
    internal partial class ExpressionBuilder
    {
        private readonly TypeManager _typeManager;

        private readonly TypeConverter _typeConverter;

        private LibraryExpressionBuilder LibraryContext { get; }

        /// <summary>
        /// A dictionary which maps qualified definition names in the form of {<see cref="Elm.Library.NameAndVersion"/>}.{<c>Definition.name"</c>}
        /// to a factory which will produce a <see cref="LambdaExpression"/> given the values of <see cref="ParameterExpression"/>.
        /// </summary>
        /// <remarks>
        /// This function can be used to provide .NET native functions in place of ELM functions, and should also be used to implement
        /// functions defined in CQL with the <code>external</code> keyword.
        /// </remarks>
        private readonly Dictionary<string, Func<ParameterExpression[], LambdaExpression>> _customImplementations;


        public bool TryGetCustomImplementationByExpressionKey(
            string expressionKey,
            [NotNullWhen(true)] out Func<ParameterExpression[], LambdaExpression>? factory) =>
            _customImplementations.TryGetValue(expressionKey, out factory);

        private readonly IList<IExpressionMutator> _expressionMutators;

        private readonly LibraryDefinitionBuilderSettings _libraryDefinitionBuilderSettings;

        private readonly OperatorBinding _operatorBinding;

        /// <summary>
        /// Parameters for function definitions.
        /// </summary>
        internal IReadOnlyDictionary<string, ParameterExpression> Operands => _operands;

        private readonly Dictionary<string, ParameterExpression> _operands;

        private readonly Dictionary<string, DefinitionDictionary<LambdaExpression>> _libraries;

        /// <summary>
        /// In dodgy sort expressions where the properties are named using the undocumented IdentifierRef expression type,
        /// this value is the implied alias name that should qualify it, e.g. from DRR-E 2022:
        /// <code>
        ///     "PHQ-9 Assessments" PHQ
        ///      where ...
        ///      sort by date from start of FHIRBase."Normalize Interval"(effective) asc
        /// </code>
        /// The use of "effective" here is unqualified and is implied to be PHQ.effective
        /// No idea how this is supposed to work with queries with multiple sources (e.g., with let statements)
        /// </summary>
        private readonly string? _impliedAlias;

        internal static string NormalizeIdentifier(string identifier)
        {
            identifier = identifier.Replace(" ", "_");
            identifier = identifier.Replace("-", "_");
            identifier = identifier.Replace(".", "_");
            identifier = identifier.Replace(",", "_");
            identifier = identifier.Replace("[", "_");
            identifier = identifier.Replace("]", "_");
            identifier = identifier.Replace("(", "_");
            identifier = identifier.Replace(")", "_");
            identifier = identifier.Replace(":", "_");
            identifier = identifier.Replace("/", "_");
            identifier = identifier.Replace("+", "plus");
            identifier = identifier.Replace("-", "minus");
            identifier = identifier.Replace("\"", "");
            identifier = identifier.Replace("'", "");
            identifier = identifier.Replace(";", "_");
            identifier = identifier.Replace("&", "and");


            if (identifier.StartsWith("$"))
                identifier = identifier.Substring(1);
            var keyword = SyntaxFacts.GetKeywordKind(identifier);
            if (keyword != SyntaxKind.None)
            {
                identifier = $"@{identifier}";
            }
            if (char.IsDigit(identifier[0]))
                identifier = "_" + identifier;
            return identifier;
        }

        internal Expression GetScopeExpression(string elmAlias)
        {
            var normalized = NormalizeIdentifier(elmAlias!)!;
            if (_scopes.TryGetValue(normalized, out var expression))
                return expression.Item1;
            else throw this.NewExpressionBuildingException($"The scope alias {elmAlias}, normalized to {normalized}, is not present in the scopes dictionary.");
        }

        internal (Expression, Elm.Element) GetScope(string elmAlias)
        {
            var normalized = NormalizeIdentifier(elmAlias!)!;
            if (_scopes.TryGetValue(normalized, out var expression))
                return expression;
            else throw this.NewExpressionBuildingException($"The scope alias {elmAlias}, normalized to {normalized}, is not present in the scopes dictionary.");
        }

        /// <summary>
        /// Contains query aliases and let declarations, and any other symbol that is now "in scope"
        /// </summary>
        private readonly IDictionary<string, (Expression, Elm.Element)> _scopes;


        internal bool HasScope(string elmAlias) => _scopes.ContainsKey(elmAlias);


        internal ExpressionBuilder WithScope(string alias, Expression expr, Elm.Element element) =>
            WithScopes(KeyValuePair.Create(alias, (expr, element)));

        internal ExpressionBuilder WithScopes(string? alias, params KeyValuePair<string, (Expression, Elm.Element)>[] kvps)
        {
            var scopes = new Dictionary<string, (Expression, Elm.Element)>(_scopes);
            if (_libraryDefinitionBuilderSettings.AllowScopeRedefinition)
            {
                foreach (var kvp in kvps)
                {
                    string? normalizedIdentifier = NormalizeIdentifier(kvp.Key);
                    if (string.IsNullOrWhiteSpace(normalizedIdentifier))
                        throw this.NewExpressionBuildingException("The normalized identifier is not available.");

                    scopes[normalizedIdentifier] = kvp.Value;
                }
            }
            else
            {
                foreach (var kvp in kvps)
                {
                    string? normalizedIdentifier = NormalizeIdentifier(kvp.Key);
                    if (string.IsNullOrWhiteSpace(normalizedIdentifier))
                        throw this.NewExpressionBuildingException("The normalize identifier is not available.");

                    if (scopes.ContainsKey(normalizedIdentifier))
                        throw this.NewExpressionBuildingException(
                            $"Scope {kvp.Key}, normalized to {NormalizeIdentifier(kvp.Key)}, is already defined and this builder does not allow scope redefinition.  Check the CQL source, or set {nameof(_libraryDefinitionBuilderSettings.AllowScopeRedefinition)} to true");
                    scopes.Add(normalizedIdentifier, kvp.Value);
                }
            }
            var subContext = new ExpressionBuilder(this, impliedAlias:alias, scopes: scopes);
            return subContext;
        }

        /// <summary>
        /// Creates a copy with the scopes provided.
        /// </summary>
        internal ExpressionBuilder
            WithScopes(params KeyValuePair<string, (Expression, Elm.Element)>[] kvps) =>
            WithScopes(_impliedAlias, kvps);

        internal ExpressionBuilder WithImpliedAlias(string aliasName, Expression linqExpression, Elm.Element elmExpression)
        {
            var subContext = WithScopes(aliasName, new KeyValuePair<string, (Expression, Elm.Element)>(aliasName, (linqExpression, elmExpression)));
            return subContext;
        }

        public Expression? Mutate(Elm.Element op, Expression? expression)
        {
            foreach (var visitor in _expressionMutators)
            {
                expression = visitor.Mutate(expression!, op, this);
            }
            return expression;
        }
    }
}
