using Abc.Aids.Enums;
using Abc.Aids.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Aids.Enums {

    [TestClass] public class RuleElementTypeTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(RuleElementType);

        [TestMethod] public void CountTest()
            => Assert.AreEqual(4, GetEnum.Count<RuleElementType>());

        [TestMethod] public void UnspecifiedTest() =>
            Assert.AreEqual(0, (int) RuleElementType.Unspecified);

        [TestMethod] public void VariableTest() =>
            Assert.AreEqual(3, (int) RuleElementType.Variable);

        [TestMethod] public void OperandTest() =>
            Assert.AreEqual(2, (int) RuleElementType.Operand);

        [TestMethod] public void OperatorTest() =>
            Assert.AreEqual(1, (int) RuleElementType.Operator);

    }

}
