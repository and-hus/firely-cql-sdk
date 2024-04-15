﻿/* 
 * Copyright (c) 2023, NCQA and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/firely-cql-sdk/main/LICENSE
 */

using Hl7.Cql.Abstractions;
using System.Linq.Expressions;

namespace Hl7.Cql.Compiler
{
    /// <summary>
    /// Binds <see cref="CqlOperator"/>s to <see cref="Expression"/>s.
    /// </summary>
    internal abstract class OperatorBinding
    {
        /// <summary>
        /// Binds <paramref name="operator"/> to an <see cref="Expression"/>.
        /// </summary>
        /// <param name="operator">The operator to bind.</param>
        /// <param name="parameters">Zero or more parameter <see cref="Expression"/>s.  The number and order of expressions is dependent on <paramref name="operator"/>.</param>
        /// <returns>An expression that implements <paramref name="operator"/>. In most cases, this will be a <see cref="MethodCallExpression"/>.</returns>
        public abstract Expression BindToMethod(CqlOperator @operator, params Expression[] parameters);

        /// <summary>
        /// Converts the given <paramref name="expression"/> to the specified type <paramref name="type"/>.
        /// </summary>
        /// <param name="expression">The expression to convert.</param>
        /// <param name="type">The type to convert the expression to.</param>
        /// <returns>The converted expression.</returns>
        public abstract Expression ConvertToType(Expression expression, System.Type type);

        /// <summary>
        /// Converts the given <paramref name="expression"/> to the specified type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to convert the expression to.</typeparam>
        /// <param name="expression">The expression to convert.</param>
        /// <returns>The converted expression.</returns>
        public Expression ConvertToType<T>(Expression expression) =>
            ConvertToType(expression, typeof(T));
    }
}
