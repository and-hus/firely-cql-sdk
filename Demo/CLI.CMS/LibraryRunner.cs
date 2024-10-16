﻿/*
 * Copyright (c) 2024, NCQA and contributors
 * See the file CONTRIBUTORS for details.
 *
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/firely-cql-sdk/main/LICENSE
 */
using CLI_cms.Helpers;
using Hl7.Cql.Abstractions;
using Hl7.Cql.Fhir;
using Hl7.Cql.Primitives;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Dumpify;
using Hl7.Cql.Runtime;
using Hl7.Cql.ValueSets;
using Hl7.Fhir.Model;

namespace CLI_cms;
internal static class LibraryRunner
{
    internal static void RunWithResources(CommandLineOptions opt)
    {
        var libNameAndVersion = $"{opt.Library}";
        Console.WriteLine($"Loading resources for Library: {libNameAndVersion}");

        var resources = ResourceHelper.LoadResources(new(opt.ResourceDirectory), opt.LibraryName, opt.LibraryVersion);
        var assembly = resources.Assemblies.FirstOrDefault(a =>
        {
            var asmName = a.GetName().Name;
            var isMatch = asmName == libNameAndVersion;
            return isMatch;
        });
        if (assembly == null)
            throw new InvalidOperationException($"Cannot find assembly '{libNameAndVersion}' in the resources.");

        RunShared(opt, assembly);
    }

    internal static void RunWithMeasureCmsProject(CommandLineOptions opt)
    {
        // /* 1st try */
        // var libraryType = ResolveLibraryType(opt.Library) ?? throw new ArgumentException($"Uknown library: {opt.Library}");
        // var valueSets = ResourceHelper.LoadValueSets(new DirectoryInfo(opt.ValueSetDirectory));
        // var patientBundle = ResourceHelper.LoadBundle(opt.TestCaseBundleFile);
        // var inputParameters = LoadInputParameters(opt.TestCaseInputParametersFile);
        //
        // var setup = FhirCqlContext.ForBundle(patientBundle, inputParameters, valueSets);
        // var instance = Activator.CreateInstance(libraryType, setup);
        // var values = new Dictionary<string, object>();
        // foreach (var method in libraryType.GetMethods())
        // {
        //     if (method.GetParameters().Length == 0)
        //     {
        //         var declaration = method.GetCustomAttribute<CqlDeclarationAttribute>();
        //         var valueset = method.GetCustomAttribute<CqlValueSetAttribute>();
        //         if (declaration != null && valueset == null)
        //         {
        //             var value = method.Invoke(instance, Array.Empty<object?>())!;
        //             values.Add(declaration.Name, value);
        //         }
        //     }
        // }
        // var json = JsonSerializer.Serialize(values,
        //     new JsonSerializerOptions().ForFhir(ModelInfo.ModelInspector));

        //* 2nd try */
        //var asmContext = ResourceHelper.LoadResources(new DirectoryInfo(opt.LibraryDirectory), opt.LibraryName, opt.LibraryVersion);
        var assembly = Assembly.Load("Measures.CMS");
        RunShared(opt, assembly);

        // var json = JsonSerializer.Serialize(values,
        //     new JsonSerializerOptions().ForFhir(ModelInfo.ModelInspector));

        /* 2nd try */
        //var asmContext = ResourceHelper.LoadResources(new DirectoryInfo(opt.LibraryDirectory), opt.LibraryName, opt.LibraryVersion);

        //var valueSets = ResourceHelper.LoadValueSets(new DirectoryInfo(opt.ValueSetDirectory));
        //var patientBundle = ResourceHelper.LoadBundle(opt.TestCaseBundleFile);
        //var inputParameters = LoadInputParameters(opt.TestCaseInputParametersFile);
        //var context = FhirCqlContext.ForBundle(patientBundle, inputParameters, valueSets);
        //var results = AssemblyLoadContextExtensions.Run(asmContext, opt.LibraryName, opt.LibraryVersion, context);
    }

