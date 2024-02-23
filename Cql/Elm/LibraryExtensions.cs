﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Hl7.Cql.Graph;

namespace Hl7.Cql.Elm;

#pragma warning disable CS1591
internal static class LibraryExtensions
{
    public static IEnumerable<Library> GetIncludedElmLibraries(this IEnumerable<Library> libraries)
    {
        var packageGraph = libraries.GetIncludedLibraries();
        var elmLibraries = packageGraph.Nodes.Values
            .Select(node => node.Properties?[Library.LibraryNodeProperty])
            .OfType<Library>()
            .ToArray();
        return elmLibraries;
    }

    public static DirectedGraph GetIncludedLibraries(this IEnumerable<Library> libraries)
    {
        var buildOrder = new DirectedGraph();
        foreach (var library in libraries)
        {
            var includes = GetIncludedLibraries(library, (name, version) =>
            {
                var dependency = libraries.SingleOrDefault(p =>
                    p.identifier?.id == name
                    && p.identifier?.version == version);
                if (dependency != null)
                    return dependency;
                else
                    throw new InvalidOperationException($"Cannot find library {name} version {version} referenced in {library.NameAndVersion}");
            });
            includes.MergeInto(buildOrder);
        }
        return buildOrder;
    }

    private static DirectedGraph GetIncludedLibraries(Library library, Func<string, string, Library> locateLibrary)
    {
        var graph = GetDependencySubgraph(library, locateLibrary);
        graph.AddStartNode();
        graph.AddEndNode();
        return graph;
    }

    internal static DirectedGraph GetIncludedLibraries(this Library library, DirectoryInfo libraryPath)
    {
        var subgraph = GetDependencySubgraph(library, (name, version) =>
        {
            var stream = OpenLibrary(libraryPath, name, version);
            var dependentLibrary = Library.LoadFromJson((Stream)stream) ??
                                   throw new InvalidOperationException($"Cannot load ELM for {name} version {version}");
            return dependentLibrary;
        });
        subgraph.AddStartNode();
        subgraph.AddEndNode();
        return subgraph;
    }

    private static Stream OpenLibrary(DirectoryInfo libraryPath, string name, string version)
    {
        var path = Path.Combine(libraryPath.FullName, $"{name}-{version}.json");
        if (!File.Exists(path))
        {
            var pathWithoutVersion = Path.Combine(libraryPath.FullName, $"{name}.json");
            if (File.Exists(pathWithoutVersion))
                path = pathWithoutVersion;
        }
        var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
        return stream;
    }

    private static DirectedGraph GetDependencySubgraph(Library library, Func<string, string, Library> locateLibrary, bool includeLibraryProperty = true)
    {
        if (library is null)
        {
            throw new ArgumentNullException(nameof(library));
        }
        var thisGraph = new DirectedGraph();
        var properties = new Dictionary<string, object>();
        if (includeLibraryProperty)
            properties.Add(Library.LibraryNodeProperty, library);

        var packageNode = new DirectedGraphNode
        {
            NodeId = $"{library.identifier!.id}-{library.identifier.version}",
            Label = library.identifier!.id,
            Properties = properties,
        };
        thisGraph.AddNode(packageNode);
        thisGraph.AddEdge((null, packageNode));

        if ((library.includes?.Length ?? 0) == 0)
        {
            thisGraph.AddEdge((packageNode, null));
            return thisGraph;
        }

        foreach (var include in library.includes ?? Enumerable.Empty<IncludeDef>())
        {
            var includedPackage = locateLibrary(include.path!, include.version!);
            var libGraph = GetDependencySubgraph(includedPackage, locateLibrary);
            // add all nodes & forward edges to graph.
            foreach (var (nodeId, node) in libGraph.Nodes)
            {
                if (thisGraph.Nodes.ContainsKey(nodeId) == false)
                {
                    var clonedNode = node.Clone();
                    thisGraph.AddNode(clonedNode);
                    foreach (var forwardNodeId in libGraph.GetForwardNodeIds(node.NodeId))
                        thisGraph.AddEdge((nodeId, forwardNodeId));
                }
            }

            // add all forward edges from lib start node to package node
            foreach (var forwardNodeId in libGraph.GetForwardNodeIds(DirectedGraphNode.StartId))
            {
                thisGraph.AddEdge((packageNode.NodeId, forwardNodeId));
            }
        }

        return thisGraph;
    }
}