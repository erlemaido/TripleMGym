using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids.Enums;
using TrainingApp.Aids.Reflection;

namespace TrainingApp.Tests.Aids.Enums
{
    [TestClass]
    public class RuleVariableTypeTests : BaseTests
    {

        [TestInitialize] public void TestInitialize() => type = typeof(RuleVariableType);

        [TestMethod]
        public void CountTest()
            => Assert.AreEqual(10, GetEnum.Count<RuleVariableType>());

        [TestMethod]
        public void UnspecifiedTest() =>
            Assert.AreEqual(0, (int)RuleVariableType.Unspecified);
        [TestMethod]
        public void BooleanTest() =>
            Assert.AreEqual(1, (int)RuleVariableType.Boolean);

        [TestMethod]
        public void StringTest() =>
            Assert.AreEqual(2, (int)RuleVariableType.String);

        [TestMethod]
        public void IntegerTest() =>
            Assert.AreEqual(3, (int)RuleVariableType.Integer);

        [TestMethod]
        public void DecimalTest() =>
            Assert.AreEqual(4, (int)RuleVariableType.Decimal);

        [TestMethod]
        public void DoubleTest() =>
            Assert.AreEqual(5, (int)RuleVariableType.Double);

        [TestMethod]
        public void DateTimeTest() =>
            Assert.AreEqual(6, (int)RuleVariableType.DateTime);

        [TestMethod]
        public void QuantityTest() =>
            Assert.AreEqual(7, (int)RuleVariableType.Quantity);

        [TestMethod]
        public void MoneyTest() =>
            Assert.AreEqual(8, (int)RuleVariableType.Money);

        [TestMethod]
        public void ErrorTest() =>
            Assert.AreEqual(9, (int)RuleVariableType.Error);

    }

}
