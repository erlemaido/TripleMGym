using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids.Random;
using TrainingApp.Data.SportsClub;

namespace TrainingApp.Tests.Aids.Random {

    [TestClass] public class GetRandomTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(GetRandom);

        [TestMethod] public void BoolTest() {
            var b = GetRandom.Bool();
            Assert.IsInstanceOfType(b, typeof(bool));

            while (true)
                if (GetRandom.Bool() == !b)
                    return;
        }

        [TestMethod] public void CharTest() {
            DoTests(GetRandom.Char, 'a', 'z');
            DoTests(GetRandom.Char, 'A', 'Z');
            DoTests(GetRandom.Char, char.MinValue, char.MaxValue);
            DoTests(GetRandom.Char, char.MinValue, (char) (char.MinValue + 100));
            DoTests(GetRandom.Char, (char) (char.MaxValue - 100), char.MaxValue);
        }

        [TestMethod] public void ColorTest() => DoTests(GetRandom.Color);

        [TestMethod] public void DateTimeTest() {
            var now = DateTime.Now;
            var min = DateTime.MinValue;
            var max = DateTime.MaxValue;
            DoTests((x, y) => GetRandom.DateTime(x, y), now.AddYears(-5), now.AddYears(5));
            DoTests((x, y) => GetRandom.DateTime(x, y), min, min.AddYears(10));
            DoTests((x, y) => GetRandom.DateTime(x, y), max.AddYears(-10), max);
            DoTests((x, y) => GetRandom.DateTime(x, y), min, max);
        }

        [TestMethod] public void DecimalTest() {
            var d = 10M;
            DoTests(GetRandom.Decimal, 100M, 200M);
            DoTests(GetRandom.Decimal, -200M, 100M);
            DoTests(GetRandom.Decimal, -400M, -200M);
            DoTests(GetRandom.Decimal, decimal.MinValue, decimal.MaxValue);
            DoTests(GetRandom.Decimal, decimal.MinValue, decimal.MinValue / d);
            DoTests(GetRandom.Decimal, decimal.MaxValue / d, decimal.MaxValue);
        }

        [TestMethod] public void DoubleTest() {
            var d = 100000;
            DoTests(GetRandom.Double, (double) 10, 110);
            DoTests(GetRandom.Double, (double) -110, -10);
            DoTests(GetRandom.Double, (double) -50, 50);
            DoTests(GetRandom.Double, double.MinValue, double.MaxValue);
            DoTests(GetRandom.Double, double.MaxValue / d, double.MaxValue);
            DoTests(GetRandom.Double, double.MinValue, double.MinValue / d);
        }

        [TestMethod] public void FloatTest() {
            var d = 10F;
            DoTests(GetRandom.Float, 10F, 110F);
            DoTests(GetRandom.Float, -110F, -10F);
            DoTests(GetRandom.Float, -50F, 50F);
            DoTests(GetRandom.Float, float.MinValue, float.MaxValue);
            DoTests(GetRandom.Float, float.MaxValue / d, float.MaxValue);
            DoTests(GetRandom.Float, float.MinValue, float.MinValue / d);
        }

        [TestMethod] public void Int8Test() {
            DoTests(GetRandom.Int8, (sbyte) 10, (sbyte) 110);
            DoTests(GetRandom.Int8, (sbyte) -110, (sbyte) -10);
            DoTests(GetRandom.Int8, (sbyte) -50, (sbyte) 50);
            DoTests(GetRandom.Int8, sbyte.MinValue, (sbyte) (sbyte.MinValue + 100));
            DoTests(GetRandom.Int8, (sbyte) (sbyte.MaxValue - 100), sbyte.MaxValue);
            DoTests(GetRandom.Int8, sbyte.MinValue, sbyte.MaxValue);
        }

        [TestMethod] public void Int16Test() {
            DoTests(GetRandom.Int16, (short) 100, (short) 200);
            DoTests(GetRandom.Int16, (short) -200, (short) 100);
            DoTests(GetRandom.Int16, (short) -400, (short) -200);
            DoTests(GetRandom.Int16, short.MinValue, (short) (short.MinValue + 200));
            DoTests(GetRandom.Int16, (short) (short.MaxValue - 100), short.MaxValue);
            DoTests(GetRandom.Int16, short.MinValue, short.MaxValue);
        }

        [TestMethod] public void Int32Test() {
            DoTests(GetRandom.Int32, 100, 200);
            DoTests(GetRandom.Int32, -200, 100);
            DoTests(GetRandom.Int32, -400, -200);
            DoTests(GetRandom.Int32, int.MinValue, int.MinValue + 200);
            DoTests(GetRandom.Int32, int.MaxValue - 100, int.MaxValue);
            DoTests(GetRandom.Int32, int.MinValue, int.MaxValue);
        }

        [TestMethod] public void Int64Test() {
            var d = 100000000L;
            DoTests(GetRandom.Int64, (long) 100, 200);
            DoTests(GetRandom.Int64, (long) -200, 100);
            DoTests(GetRandom.Int64, (long) -400, -200);
            DoTests(GetRandom.Int64, long.MinValue, long.MaxValue);
            DoTests(GetRandom.Int64, long.MinValue, long.MinValue + d);
            DoTests(GetRandom.Int64, long.MaxValue - d, long.MaxValue);
        }

