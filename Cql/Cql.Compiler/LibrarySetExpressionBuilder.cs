﻿using System.Linq.Expressions;
using Hl7.Cql.Runtime;

namespace Hl7.Cql.Compiler;

internal partial class LibrarySetExpressionBuilder
{
    public DefinitionDictionary<LambdaExpression> ProcessLibrarySet()
    {
        foreach (var library in LibrarySet)
        {
            var packageDefinitions = CreateLibraryExpressionBuilder(library, new()).ProcessLibrary();
            LibrarySetDefinitions.Merge(packageDefinitions);
        }

        return LibrarySetDefinitions;
    }

}