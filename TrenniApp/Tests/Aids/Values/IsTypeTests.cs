using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids.Random;
using TrainingApp.Aids.Values;

namespace TrainingApp.Tests.Aids.Values {

    [TestClass] public class IsTypeTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(IsType);

        [TestMethod] public void AnyDecimalTest() { }

        [TestMethod] public void AnyDoubleTest() { }

        [TestMethod] public void AnyIntTest() { }

        [TestMethod] public void AnyLongTest() { }

        [TestMethod] public void TimeSpanTest() => test(GetRandom.TimeSpan(), typeof(TimeSpan));

        [TestMethod] public void DateTimeTest() => test(GetRandom.DateTime(), typeof(DateTime));

        [TestMethod] public void StringTest() => test(GetRandom.String(), typeof(string));

        [TestMethod] public void BoolTest() => test(GetRandom.Bool(), typeof(bool));

        [TestMethod] public void LongTest() => test(GetRandom.Int64(), typeof(long));

        [TestMethod] public void IntTest() => test(GetRandom.Int32(), typeof(int));

        [TestMethod] public void ShortTest() => test(GetRandom.Int16(), typeof(short));

        [TestMethod] public void SByteTest() => test(GetRandom.Int8(), typeof(sbyte));

        [TestMethod] public void ULongTest() => test(GetRandom.UInt64(), typeof(ulong));

        [TestMethod] public void UIntTest() => test(GetRandom.UInt32(), typeof(uint));

        [TestMethod] public void UShortTest() => test(GetRandom.UInt16(), typeof(ushort));

        [TestMethod] public void ByteTest() => test(GetRandom.UInt8(), typeof(byte));

        [TestMethod] public void FloatTest() => test(GetRandom.Float(), typeof(float));

        [TestMethod] public void DoubleTest() => test(GetRandom.Double(), typeof(double));

        [TestMethod] public void DecimalTest() => test(GetRandom.Decimal(), typeof(decimal));

        [TestMethod] public void NullTest() {
            Assert.AreEqual(true, IsType.Null(null));
            Assert.AreEqual(false, IsType.Null(GetRandom.AnyValue()));
        }

        private static void test(object x, Type t) {
            testType(x, t);
            testAnyInt(x, t);
            testAnyLong(x, t);
            testAnyDouble(x, t);
            testAnyDecimal(x, t);
        }

        private static void testAnyDouble(object x, Type t) {
            var expected = isAnyDouble(t);
            Assert.AreEqual(expected, IsType.AnyDouble(x));
        }

        private static void testAnyDecimal(object x, Type t) {
            var expected = isAnyDecimal(t);
            Assert.AreEqual(expected, IsType.AnyDecimal(x));
        }

        private static void testAnyLong(object x, Type t) {
            var expected = isAnyLong(t);
            Assert.AreEqual(expected, IsType.AnyLong(x));
        }

        private static void testAnyInt(object x, Type t) {
            var expected = isAnyInt(t);
            Assert.AreEqual(expected, IsType.AnyInt(x));
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

        private static void testType(object x, Type t) {
            Assert.AreEqual(t == typeof(DateTime), IsType.DateTime(x));
            Assert.AreEqual(t == typeof(bool), IsType.Bool(x));
            Assert.AreEqual(t == typeof(string), IsType.String(x));
            Assert.AreEqual(t == typeof(TimeSpan), IsType.TimeSpan(x));
            Assert.AreEqual(t == typeof(decimal), IsType.Decimal(x));
            Assert.AreEqual(t == typeof(double), IsType.Double(x));
            Assert.AreEqual(t == typeof(float), IsType.Float(x));
            Assert.AreEqual(t == typeof(sbyte), IsType.SByte(x));
            Assert.AreEqual(t == typeof(short), IsType.Short(x));
            Assert.AreEqual(t == typeof(int), IsType.Int(x));
            Assert.AreEqual(t == typeof(long), IsType.Long(x));
            Assert.AreEqual(t == typeof(byte), IsType.Byte(x));
            Assert.AreEqual(t == typeof(ushort), IsType.UShort(x));
            Assert.AreEqual(t == typeof(uint), IsType.UInt(x));
            Assert.AreEqual(t == typeof(ulong), IsType.ULong(x));
        }

    }

}