using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Aids {

    [TestClass] public class UriKindTests {

        [TestMethod] public void CanCreateTest() {
            Assert.AreEqual("/aaa", new Uri("/aaa", UriKind.Relative).ToString());
            Assert.AreEqual("\\aaa", new Uri("\\aaa", UriKind.Relative).ToString());
            Assert.AreEqual(".\\aaa", new Uri(".\\aaa", UriKind.Relative).ToString());
            Assert.AreEqual("..\\aaa", new Uri("..\\aaa", UriKind.Relative).ToString());
            Assert.AreEqual("../aaa", new Uri("../aaa", UriKind.Relative).ToString());
            Assert.AreEqual("./aaa", new Uri("./aaa", UriKind.Relative).ToString());
            Assert.AreEqual("aaa", new Uri("aaa", UriKind.Relative).ToString());
        }
    }
}
