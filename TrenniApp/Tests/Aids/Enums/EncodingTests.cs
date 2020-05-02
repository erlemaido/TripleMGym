using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids.Enums;

namespace TrainingApp.Tests.Aids.Enums {

    [TestClass] public class EncodingTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(Encoding);

        //[TestMethod] public void CountTest() => Assert.AreEqual(4, GetEnum.Count<Encoding>());

        //[TestMethod] public void AsciiTest() => Assert.AreEqual(0, (int) Encoding.Ascii);

        //[TestMethod] public void UnicodeTest() => Assert.AreEqual(1, (int) Encoding.Unicode);

        //[TestMethod] public void Utf7Test() => Assert.AreEqual(2, (int) Encoding.Utf7);

        //[TestMethod] public void Utf8Test() => Assert.AreEqual(3, (int) Encoding.Utf8);

    }

}
