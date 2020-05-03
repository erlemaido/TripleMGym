using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids.Enums;
using TrainingApp.Aids.Reflection;

namespace TrainingApp.Tests.Aids.Enums {

    [TestClass] public class IsoGenderTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(IsoGender);

        [TestMethod] public void CountTest()
            => Assert.AreEqual(4, GetEnum.Count<IsoGender>());

        [TestMethod] public void NotKnownTest() =>
            Assert.AreEqual(0, (int) IsoGender.NotKnown);

        [TestMethod] public void MaleTest() =>
            Assert.AreEqual(1, (int) IsoGender.Male);

        [TestMethod] public void FemaleTest() =>
            Assert.AreEqual(2, (int) IsoGender.Female);

        [TestMethod] public void NotApplicableTest() =>
            Assert.AreEqual(9, (int) IsoGender.NotApplicable);

    }

}