        [TestMethod] public void StringTest() {
            DoTests(() => GetRandom.String());
        }

        [TestMethod] public void TimeSpanTest() {
            DoTests(GetRandom.TimeSpan);
        }

        [TestMethod] public void UInt8Test() {
            DoTests(GetRandom.UInt8, (byte) 10, (byte) 110);
            DoTests(GetRandom.UInt8, byte.MinValue, (byte) (byte.MinValue + 100));
            DoTests(GetRandom.UInt8, (byte) (byte.MaxValue - 100), byte.MaxValue);
            DoTests(GetRandom.UInt8, byte.MinValue, byte.MaxValue);
        }

        [TestMethod] public void UInt16Test() {
            DoTests(GetRandom.UInt16, (ushort) 100, (ushort) 200);
            DoTests(GetRandom.UInt16, ushort.MinValue, (ushort) (ushort.MinValue + 200));
            DoTests(GetRandom.UInt16, (ushort) (ushort.MaxValue - 100), ushort.MaxValue);
            DoTests(GetRandom.UInt16, ushort.MinValue, ushort.MaxValue);
        }

        [TestMethod] public void UInt32Test() {
            DoTests(GetRandom.UInt32, (uint) 100, (uint) 200);
            DoTests(GetRandom.UInt32, uint.MinValue, uint.MinValue + 200);
            DoTests(GetRandom.UInt32, uint.MaxValue - 100, uint.MaxValue);
            DoTests(GetRandom.UInt32, uint.MinValue, uint.MaxValue);
        }

        [TestMethod] public void UInt64Test() {
            var d = 100000000UL;
            DoTests(GetRandom.UInt64, (ulong) 100, (ulong) 200);
            DoTests(GetRandom.UInt64, ulong.MinValue, ulong.MaxValue);
            DoTests(GetRandom.UInt64, ulong.MinValue, ulong.MinValue + d);
            DoTests(GetRandom.UInt64, ulong.MaxValue - d, ulong.MaxValue);
        }

        [TestMethod] public void ArrayTest() {
            static void Test(Type x, Type y = null) => Assert.IsInstanceOfType(GetRandom.Array(x), y);
            Test(typeof(bool), typeof(bool[]));
            Test(typeof(char), typeof(char[]));
            Test(typeof(Color), typeof(Color[]));
            Test(typeof(int), typeof(int[]));
        }

        [TestMethod] public void ValueTest() {
            static void Test(Type x, Type y = null) {
                Assert.IsInstanceOfType(GetRandom.Value(x), y ?? x);

                if (y is null) return;
                Assert.IsInstanceOfType(GetRandom.Value(y), y);
            }

            Test(typeof(bool?), typeof(bool));
            Test(typeof(char?), typeof(char));
            Test(typeof(Color?), typeof(Color));
            Test(typeof(DateTime?), typeof(DateTime));
            Test(typeof(decimal?), typeof(decimal));
            Test(typeof(double?), typeof(double));
            Test(typeof(float?), typeof(float));
            Test(typeof(sbyte?), typeof(sbyte));
            Test(typeof(short?), typeof(short));
            Test(typeof(int?), typeof(int));
            Test(typeof(long?), typeof(long));
            Test(typeof(TimeSpan?), typeof(TimeSpan));
            Test(typeof(byte?), typeof(byte));
            Test(typeof(ushort?), typeof(ushort));
            Test(typeof(uint?), typeof(uint));
            Test(typeof(ulong?), typeof(ulong));
            Test(typeof(string));
            Test(typeof(object));
            Test(typeof(TrainingData));
        }

        [TestMethod] public void ObjectTest() {
            Assert.IsNull(GetRandom.Object(null));
            var o = GetRandom.Object(typeof(TrainingData)) as TrainingData;
            Assert.IsNotNull(o);
            Assert.IsFalse(string.IsNullOrWhiteSpace(o.Id));
            Assert.IsFalse(string.IsNullOrWhiteSpace(o.Code));
            var l = GetRandom.Object(typeof(List<int>)) as List<int>;
            Assert.IsNotNull(l);
            Assert.IsTrue(l.Count > 0);
        }

        private static void DoTests<T>(Func<T, T, T> f, T min, T max)
            where T : IComparable {
            TestBorder(f, min);
            TestBorder(f, max);
            TestBetweenBorders(f, min, max);
            TestBetweenBorders((x, y) => f(max, min), min, max);
        }

        private static void TestBorder<T>(Func<T, T, T> f, T x) => Assert.AreEqual(x, f(x, x));

        private static void TestBetweenBorders<T>(Func<T, T, T> f, T min, T max) where T : IComparable {
            var l = new List<T>();

            for (var i = 0; i < 10; i++) {
                T r;

                do { r = f(min, max); } while (l.Contains(r));

                Assert.IsInstanceOfType(r, typeof(T));
                Assert.IsTrue(r.CompareTo(min) >= 0, $"{r} !>= {min}");
                Assert.IsTrue(r.CompareTo(max) <= 0, $"{r} !<= {min}");
                l.Add(r);
            }
        }

        private static void DoTests<T>(Func<T> f) {
            var l = new List<T>();

            for (var i = 0; i < 10; i++) {
                T r;

                do { r = f(); } while (l.Contains(r));

                Assert.IsInstanceOfType(r, typeof(T));
                l.Add(r);
            }
        }
    }
}
