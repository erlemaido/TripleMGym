using System;
using Abc.Aids.Random;
using Abc.Aids.Values;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Aids.Values {

    [TestClass] public class AreTypesTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(AreTypes);

        [TestMethod] public void AnyDecimalTest() { }

        [TestMethod] public void AnyDoubleTest() { }

        [TestMethod] public void AnyIntTest() { }

        [TestMethod] public void AnyLongTest() { }

        [TestMethod] public void TimeSpanTest() => test(GetRandom.TimeSpan);

        [TestMethod] public void DateTimeTest() => test(() => GetRandom.DateTime());

        [TestMethod] public void StringTest() => test(() => GetRandom.String());

        [TestMethod] public void BoolTest() => test(GetRandom.Bool);

        [TestMethod] public void LongTest() => test(() => GetRandom.Int64());

        [TestMethod] public void IntTest() => test(() => GetRandom.Int32());

        [TestMethod] public void ShortTest() => test(() => GetRandom.Int16());

        [TestMethod] public void SByteTest() => test(() => GetRandom.Int8());

        [TestMethod] public void ULongTest() => test(() => GetRandom.UInt64());

        [TestMethod] public void UIntTest() => test(() => GetRandom.UInt32());

        [TestMethod] public void UShortTest() => test(() => GetRandom.UInt16());

        [TestMethod] public void ByteTest() => test(() => GetRandom.UInt8());

        [TestMethod] public void FloatTest() => test(() => GetRandom.Float());

        [TestMethod] public void DoubleTest() => test(() => GetRandom.Double());

        [TestMethod] public void DecimalTest() => test(() => GetRandom.Decimal());

        [TestMethod] public void NullTest() {
            var x = GetRandom.List(GetRandom.AnyValue).ToArray();
            Assert.AreEqual(false, AreTypes.Null(x));
            x = GetRandom.List<object>(() => null).ToArray();
            Assert.AreEqual(true, AreTypes.Null(x));
        }

        private static void test<T>(Func<T> f) {
            var x = GetRandom.List(() => f() as object).ToArray();
            testType(x, typeof(T));
            testAnyInt(x, typeof(T));
            testAnyLong(x, typeof(T));
            testAnyDouble(x, typeof(T));
            testAnyDecimal(x, typeof(T));
        }

        private static void testAnyDouble(object[] x, Type t) {
            var expected = isAnyDouble(t);
            Assert.AreEqual(expected, AreTypes.AnyDouble(x));
        }

        private static void testAnyDecimal(object[] x, Type t) {
            var expected = isAnyDecimal(t);
            Assert.AreEqual(expected, AreTypes.AnyDecimal(x));
        }

        private static void testAnyLong(object[] x, Type t) {
            var expected = isAnyLong(t);
            Assert.AreEqual(expected, AreTypes.AnyLong(x));
        }

        private static void testAnyInt(object[] x, Type t) {
            var expected = isAnyInt(t);
            Assert.AreEqual(expected, AreTypes.AnyInt(x));
        }

        private static bool isAnyDouble(Type t) => t == typeof(double)
                                                   || t == typeof(float)
                                                   || isAnyDecimal(t);

        private static bool isAnyDecimal(Type t) => t == typeof(decimal)
                                                    || t == typeof(ulong)
                                                    || isAnyLong(t);

        private static bool isAnyLong(Type t) => t == typeof(long)
                                                 || t == typeof(uint)
                                                 || isAnyInt(t);

        private static bool isAnyInt(Type t) => t == typeof(byte)
                                                || t == typeof(sbyte)
                                                || t == typeof(short)
                                                || t == typeof(ushort)
                                                || t == typeof(int);

        private static void testType(object[] x, Type t) {
            Assert.AreEqual(t == typeof(DateTime), AreTypes.DateTime(x));
            Assert.AreEqual(t == typeof(bool), AreTypes.Bool(x));
            Assert.AreEqual(t == typeof(string), AreTypes.String(x));
            Assert.AreEqual(t == typeof(TimeSpan), AreTypes.TimeSpan(x));
            Assert.AreEqual(t == typeof(decimal), AreTypes.Decimal(x));
            Assert.AreEqual(t == typeof(double), AreTypes.Double(x));
            Assert.AreEqual(t == typeof(float), AreTypes.Float(x));
            Assert.AreEqual(t == typeof(sbyte), AreTypes.SByte(x));
            Assert.AreEqual(t == typeof(short), AreTypes.Short(x));
            Assert.AreEqual(t == typeof(int), AreTypes.Int(x));
            Assert.AreEqual(t == typeof(long), AreTypes.Long(x));
            Assert.AreEqual(t == typeof(byte), AreTypes.Byte(x));
            Assert.AreEqual(t == typeof(ushort), AreTypes.UShort(x));
            Assert.AreEqual(t == typeof(uint), AreTypes.UInt(x));
            Assert.AreEqual(t == typeof(ulong), AreTypes.ULong(x));
        }

    }

}