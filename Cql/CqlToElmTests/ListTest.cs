﻿using Hl7.Cql.Abstractions;
using Hl7.Cql.Elm;
using Hl7.Cql.Fhir;
using Hl7.Cql.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl7.Cql.CqlToElm.Test
{
    [TestClass]
    public class ListTest: Base
    {
        [ClassInitialize]
#pragma warning disable IDE0060 // Remove unused parameter
        public static void Initialize(TestContext context) => ClassInitialize();
#pragma warning restore IDE0060 // Remove unused parameter



        [TestMethod]
        public void Empty_List()
        {
            var library = DefaultConverter.ConvertLibrary(@"
                library ListTest version '1.0.0'

                define private Empty_List: { }
            ");
            Assert.IsNotNull(library.statements);
            Assert.AreEqual(1, library.statements.Length);
            Assert.IsNotNull(library.statements[0].expression.localId);
            Assert.IsNotNull(library.statements[0].expression.locator);
            Assert.IsInstanceOfType(library.statements[0].expression, typeof(List));
            {
                var list = (List)library.statements[0].expression;
                AssertListType(list.resultTypeSpecifier, $"{{{SystemUri}}}Any");
                AssertList(list, Array.Empty<object>());
            }
        }

        [TestMethod]
        public void List_Integer()
        {
            var library = DefaultConverter.ConvertLibrary(@"
                library ListTest version '1.0.0'

                define private List_Integer: { 1, 2, 3 }
            ");
            Assert.IsNotNull(library.statements);
            Assert.AreEqual(1, library.statements.Length);
            Assert.IsNotNull(library.statements[0].expression.localId);
            Assert.IsNotNull(library.statements[0].expression.locator);
            Assert.IsInstanceOfType(library.statements[0].expression, typeof(List));
            {
                var list = (List)library.statements[0].expression;
                AssertListType(list.resultTypeSpecifier, $"{{{SystemUri}}}Integer");
                AssertList(list, new int?[] { 1, 2, 3 });
            }
        }

        [TestMethod]
        public void List_Mixed_ToQuantity()
        {
            var library = DefaultConverter.ConvertLibrary(@"
                library ListTest version '1.0.0'

                define private List_Mixed_ToQuantity: { 1, 2L, 3.0, 4.0 '1' }
            ");
            Assert.IsNotNull(library.statements);
            Assert.AreEqual(1, library.statements.Length);
            Assert.IsNotNull(library.statements[0].expression.localId);
            Assert.IsNotNull(library.statements[0].expression.locator);
            Assert.IsInstanceOfType(library.statements[0].expression, typeof(List));
            {
                var list = (List)library.statements[0].expression;
                AssertListType(list.resultTypeSpecifier, $"{{{SystemUri}}}Quantity");
                AssertList(list, new CqlQuantity?[] {
                    new CqlQuantity(1m, UCUMUnits.Default),
                    new CqlQuantity(2m, UCUMUnits.Default),
                    new CqlQuantity(3m, UCUMUnits.Default),
                    new CqlQuantity(4m, UCUMUnits.Default)
                });
            }
        }

        [TestMethod]
        public void List_Mixed_ToDecimal()
        {
            var library = DefaultConverter.ConvertLibrary(@"
                library ListTest version '1.0.0'

                define private List_Mixed_ToDecimal: { 1, 2L, 3.0 }
            ");
            Assert.IsNotNull(library.statements);
            Assert.AreEqual(1, library.statements.Length);
            Assert.IsNotNull(library.statements[0].expression.localId);
            Assert.IsNotNull(library.statements[0].expression.locator);
            Assert.IsInstanceOfType(library.statements[0].expression, typeof(List));
            {
                var list = (List)library.statements[0].expression;
                AssertListType(list.resultTypeSpecifier, $"{{{SystemUri}}}Decimal");
                AssertList(list, new decimal?[] { 1m, 2m, 3m });
            }
        }

        [TestMethod]
        public void List_Mixed_ToLong()
        {
            var library = DefaultConverter.ConvertLibrary(@"
                library ListTest version '1.0.0'

                define private List_Mixed_ToLong: { 1, 2L }
            ");
            Assert.IsNotNull(library.statements);
            Assert.AreEqual(1, library.statements.Length);
            Assert.IsNotNull(library.statements[0].expression.localId);
            Assert.IsNotNull(library.statements[0].expression.locator);
            Assert.IsInstanceOfType(library.statements[0].expression, typeof(List));
            {
                var list = (List)library.statements[0].expression;
                AssertListType(list.resultTypeSpecifier, $"{{{SystemUri}}}Long");
                AssertList(list, new long?[] { 1L, 2L });
            }
        }

        [TestMethod]
        public void List_Mixed_Any()
        {
            var library = DefaultConverter.ConvertLibrary(@"
                library ListTest version '1.0.0'

                define private List_Mixed_Any: { 1, 'string' }
            ");
            Assert.IsNotNull(library.statements);
            Assert.AreEqual(1, library.statements.Length);
            Assert.IsNotNull(library.statements[0].expression.localId);
            Assert.IsNotNull(library.statements[0].expression.locator);
            Assert.IsInstanceOfType(library.statements[0].expression, typeof(List));
            {
                var list = (List)library.statements[0].expression;
                AssertListType(list.resultTypeSpecifier, $"{{{SystemUri}}}Any");
                AssertList(list, new object?[] { 1, "string" });
            }
        }


        [TestMethod]
        public void List_Nulls()
        {
            var library = DefaultConverter.ConvertLibrary(@"
                library ListTest version '1.0.0'

                define private List_Nulls: { null, null }
            ");
            Assert.IsNotNull(library.statements);
            Assert.AreEqual(1, library.statements.Length);
            Assert.IsNotNull(library.statements[0].expression.localId);
            Assert.IsNotNull(library.statements[0].expression.locator);
            Assert.IsInstanceOfType(library.statements[0].expression, typeof(List));
            {
                var list = (List)library.statements[0].expression;
                AssertListType(list.resultTypeSpecifier, $"{{{SystemUri}}}Any");
                AssertList(list, new object?[] { null, null });
            }
        }

    }
}
