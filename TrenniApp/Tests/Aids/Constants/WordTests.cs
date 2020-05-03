using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids.Constants;

namespace TrainingApp.Tests.Aids.Constants {

    [TestClass] public class WordTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(Word);

        [TestMethod] public void UndefinedTest() => Assert.AreEqual("Undefined", Word.Undefined);

        [TestMethod] public void UnspecifiedTest()
            => Assert.AreEqual("Unspecified", Word.Unspecified);

        [TestMethod] public void ListTest()
            => Assert.AreEqual("List", Word.List);

        [TestMethod] public void NoneTest()
            => Assert.AreEqual("None", Word.None);

        [TestMethod] public void NullTest()
            => Assert.AreEqual("Null", Word.Null);

    }

}
