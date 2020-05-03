﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids.Formats.Dates;

namespace TrainingApp.Tests.Aids.Formats.Dates {

    [TestClass] public class InFileNameTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(InFileName);

        [TestMethod] public void LongTest()
            => Assert.AreEqual("yyyy.MM.dd.HH.mm.ss", InFileName.Long);

        [TestMethod] public void ShortTest()
            => Assert.AreEqual("yyyy.MM.dd", InFileName.Short);

        [TestMethod] public void ArchiveTest()
            => Assert.AreEqual("dd.MM.yyyy.HH.mm.ss", InFileName.Archive);

    }

}
