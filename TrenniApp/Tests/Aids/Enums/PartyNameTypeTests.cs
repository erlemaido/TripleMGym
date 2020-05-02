using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids.Enums;
using TrainingApp.Aids.Reflection;

namespace TrainingApp.Tests.Aids.Enums
{
    [TestClass]
    public class PartyNameTypeTests : BaseTests
    {

        [TestInitialize] public void TestInitialize() => type = typeof(PartyNameType);

        [TestMethod] public void CountTest() => Assert.AreEqual(3, GetEnum.Count<PartyNameType>());

        [TestMethod]
        public void UnspecifiedTest() =>
            Assert.AreEqual(0, (int)PartyNameType.Unspecified);

        [TestMethod]
        public void OrganizationNameTest() =>
            Assert.AreEqual(1, (int)PartyNameType.OrganizationName);

        [TestMethod]
        public void PersonNameTest() =>
            Assert.AreEqual(2, (int)PartyNameType.PersonName);
    }

}
