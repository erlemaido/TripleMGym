using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids.Formats.Dates;

namespace TrainingApp.Tests.Aids.Formats.Dates {

    [TestClass] public class MidnightTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(Midnight);

        [TestMethod] public void LongTest()
            => Assert.AreEqual("00:00:00", Midnight.Long);

        [TestMethod] public void ShortTest()
            => Assert.AreEqual("00:00", Midnight.Short);

    }

}
