﻿// /*
//  * Copyright (c) 2024, NCQA and contributors
//  * See the file CONTRIBUTORS for details.
//  *
//  * This file is licensed under the BSD 3-Clause license
//  * available at https://raw.githubusercontent.com/FirelyTeam/firely-cql-sdk/main/LICENSE
//  */

using System;
using System.Linq.Expressions;
using Hl7.Cql.Abstractions.Infrastructure;
using Hl7.Cql.Compiler.Expressions;
using Hl7.Cql.Conversion;
using Hl7.Cql.Operators;

namespace Hl7.Cql.Compiler;

internal class ExpressionConverter
{
	private readonly TypeConverter _typeConverter;

	public ExpressionConverter(TypeConverter typeConverter)
	{
		_typeConverter = typeConverter;
	}

	/// <summary>
	/// Tries to convert the given <paramref name="expression"/> to the specified type <paramref name="to"/>.
	/// </summary>
	/// <exception cref="InvalidOperationException"></exception>
	public virtual bool TryConvert(
		Expression expression,
		Type to,
		out (Expression arg, TypeConversion conversion) result)
	{
		Type from = expression.Type;

		if (from == to)
		{
			// Exact match
			result = (expression, TypeConversion.ExactType);
			return true;
		}

		if (from.IsAssignableTo(to))
		{
			// 'from' is a subtype of 'to' e.g. string -> object
			// OR 'from' is a nullable value type and 'to' is the underlying type e.g. int? -> int
			result = (expression.NewAssignToTypeExpression(to), TypeConversion.AssignableType);
			return true;
		}

		if (_typeConverter?.CanConvert(from, to) == true)
		{
			var bindToGenericMethod =
				CqlOperatorsBinder.BindToGenericMethod(
					nameof(ICqlOperators.Convert),
					[to],
					expression.NewAssignToTypeExpression<object>()
				);
			result = (bindToGenericMethod, TypeConversion.OperatorConvert);
			return true;
		}

		if (expression is ConstantExpression fromConstant)
		{
			if (fromConstant.Value is null && to.IsNullable(out _))
			{
				// Null values to a type that can accept nulls e.g. default(string) or default(int?)
				result =(fromConstant.NewAssignToTypeExpression(to), TypeConversion.ExactType);
				return true;
			}

			if (fromConstant.Value is Enum enumValue && to == typeof(string) )
			{
				// Enum values to lowercase string e.g DateTimePrecision.Year -> "year"
				var name = Enum.GetName(enumValue.GetType(), enumValue);
				if (name is null)
					throw new InvalidOperationException($"Enum value {enumValue} is not defined in enum type {enumValue.GetType()}");

				result = (Expression.Constant(name.ToLowerInvariant()), TypeConversion.SimpleConvert);
				return true;
			}
		}

		result = default;
		return false;
	}


	/// <summary>
	/// Converts the given <paramref name="expression"/> to the specified type <paramref name="type"/>.
	/// </summary>
	/// <param name="expression">The expression to convert.</param>
	/// <param name="type">The type to convert the expression to.</param>
	/// <returns>The converted expression.</returns>
	public virtual Expression ConvertToType(Expression expression, Type type) =>
		TryConvert(expression, type, out var t)
			? t.arg!
			: throw new InvalidOperationException($"Cannot convert '{expression.Type.FullName}' to '{type.FullName}'");

	/// <summary>
	/// Casts the given <paramref name="expression"/> to the specified type <paramref name="type"/>.
	/// </summary>
	/// <param name="expression">The expression to cast.</param>
	/// <param name="type">The type to cast the expression to.</param>
	/// <returns>The expression that was cast.</returns>
	public virtual Expression CastToType(Expression expression, Type type)
	{
		if (expression.Type != typeof(object))
			throw new ArgumentException("Cast only allowed on Object typed expressions.", nameof(expression));

		return expression.NewAssignToTypeExpression(type);
	}
}

internal enum TypeConversion
{
	NoMatch = 0,
	ExactType = 1,

	/// <summary>
	/// e.g. String is assignable to Object, and  'from' is a subtype of 'to' e.g. string -> object
	/// </summary>
	AssignableType = 2,

	SimpleConvert = 3,
	OperatorConvert = 4,
}