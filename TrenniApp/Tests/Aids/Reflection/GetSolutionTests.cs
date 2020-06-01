using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids.Reflection;

namespace TrainingApp.Tests.Aids.Reflection {

    [TestClass] public class GetSolutionTests : BaseTests {

        private static readonly string assemblyName = "TrainingApp.Aids";
        private const string DummyName = "bla-bla";

        [TestInitialize] public void TestInitialize() => type = typeof(GetSolution);

        [TestMethod] public void DomainTest() {
            var expected = AppDomain.CurrentDomain;
            var actual = GetSolution.Domain;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] public void AssemblyByNameTest() {
            Assert.IsNull(GetSolution.AssemblyByName(DummyName));
            var assembly = GetSolution.AssemblyByName(assemblyName);
            Assert.IsTrue(assembly.FullName != null && assembly.FullName.StartsWith(assemblyName));
        }

        [TestMethod] public void TypesForAssemblyTest() {
            var expected = GetSolution.AssemblyByName(assemblyName).GetTypes();
            var actual = GetSolution.TypesForAssembly(DummyName);
            Assert.AreEqual(0, actual.Count);
            Assert.IsInstanceOfType(actual, typeof(List<Type>));
            actual = GetSolution.TypesForAssembly(assemblyName);
            Assert.AreEqual(expected.Length, actual.Count);
            foreach (var e in expected) Assert.IsTrue(actual.Contains(e));
        }

        [TestMethod] public void TypeNamesForAssemblyTest() {
            var expected = GetSolution.AssemblyByName(assemblyName).GetTypes();
            var actual = GetSolution.TypeNamesForAssembly(DummyName);
            Assert.AreEqual(0, actual.Count);
            Assert.IsInstanceOfType(actual, typeof(List<string>));
            actual = GetSolution.TypeNamesForAssembly(assemblyName);
            Assert.AreEqual(expected.Length, actual.Count);
            foreach (var e in expected)
                Assert.IsTrue(actual.Contains(e.FullName));
        }
    }
}
