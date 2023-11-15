﻿using FluentAssertions;
using Hl7.Cql.Elm;
using Hl7.Cql.Fhir;
using Hl7.Cql.Primitives;
using Hl7.Cql.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using M = Hl7.Fhir.Model;

namespace Hl7.Cql.CqlToElm.Test
{
    [TestClass]
    public class RefTest : Base
    {
        [ClassInitialize]
#pragma warning disable IDE0060 // Remove unused parameter
        public static void Initialize(TestContext context) => ClassInitialize();
#pragma warning restore IDE0060 // Remove unused parameter

        [TestMethod]
        public void ValueSet_Local()
        {
            var library = MakeLibrary($@"
                library {nameof(RefTest)} version '1.0.0'

                valueset ""vs"": 'http://xyz.com'

                define private {nameof(ValueSet_Local)}: ""vs""
            ");
            Assert.IsNotNull(library.statements);
            Assert.AreEqual(1, library.statements.Length);
            Assert.IsNotNull(library.statements[0].expression.localId);
            Assert.IsNotNull(library.statements[0].expression.locator);
            Assert.IsInstanceOfType(library.statements[0].expression, typeof(ValueSetRef));
            AssertType(library.statements[0].expression, SystemTypes.ValueSetType);
            var result = Run<CqlValueSet>(library, nameof(ValueSet_Local));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CodeSystem_Local()
        {
            var library = MakeLibrary($@"
                library {nameof(RefTest)} version '1.0.0'

                private codesystem CS: 'id' version 'version string'

                define private {nameof(CodeSystem_Local)}: ""CS""
            ");
            Assert.IsNotNull(library.statements);
            Assert.AreEqual(1, library.statements.Length);
            Assert.IsNotNull(library.statements[0].expression.localId);
            Assert.IsNotNull(library.statements[0].expression.locator);
            Assert.IsInstanceOfType(library.statements[0].expression, typeof(CodeSystemRef));
            AssertType(library.statements[0].expression, SystemTypes.CodeSystemType);
            var result = Run<CqlCode[]>(library, nameof(CodeSystem_Local));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Code_Local()
        {
            var library = MakeLibrary($@"
                library {nameof(RefTest)} version '1.0.0'

                private codesystem CS: 'id' version 'version string'
                private code C: 'id' from CS display 'Code display text'

                define private {nameof(Code_Local)}: ""C""
            ");
            Assert.IsNotNull(library.statements);
            Assert.AreEqual(1, library.statements.Length);
            Assert.IsNotNull(library.statements[0].expression.localId);
            Assert.IsNotNull(library.statements[0].expression.locator);
            Assert.IsInstanceOfType(library.statements[0].expression, typeof(CodeRef));
            AssertType(library.statements[0].expression, SystemTypes.CodeType);
            var result = Run<CqlCode>(library, nameof(Code_Local));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Concept_Local()
        {
            var library = MakeLibrary($@"
                library {nameof(RefTest)} version '1.0.0'

                private codesystem CS: 'id' version 'version string'
                private code C: 'id' from CS display 'Code display text'
                private concept TheConcept: {{ C }} display 'My concept'

                define private {nameof(Concept_Local)}: ""TheConcept""
            ");
            Assert.IsNotNull(library.statements);
            Assert.AreEqual(1, library.statements.Length);
            Assert.IsNotNull(library.statements[0].expression.localId);
            Assert.IsNotNull(library.statements[0].expression.locator);
            Assert.IsInstanceOfType(library.statements[0].expression, typeof(ConceptRef));
            AssertType(library.statements[0].expression, SystemTypes.ConceptType);
            var result = Run<CqlConcept>(library, nameof(Concept_Local));
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Parameter()
        {
            var library = MakeLibrary($@"
                library {nameof(RefTest)} version '1.0.0'

                private parameter ""Measurement Year"" System.Integer default 2023

                define private {nameof(Parameter)}: ""Measurement Year""
            ");
            Assert.IsNotNull(library.statements);
            Assert.AreEqual(1, library.statements.Length);
            Assert.IsNotNull(library.statements[0].expression.localId);
            Assert.IsNotNull(library.statements[0].expression.locator);
            Assert.IsInstanceOfType(library.statements[0].expression, typeof(ParameterRef));
            AssertType(library.statements[0].expression, SystemTypes.IntegerType);
            var result = Run<int?>(library, nameof(Parameter));
            Assert.IsNotNull(result);
            Assert.AreEqual(2023, result);
        }

        private static T? Run<T>(Library library, string member, Hl7.Fhir.Model.Bundle? bundle = null)
        {
            var eb = ExpressionBuilderFor(library);
            var lambdas = eb.Build();
            var delegates = lambdas.CompileAll();
            var dg = delegates[library.NameAndVersion, member];
            var ctx = FhirCqlContext.ForBundle(bundle, delegates: delegates);
            var result = dg.DynamicInvoke(ctx);
            Assert.IsInstanceOfType(result, typeof(T));
            return (T?)result;
        }

        private static void AssertType(Expression expression, NamedTypeSpecifier spec)
        {
            expression.resultTypeName.Should().Be(spec.name);
            expression.resultTypeSpecifier.Should().Be(spec);
        }

        private ExpressionDef shouldDefineExpression(Library l, string name) =>
            l.ShouldDefine<ExpressionDef>(name);

        [TestMethod]
        public void Expression()
        {
            var library = MakeLibrary($@"
                library {nameof(RefTest)} version '1.0.0'

                define private four: 4

                define private {nameof(Expression)}: four
            ");

            var f = shouldDefineExpression(library, nameof(Expression));
            var fref = f.expression.Should().BeOfType<ExpressionRef>().Subject;
            AssertType(fref, SystemTypes.IntegerType);
            fref.name.Should().Be("four");

            var result = Run<int>(library, nameof(Expression));
            result.Should().Be(4);
        }

        [TestMethod]
        public void Function()
        {
            var library = MakeLibrary($@"
                library {nameof(RefTest)} version '1.0.0'

                define private function double(a Integer): a*2

                define private {nameof(Function)}: double(4)
            ");

            var f = shouldDefineExpression(library, nameof(Function));
            var fref = f.expression.Should().BeOfType<FunctionRef>().Subject;
            fref.name.Should().Be("double");
            fref.operand.Should().ContainSingle().Which.Should().BeLiteralInteger(4);

            var result = Run<int>(library, nameof(Function));
            result.Should().Be(8);
        }

        [TestMethod]
        public void InvokeParameter()
        {
            var library = MakeLibrary($@"
               library BareMinimum version '0.0.1'
    
                parameter x default 'bla'

                define {nameof(InvokeParameter)}: x(4)
            ", "x is not a function, so it cannot be invoked.");
        }

        [TestMethod]
        public void InvokeExpression()
        {
            var library = MakeLibrary($@"
               library BareMinimum version '0.0.1'
    
                define pi: 3.14

                define {nameof(InvokeExpression)}: pi()
            ", "pi is an expression, and should be invoked without the parenthesis.");
        }

        [TestMethod]
        public void InvokeNonLocalFunction()
        {
            var library = MakeLibrary($@"
               library BareMinimum version '0.0.1'

               include Math

               define {nameof(InvokeExpression)}: Math.Floor(4)
            ", "Could not find library Math.", "Unable to resolve identifier Floor in library Math.");
        }

        [TestMethod]
        public void InvokeProperty()
        {
            var library = MakeLibrary($@"
                    library BareMinimum version '0.0.1'
    
                    using FHIR

                    context Patient

                    // Just here to check that we parse the datatype well.
                    define function getContactName(contact FHIR.Patient.Contact): contact.name

                    define getName: Patient.name
            ");

            var getContactName = library.ShouldDefine<FunctionDef>("getContactName");
            getContactName.operand.Should().ContainSingle().Which
                .Should().BeOfType<OperandDef>().Which
                .resultTypeSpecifier.Should().Be(TestExtensions.ForFhir("Patient.Contact"));
            getContactName.resultTypeSpecifier.Should().Be(TestExtensions.ForFhir("HumanName"));

            var getName = shouldDefineExpression(library, "getName");
            var prop = getName.expression.Should().BeOfType<Property>().Subject;
            prop.path.Should().Be("name");
            prop.source.Should().BeOfType<ExpressionRef>().Which.name.Should().Be("Patient");
            prop.resultTypeSpecifier.Should().Be(TestExtensions.ForFhir("HumanName").ToListType());

            var bundle = new M.Bundle();
            var patient = new M.Patient { Name = new() { new() { Given = new[] { "John" }, Family = "Doe" } } };
            bundle.Entry.Add(new() { Resource = patient });

            var result = Run<List<M.HumanName>>(library, "getName", bundle);
            result.Should().BeEquivalentTo(patient.Name);
        }

    }
}
