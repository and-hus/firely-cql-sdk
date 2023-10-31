﻿/* 
 * Copyright (c) 2023, NCQA and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/firely-cql-sdk/main/LICENSE
 */

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Hl7.Cql.Elm
{

    public partial class TypeSpecifier
    {
        /// <summary>
        /// Enumerates the open generic parameters present in the type, e.g. 'T' in List{T}.
        /// </summary>
        internal abstract IEnumerable<ParameterTypeSpecifier> GetGenericParameters();

        /// <summary>
        /// Returns a clone of the type with the generic parameters replaced with the given assignments.
        /// </summary>
        internal abstract TypeSpecifier ReplaceGenericParameters(GenericParameterAssignments assignments);

        /// <inheritdoc/>
        public override bool Equals(object? obj) => base.Equals(obj);

        /// <inheritdoc/>
        public override int GetHashCode() => base.GetHashCode();

        /// <inheritdoc/>
        public static bool operator ==(TypeSpecifier? a, TypeSpecifier? b) => a?.Equals(b) ?? b is null;

        /// <inheritdoc/>
        public static bool operator !=(TypeSpecifier? a, TypeSpecifier? b) => !(a == b);

        internal static bool SequenceEquals<T>(IEnumerable<T>? a, IEnumerable<T>? b) => EmptyIfNull(a).SequenceEqual(EmptyIfNull(b));

        internal static IEnumerable<T> EmptyIfNull<T>(IEnumerable<T>? a) => a ?? Enumerable.Empty<T>();
    }

    public partial class ChoiceTypeSpecifier
    {
        /// <summary>
        /// Creates an empty Choice type. This is used for deserialization.
        /// </summary>
        public ChoiceTypeSpecifier()
        {
            // deserialization constructor
        }

        /// <summary>
        /// Creates a Choice type with the given choices of types.
        /// </summary>
        public ChoiceTypeSpecifier(params TypeSpecifier[] choice)
        {
            this.choice = choice;
        }

        /// <inheritdoc/>
        public override string ToString() => $"Choice<{string.Join(", ", EmptyIfNull(choice))}>";

        /// <inheritdoc/>
        public override bool Equals([NotNullWhen(true)] object? other)
        {
            if (base.Equals(other))
                return true;

            if (other is ChoiceTypeSpecifier c)
                return SequenceEquals(c.choice, choice);

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(typeof(ChoiceTypeSpecifier), choice?.Length, choice?.FirstOrDefault());

        internal override TypeSpecifier ReplaceGenericParameters(GenericParameterAssignments assignments)
        {
            if (!assignments.Any()) return this;

            var choices = choice?.Select(c => c.ReplaceGenericParameters(assignments))
                    .Distinct()
                    .ToArray();

            return choices switch
            {
                null => this,
                { Length: 0 } => new ChoiceTypeSpecifier(),
                { Length: 1 } => choices[0],
                _ => new ChoiceTypeSpecifier { choice = choices }
            };
        }

        internal override IEnumerable<ParameterTypeSpecifier> GetGenericParameters() => EmptyIfNull(choice?.SelectMany(c => c.GetGenericParameters()));
    }

    public partial class ParameterTypeSpecifier
    {
        /// <inheritdoc/>
        public override string ToString() => parameterName ?? "Null";

        /// <inheritdoc/>
        public override bool Equals([NotNullWhen(true)] object? other)
        {
            if (base.Equals(other))
                return true;

            if (other is ParameterTypeSpecifier par)
                return par.parameterName == parameterName;

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => parameterName?.GetHashCode() ?? typeof(ParameterTypeSpecifier).GetHashCode();

        internal override TypeSpecifier ReplaceGenericParameters(GenericParameterAssignments assignments) =>
            assignments.TryGetValue(this, out var replacement) ? replacement : this;

        internal override IEnumerable<ParameterTypeSpecifier> GetGenericParameters() => new[] { this };
    }

    public partial class TupleElementDefinition
    {
        /// <inheritdoc/>
        public override string ToString() => $"{name ?? "null"} {elementType?.ToString() ?? "Null"}";

        /// <inheritdoc/>
        public override bool Equals([NotNullWhen(true)] object? other)
        {
            if (base.Equals(other))
                return true;

            if (other is TupleElementDefinition tuple)
                return tuple.name == name && tuple.elementType == elementType;

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(name, type);

        internal TupleElementDefinition ReplaceGenericParameters(GenericParameterAssignments assignments)
        {
            if (!assignments.Any()) return this;

            return new TupleElementDefinition
            {
                name = name,
                elementType = elementType?.ReplaceGenericParameters(assignments)
            };
        }

        internal IEnumerable<ParameterTypeSpecifier> GetGenericParameters() => TypeSpecifier.EmptyIfNull(elementType?.GetGenericParameters());
    }

    public partial class TupleTypeSpecifier
    {
        /// <inheritdoc/>
        public override string ToString() => $"Tuple {{ {string.Join(", ", EmptyIfNull(element))} }}";

        /// <inheritdoc/>
        public override bool Equals([NotNullWhen(true)] object? other)
        {
            if (base.Equals(other))
                return true;

            if (other is TupleTypeSpecifier tuple)
                return SequenceEquals(element, tuple.element);

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(typeof(IntervalTypeSpecifier), element?.Length, element?.FirstOrDefault());

        internal override TypeSpecifier ReplaceGenericParameters(GenericParameterAssignments assignments)
        {
            if (!assignments.Any()) return this;

            return new TupleTypeSpecifier()
            {
                element = element?.Select(e => e.ReplaceGenericParameters(assignments)).ToArray()
            };
        }

        internal override IEnumerable<ParameterTypeSpecifier> GetGenericParameters() =>
            EmptyIfNull(element?.SelectMany(e => e.GetGenericParameters()).Distinct());
    }

    public partial class IntervalTypeSpecifier
    {
        /// <inheritdoc/>
        public override string ToString() => $"Interval<{pointType}>";

        /// <inheritdoc/>
        public override bool Equals([NotNullWhen(true)] object? other)
        {
            if (base.Equals(other))
                return true;

            if (other is IntervalTypeSpecifier interval)
                return pointType == interval.pointType;

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(typeof(IntervalTypeSpecifier), pointType);

        internal override TypeSpecifier ReplaceGenericParameters(GenericParameterAssignments assignments)
        {
            if (!assignments.Any()) return this;

            return new IntervalTypeSpecifier
            {
                pointType = pointType?.ReplaceGenericParameters(assignments)
            };
        }

        internal override IEnumerable<ParameterTypeSpecifier> GetGenericParameters() => EmptyIfNull(pointType?.GetGenericParameters());
    }

    public partial class NamedTypeSpecifier
    {
        /// <inheritdoc/>
        public override string ToString() => name?.ToString() ?? "null";

        /// <inheritdoc/>
        public override bool Equals([NotNullWhen(true)] object? other)
        {
            if (base.Equals(other))
                return true;

            if (other is NamedTypeSpecifier nt)
                return name == nt.name;

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => name?.GetHashCode() ?? typeof(NamedTypeSpecifier).GetHashCode();

        internal override TypeSpecifier ReplaceGenericParameters(GenericParameterAssignments assignments) => this;

        internal override IEnumerable<ParameterTypeSpecifier> GetGenericParameters() => Enumerable.Empty<ParameterTypeSpecifier>();
    }

    public partial class ListTypeSpecifier
    {
        /// <inheritdoc/>
        public override string ToString() => $"List<{elementType}>";

        /// <inheritdoc/>
        public override bool Equals([NotNullWhen(true)] object? other)
        {
            if (base.Equals(other))
                return true;

            if (other is ListTypeSpecifier list)
                return list.elementType == elementType;

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(typeof(ListTypeSpecifier), elementType);

        internal override TypeSpecifier ReplaceGenericParameters(GenericParameterAssignments assignments)
        {
            if (!assignments.Any()) return this;

            return new ListTypeSpecifier
            {
                elementType = elementType?.ReplaceGenericParameters(assignments)
            };
        }

        internal override IEnumerable<ParameterTypeSpecifier> GetGenericParameters() => EmptyIfNull(elementType?.GetGenericParameters());
    }
}
