﻿#pragma warning disable IDE1006 // Naming violation suppressed.
#pragma warning disable RS0016 // Undocumented public api members.

using Hl7.Cql.Abstractions.Exceptions;
using Hl7.Fhir.Model;
using System.Diagnostics;

namespace Hl7.Cql.Elm;

#region NameAndVersion

internal interface IGetNameAndVersion
{
    /// <summary>
    /// Gets the name with version, or just the name if no version exists.
    /// </summary>
    /// <param name="throwError">Indicates whether to throw an exception if the identifier is missing.</param>
    /// <returns>The name with version, or just the name if no version exists.</returns>
    string? NameAndVersion(bool throwError = true);

    /// <summary>
    /// Gets the versioned identifier, or null if the identifier is missing.
    /// </summary>
    /// <param name="throwError">Indicates whether to throw an exception if the identifier is missing.</param>
    /// <returns>The versioned identifier, or null if the identifier is missing.</returns>
    VersionedIdentifier? GetVersionedIdentifier(bool throwError = true);
}

[DebuggerDisplay("{GetType().Name,nq} {ToString()}")]
partial class Library : IGetNameAndVersion
{
    /// <inheritdoc />
    public string? NameAndVersion(bool throwError = true) => 
        GetVersionedIdentifier(throwError)!
       .NameAndVersion(throwError);

    /// <inheritdoc />
    public VersionedIdentifier? GetVersionedIdentifier(bool throwError = true)
    {
        if (identifier != null) return identifier;

        if (throwError) throw new MissingIdentifierError(this).ToException();
        return null;
    }

    /// <inheritdoc />
    public override string? ToString() => NameAndVersion(false);
}

[DebuggerDisplay("{GetType().Name,nq} {ToString()}")]
partial class IncludeDef : IGetNameAndVersion
{
    /// <inheritdoc />
    public string? NameAndVersion(bool throwError = true) =>
        GetVersionedIdentifier(throwError)!
            .NameAndVersion(throwError);

    /// <inheritdoc />
    public VersionedIdentifier? GetVersionedIdentifier(bool throwError = true)
    {
        if (path is {Length:>0}) 
            return new()
            {
                id = path, 
                version = version is {Length:0} ? null : version
            };

        if (throwError) throw new MissingIdentifierError(this).ToException();
        return null;
    }

    /// <inheritdoc />
    public override string? ToString() => NameAndVersion(false);
}

[DebuggerDisplay("{GetType().Name,nq} {ToString()}")]
partial class VersionedIdentifier : IGetNameAndVersion
{
    /// <inheritedoc/>
    public string? NameAndVersion(bool throwError = true)
    {
        if (string.IsNullOrEmpty(id))
        {
            if (throwError) throw new MissingNameError(this).ToException();
            return null;
        }

        if (string.IsNullOrEmpty(version))
        {
            return id;
        }

        return $"{id}-{version}";
    }

    /// <inheritdoc />
    VersionedIdentifier? IGetNameAndVersion.GetVersionedIdentifier(bool throwError) => this;

    /// <inheritdoc />
    public override string? ToString() => NameAndVersion(false);
}

#endregion

#region LibraryName

internal interface IGetLibraryName
{
    string? libraryName { get; }
}
partial class CodeRef : IGetLibraryName {}
partial class CodeSystemRef : IGetLibraryName {}
partial class ConceptRef : IGetLibraryName {}
partial class ExpressionRef : IGetLibraryName {}
partial class IdentifierRef : IGetLibraryName {}
partial class ParameterRef : IGetLibraryName {}
partial class ValueSetRef : IGetLibraryName {}

#endregion

#region Path

internal interface IGetPath
{
    string? path { get; }
}
partial class AggregateExpression : IGetPath { }
partial class ByColumn : IGetPath { }
partial class Property : IGetPath { }

#endregion

#region Name

internal interface IGetName 
{
    string? name { get; }
}
partial class AliasRef : IGetName { }
partial class CodeRef : IGetName { }
partial class CodeSystemDef : IGetName { }
partial class CodeSystemRef : IGetName { }
partial class ConceptDef : IGetName { }
partial class ConceptRef : IGetName { }
partial class ExpressionDef : IGetName { }
partial class ExpressionRef : IGetName { }
partial class IdentifierRef : IGetName { }
partial class InstanceElement : IGetName { }
partial class OperandDef : IGetName { }
partial class OperandRef : IGetName { }
partial class ParameterDef: IGetName { }
partial class ParameterRef: IGetName { }
partial class QueryLetRef: IGetName { }
partial class Tag: IGetName { }
partial class TupleElement: IGetName { }
partial class TupleElementDefinition: IGetName { }
partial class ValueSetDef: IGetName { }
partial class ValueSetRef: IGetName { }

#endregion