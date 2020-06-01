using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids.Classes;
using TrainingApp.Aids.Reflection;

namespace TrainingApp.Tests.Aids.Reflection {

    [TestClass] public class GetClassTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(GetClass);

        [TestMethod] public void NamespaceTest() {
            var t = typeof(object);
            Assert.AreEqual(t.Namespace, GetClass.Namespace(t));
            Assert.AreEqual(string.Empty, GetClass.Namespace(null));
        }

        [TestMethod] public void MembersTest() {
            TestMember(typeof(TestClass));
            TestNull(null);
        }

        private static void TestNull(Type t) {
            var a = GetClass.Members(t);
            Assert.IsInstanceOfType(a, typeof(List<MemberInfo>));
            Assert.AreEqual(0, a.Count);
        }

        private static void TestMember(Type t) {
            var a = GetClass.Members(t, PublicFlagsFor.all, false);
            var e = t.GetMembers(PublicFlagsFor.all);
            Assert.AreEqual(e.Length, a.Count);
            Assert.AreEqual(10, a.Count);
            foreach (var v in e) Assert.IsTrue(a.Contains(v));
            Assert.AreEqual(7, GetClass.Members(t).Count);
        }

        [TestMethod] public void PropertiesTest() {
            var a = GetClass.Properties(typeof(TestClass));
            Assert.IsNotNull(a);
            Assert.IsInstanceOfType(a, typeof(List<PropertyInfo>));
            Assert.AreEqual(1, a.Count);
            Assert.AreEqual("F", a[0].Name);
        }

        [TestMethod]
        public void PropertyTest()
        {
            Assert.Inconclusive();
        }

        internal class TestBaseClass 
        {
        }

        internal class TestClass : TestBaseClass {

            public int e = 0;
            public string F { get; set; }

        }
    }
}
