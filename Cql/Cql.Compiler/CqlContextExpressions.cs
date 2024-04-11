using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Hl7.Cql.Compiler.Infrastructure;
using Hl7.Cql.Operators;
using Hl7.Cql.Runtime;

namespace Hl7.Cql.Compiler;

#pragma warning disable CS1591

internal class CqlContextExpressions
{
    private static readonly Type CqlContextType = typeof(CqlContext);
    private static readonly CqlContext CqlContextInstance = default!;

    public static readonly ParameterExpression ParameterExpression = Expression.Parameter(CqlContextType, "context");
    private static readonly PropertyInfo Operators_PropertyInfo = ReflectionUtility.PropertyOf(() => CqlContextInstance.Operators);
    public static readonly MemberExpression Operators_PropertyExpression = Expression.Property(ParameterExpression, Operators_PropertyInfo);

    private static PropertyInfo Definitions_PropertyInfo = ReflectionUtility.PropertyOf(() => CqlContextInstance.Definitions);
    public static MemberExpression Definitions_PropertyExpression = Expression.Property(ParameterExpression, Definitions_PropertyInfo);
}

internal class ICqlOperatorsExpressions
{
    private static readonly Type ICqlOperatorsType = typeof(ICqlOperators);

    public static readonly IReadOnlyDictionary<string, MethodInfo[]> ICqlOperators_MethodInfos_By_Name =
        ICqlOperatorsType
            .GetMethods(BindingFlags.Instance|BindingFlags.Public)
            .GroupBy(m => m.Name)
            .ToDictionary(m => m.Key, m => m.ToArray());
}