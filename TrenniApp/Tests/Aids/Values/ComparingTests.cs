using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids.Methods;
using TrainingApp.Aids.Random;
using TrainingApp.Aids.Values;

namespace TrainingApp.Tests.Aids.Values {

    [TestClass] public class ComparingTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(Comparing);

        [TestMethod] public void IsGreaterTest() => doTest(testGreater);

        private static void doTest(Action<IComparable, IComparable> action) {
            action(true, false);
            action(GetRandom.String(), GetRandom.String());
            action(GetRandom.Int8( max: 0), GetRandom.Int8(1));
            action(GetRandom.Int16(), GetRandom.Int16());
            action(GetRandom.Int32(), GetRandom.Int32());
            action(GetRandom.Int64(), GetRandom.Int64());
            action(GetRandom.UInt8(max: 100), GetRandom.UInt8(101));
            action(GetRandom.UInt16(), GetRandom.UInt16());
            action(GetRandom.UInt32(), GetRandom.UInt32());
            action(GetRandom.UInt64(), GetRandom.UInt64());
            action(GetRandom.Float(), GetRandom.Float());
            action(GetRandom.Double(), GetRandom.Double());
            action(GetRandom.Decimal(), GetRandom.Decimal());
            action(GetRandom.DateTime(), GetRandom.DateTime());
            action(GetRandom.TimeSpan(), GetRandom.TimeSpan());
        }

        private void testGreater<T>(T x, T y) where T : notnull, IComparable {
            while (x.Equals(y)) y = GetRandom.Object<T>();
            Sort.Descending(ref x, ref y);
            Assert.AreEqual(true, x.IsGreater(y));
            Assert.AreEqual(false, x.IsGreater(x));
            Assert.AreEqual(false, y.IsGreater(x));
        }

        private void testNotGreater<T>(T x, T y) where T : notnull, IComparable {
            while (x.Equals(y)) y = GetRandom.Object<T>();
            Sort.Descending(ref x, ref y);
            Assert.AreEqual(false, x.IsNotGreater(y));
            Assert.AreEqual(true, x.IsNotGreater(x));
            Assert.AreEqual(true, y.IsNotGreater(x));
        }

        [TestMethod] public void IsNotGreaterTest() => doTest(testNotGreater);

        private void testLess<T>(T x, T y) where T : notnull, IComparable {
            while (x.Equals(y)) y = GetRandom.Object<T>();
            Sort.Ascending(ref x, ref y);
            Assert.AreEqual(true, x.IsLess(y));
            Assert.AreEqual(false, x.IsLess(x));
            Assert.AreEqual(false, y.IsLess(x));
        }

        private void testNotLess<T>(T x, T y) where T : notnull, IComparable {
            while (x.Equals(y)) y = GetRandom.Object<T>();
            Sort.Ascending(ref x, ref y);
            Assert.AreEqual(false, x.IsNotLess(y));
            Assert.AreEqual(true, x.IsNotLess(x));
            Assert.AreEqual(true, y.IsNotLess(x));
        }

        [TestMethod] public void IsLessTest() => doTest(testLess);

        [TestMethod] public void IsNotLessTest() => doTest(testNotLess);

        [TestMethod] public void IsEqualTest() => doTest(testEqual);

        private void testEqual<T>(T x, T y) where T : notnull, IComparable {
            Assert.AreEqual(true, x.IsEqual(x));
            Assert.AreEqual(false, x.IsEqual(y));
        }

        [TestMethod] public void IsNotEqualTest() => doTest(testNotEqual);

        private void testNotEqual<T>(T x, T y) where T : notnull, IComparable {
            Assert.AreEqual(true, x.IsNotEqual(y));
            Assert.AreEqual(false, x.IsNotEqual(x));
        }

    }

}
