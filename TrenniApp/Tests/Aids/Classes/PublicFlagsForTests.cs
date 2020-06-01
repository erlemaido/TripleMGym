using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids.Classes;

namespace TrainingApp.Tests.Aids.Classes {

    [TestClass] public class PublicFlagsForTests : BaseTests {

        [TestInitialize] public void TestInitialize() {
            type = typeof(PublicFlagsFor);
            testType = typeof(TestClass);
        }

        private const BindingFlags p = BindingFlags.Public;
        private const BindingFlags i = BindingFlags.Instance;
        private const BindingFlags s = BindingFlags.Static;
        private const BindingFlags d = BindingFlags.DeclaredOnly;
        private Type testType;

        internal class TestClass 
        {
        }

        [TestMethod] public void AllTest() 
            => TestMembers(i | s | p, PublicFlagsFor.all, 5);

        [TestMethod] public void InstanceTest() 
            => TestMembers(i | p, PublicFlagsFor.instance, 5);

        [TestMethod] public void StaticTest() 
            => TestMembers(s | p, PublicFlagsFor.@static, 0);

        [TestMethod] public void DeclaredTest() 
            => TestMembers(d | i | s | p, PublicFlagsFor.declared, 1);

        private void TestMembers(BindingFlags expected, BindingFlags actual,
            int membersCount) {
            var a = testType.GetMembers(actual);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(membersCount, a.Length);
        }
    }
}
