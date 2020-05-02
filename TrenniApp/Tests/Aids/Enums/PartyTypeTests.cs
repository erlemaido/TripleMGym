using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids.Enums;
using TrainingApp.Aids.Reflection;

namespace TrainingApp.Tests.Aids.Enums
{
    public class PartyTypeTests : BaseTests
    {

        [TestInitialize] public void TestInitialize() => type = typeof(PartyType);

        [TestMethod] public void CountTest() => Assert.AreEqual(3, GetEnum.Count<PartyType>());

        [TestMethod]
        public void UnspecifiedTest() =>
            Assert.AreEqual(0, (int)PartyType.Unspecified);

        [TestMethod]
        public void OrganizationTest() =>
            Assert.AreEqual(1, (int)PartyType.Organization);

        [TestMethod]
        public void PersonTest() =>
            Assert.AreEqual(2, (int)PartyType.Person);
    }

}
