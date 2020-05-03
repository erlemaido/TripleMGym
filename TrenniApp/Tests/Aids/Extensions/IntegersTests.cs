﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids.Extensions;
using TrainingApp.Aids.Random;

namespace TrainingApp.Tests.Aids.Extensions {
    [TestClass]
    public class IntegersTests :BaseTests {
        [TestInitialize] public void TestInitialize() { type = typeof(Integers); }

        [TestMethod] public void ToIntegerTest() => testToInt();

        private void testToInt() {
            testToInt(GetRandom.String(), false);
            testToInt(GetRandom.DateTime(), false);
            testToInt(GetRandom.Float(), false);
            testToInt(GetRandom.UInt64(), false);
            testToInt(GetRandom.Int64(), false);
            testToInt(GetRandom.Double(), false);
            testToInt(GetRandom.Decimal(), false);
            testToInt(GetRandom.UInt8(), true);
            testToInt(GetRandom.UInt16(), true);
            testToInt(GetRandom.UInt32(max: int.MaxValue), true);
            testToInt(GetRandom.Int8(), true);
            testToInt(GetRandom.Int16(), true);
            testToInt(GetRandom.Int32(), true);
        }

        private void testToInt(object x, bool hasValue) {
            var s = x.ToString();
            int i;
            var expected = hasValue? int.Parse(s): int.MaxValue;
            if (hasValue) {
                Assert.AreEqual(expected, Integers.ToInteger(x));
                Assert.AreEqual(expected, Integers.ToInteger(s));
                Assert.AreEqual(true, Integers.ToInteger(x, out i));
                Assert.AreEqual(expected, i);
                Assert.AreEqual(true, Integers.ToInteger(s, out i));
                Assert.AreEqual(expected, i);
            }
            else {
                Assert.AreEqual(expected, Integers.ToInteger(x));
                Assert.AreEqual(expected, Integers.ToInteger(s));
                Assert.AreEqual(false, Integers.ToInteger(x, out i));
                Assert.AreEqual(expected, i);
                Assert.AreEqual(false, Integers.ToInteger(s, out i));
                Assert.AreEqual(expected, i);
            }
        }

        [TestMethod]
        public void TryToIntegerTest() => testToInt();
    }
}