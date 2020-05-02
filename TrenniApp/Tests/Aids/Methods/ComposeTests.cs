using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids.Methods;
using TrainingApp.Aids.Random;

namespace TrainingApp.Tests.Aids.Methods {

    [TestClass] public class ComposeTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(Compose);

        [TestMethod] public void IdTest() {
            var h = GetRandom.String();
            var t = GetRandom.String();
            var actual = Compose.Id(h, t);
            var expected = $"{h}.{t}";
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(".", Compose.Id(null, null));
        }

    }

}
