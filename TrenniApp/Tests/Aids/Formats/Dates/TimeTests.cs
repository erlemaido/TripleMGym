﻿using System.Globalization;
using Abc.Aids.Formats.Dates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids;
using Date = Abc.Aids.Formats.Dates.Date;

namespace TrainingApp.Tests.Aids.Formats.Dates {

    [TestClass] public class TimeTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(Time);

        [TestMethod] public void LongTest()
            => Assert.AreEqual("HH:mm:ss", Time.Long);

        [TestMethod] public void ShortTest()
            => Assert.AreEqual("HH:mm", Time.Short);

        [TestMethod] public void SeparatorsTest()
            => Assert.AreEqual(". Tt", Time.Separators);

        [TestMethod] public void AllTest() {
            foreach (var f in Time.All) {
                var expected = GetRandom.DateTime();
                var s = expected.ToString(f);
                var b = System.DateTime.TryParseExact(s, f,
                    UseCulture.Invariant, DateTimeStyles.None, out var actual);
                Assert.AreEqual(true, b);
                Assert.AreEqual(expected.ToString(f), actual.ToString(f));
            }
        }

        [TestMethod] public void IsTimeTest() {
            foreach (var f in Time.All) Assert.IsTrue(Time.IsTime(f));
            foreach (var f in Date.All) Assert.IsFalse(Time.IsTime(f));
            Assert.IsFalse(Time.IsTime(null));
            Assert.IsFalse(Time.IsTime(""));
            Assert.IsFalse(Time.IsTime("  "));
            Assert.IsFalse(Time.IsTime(GetRandom.String()));
        }

    }

}
