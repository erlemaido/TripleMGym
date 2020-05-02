using Abc.Aids.Enums;
using Abc.Aids.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Aids.Enums {

    [TestClass] public class PartyContactTypeTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(PartyContactType);

        [TestMethod] public void CountTest()
            => Assert.AreEqual(5, GetEnum.Count<PartyContactType>());

        [TestMethod] public void UnspecifiedTest() =>
            Assert.AreEqual(0, (int) PartyContactType.Unspecified);

        [TestMethod] public void EmailAddressTest() =>
            Assert.AreEqual(1, (int) PartyContactType.EmailAddress);

        [TestMethod] public void WebPageAddressTest() =>
            Assert.AreEqual(2, (int) PartyContactType.WebPageAddress);

        [TestMethod] public void TelecomDeviceAddressTest() =>
            Assert.AreEqual(3, (int) PartyContactType.TelecomDeviceAddress);

        [TestMethod] public void GeographicAddressTest() =>
            Assert.AreEqual(4, (int) PartyContactType.GeographicAddress);


    }

}