    private static void RunShared(CommandLineOptions opt, Assembly assembly)
    {
        Type libraryType = ResolveLibraryType(opt, assembly) ?? throw new ArgumentException($"Uknown library: {opt.Library}");

        Console.WriteLine("Loading value sets");
        IValueSetDictionary valueSets = ResourceHelper.LoadValueSets(new DirectoryInfo(opt.ValueSetsDirectory));

        Console.WriteLine("Loading test case bundle");
        Bundle patientBundle = ResourceHelper.LoadBundle(opt.TestCaseBundleFile);

        IDictionary<string, object> inputParameters = LoadInputParameters(opt.TestCaseInputParametersFile);

        Console.WriteLine("Setting up CQL context");
        CqlContext setup = FhirCqlContext.ForBundle(patientBundle, inputParameters, valueSets);
        object? instance = Activator.CreateInstance(libraryType, setup);
        Dictionary<string, object> values = new Dictionary<string, object>();
        Dictionary<string, Exception> errors = new Dictionary<string, Exception>();

        IEnumerable<(MethodInfo method, string declName)> GetMethodWithDeclarations()
        {
            foreach (MethodInfo method in libraryType.GetMethods())
            {
                if (method.GetParameters().Length == 0)
                {
                    CqlDeclarationAttribute? declaration = method.GetCustomAttribute<CqlDeclarationAttribute>();
                    CqlValueSetAttribute? valueset = method.GetCustomAttribute<CqlValueSetAttribute>();
                    if (declaration is { Name: { } declName } && valueset is null)
                    {
                        yield return (method, declName);
                    }
                }
            }
        }

        foreach ( (MethodInfo method, string declName) in GetMethodWithDeclarations())
        {
            Console.WriteLine($"Running method: {method.Name} ({declName})");
            try
            {
                object value = method.Invoke(instance, [])!;
                values.Add(declName, value);
            }
            catch (TargetInvocationException e)
            {
                errors.Add(declName, e.InnerException!);
            }
        }

        Console.WriteLine($"Results: {errors.Count} error(s), {values} value(s)");
        errors.DumpConsole("Errors");
        values.DumpConsole("Values");
    }

    private static Type? ResolveLibraryType(CommandLineOptions opt, Assembly assembly)
    {
        Console.WriteLine("Resolving library type from assemblies");
        var type = assembly
            .GetTypes()
            .SingleOrDefault(t =>
            {
                var libAttr = t.GetCustomAttribute<CqlLibraryAttribute>(false);
                var isMatch =
                    libAttr is
                        {
                            Identifier:{} libId,
                            Version:{} libVer
                        }
                    && string.Equals(libId, opt.LibraryName, StringComparison.OrdinalIgnoreCase)
                    && string.Equals(libVer, opt.LibraryVersion, StringComparison.OrdinalIgnoreCase);
                return isMatch;
            });
        if (type == null) throw new InvalidOperationException($"Cannot find library type for {opt.Library}");

        Console.WriteLine($"Resolved library type: {type.AssemblyQualifiedName}");
        return type;
    }

    private static IDictionary<string, object> LoadInputParameters(string inputParameterFile)
    {
        Console.WriteLine("Loading test case input parameters");
        var parameters = new Dictionary<string, object>();

        var jsonData = File.ReadAllText(inputParameterFile, Encoding.UTF8);
        using (JsonDocument document = JsonDocument.Parse(jsonData))
        {
            var root = document.RootElement;

            // extract input parameter "Measurement Period"
            if (root.TryGetProperty("Measurement Period", out JsonElement period))
            {
                JsonElement start;
                if (!period.TryGetProperty("Start", out start))
                {
                    throw new ArgumentException($"Cannot find parameter 'Measurement Period'.Start in file '{inputParameterFile}'.");
                }
                JsonElement end;
                if (!period.TryGetProperty("End", out end))
                {
                    throw new ArgumentException($"Cannot find parameter 'Measurement Period'.end in file '{inputParameterFile}'.");
                }

                CqlDateTime startCqlDateTime;
                if (!CqlDateTime.TryParse(start.GetString()!, out startCqlDateTime!))
                {
                    throw new ArgumentException($"Cannot convert parameter 'Measurement Period'.start in file '{inputParameterFile}' to CqlDateTime.");
                }
                CqlDateTime endCqlDateTime;
                if (!CqlDateTime.TryParse(end.GetString()!, out endCqlDateTime!))
                {
                    throw new ArgumentException($"Cannot convert parameter 'Measurement Period'.end in file '{inputParameterFile}' to CqlDateTime.");
                }

                parameters.Add(
                    "Measurement Period",
                    new CqlInterval<CqlDateTime>(
                        startCqlDateTime,
                        endCqlDateTime,
                        true,
                        true
                    ));
            }
            else
            {
                throw new ArgumentException($"Cannot find parameter 'Measurement Period' in file '{inputParameterFile}'");
            }
        }

        parameters.DumpConsole("Input Parameters");
        return parameters;
    }
}
