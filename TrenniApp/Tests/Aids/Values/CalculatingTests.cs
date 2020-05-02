using System;
using Abc.Aids.Constants;
using Abc.Aids.Extensions;
using Abc.Aids.Random;
using Abc.Aids.Values;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Aids.Values {

    [TestClass] public class CalculatingTests : BaseTests {

        private object o1;
        private object o2;
        private DateTime dt1;
        private DateTime dt2;
        private object do1;
        private object do2;
        private object i1;
        private object i2;
        private string s1;
        private string s2;
        private bool b1;
        private bool b2;
        private decimal de1;
        private decimal de2;
        private TimeSpan ts1;
        private TimeSpan ts2;

        [TestInitialize] public void TestInitialize() {
            type = typeof(Calculating);
            o1 = GetRandom.AnyValue();
            o2 = GetRandom.AnyValue();
            while (o1.ToString() == o2.ToString()) o2 = GetRandom.AnyValue();
            dt1 = GetRandom.DateTime(DateTime.Now.AddYears(-100), DateTime.Now).AddYears(100);
            dt2 = GetRandom.DateTime(dt1, dt1.AddYears(100));
            ts1 = GetRandom.TimeSpan();
            ts2 = GetRandom.TimeSpan();
            do1 = GetRandom.Double(-1000000, 1000000);
            do2 = GetRandom.Double(-1000000, 1000000);
            i1 = GetRandom.AnyInt();
            i2 = GetRandom.AnyInt();
            s1 = GetRandom.String();
            s2 = GetRandom.String();
            b1 = GetRandom.Bool();
            b2 = GetRandom.Bool();
            de1 = GetRandom.Decimal(-1000000, 1000000);
            de2 = GetRandom.Decimal(-1000000, 1000000);
        }

        [TestMethod]
        public void AddDaysTest()
        {
            Assert.IsNull(Calculating.AddDays(o1, o1));
            do1 = GetRandom.Double(-10000, 10000);
            var result = Calculating.AddDays(dt1, do1);
            Assert.IsNotNull(result);
            var d = Doubles.ToDouble(do1);
            Assert.AreEqual(result, dt1.AddDaysSafe(d));
            Assert.AreEqual(result, dt1.AddDays(d));
        }
        [TestMethod] public void AddTest() {
            AddBooleansTests();
            AddStringsTests();
            AddDatesTests();
            AddDoublesTests();
            AddDecimalsTests();
            AddObjectsTests();
        }

        [TestMethod] public void AddStringsTests() {
            static void test(string sum, string x, string y) {
                Assert.AreEqual(Calculating.Add(x, y), Strings.Add(x, y));
                Assert.AreEqual(sum, Strings.Add(x, y));
            }

            test(string.Empty, string.Empty, string.Empty);
            test("AB", "A", "B");
            test("   ", " ", "  ");
            test(s1 + s2, s1, s2);
        }

        [TestMethod] public void AddDatesTests() {
            Assert.AreEqual(Calculating.Add(dt1, dt2),
                dt1.AddSafe(dt2));
        }

        [TestMethod] public void AddBooleansTests() {
            Assert.AreEqual(Calculating.Add(b1, b2), b1.Add(b2));
        }

        [TestMethod] public void AddDoublesTests() {
            var d1 = Doubles.ToDouble(do1);
            var d2 = Doubles.ToDouble(do2);
            var r = Calculating.Add(do1, do2);
            Assert.AreEqual(r, d1.Add(d2));
            Assert.AreEqual(r, d1 + d2);
        }

        [TestMethod] public void AddDecimalsTests() {
            var r = Calculating.Add(de1, de2);
            Assert.AreEqual(r, de1.Add(de2));
            Assert.AreEqual(r, de1 + de2);
        }

        [TestMethod] public void AddObjectsTests() {
            var r = Calculating.Add(o1, new object());
            Assert.IsNull(r);
        }

        [TestMethod] public void AndTest() {
            testAllNotBothBooleanIsNull(Calculating.And);
            Assert.AreEqual(Calculating.And(b1, b2), b1.And(b2));
            Assert.AreEqual(true, Calculating.And(true, true));
            Assert.AreEqual(false, Calculating.And(false, true));
            Assert.AreEqual(false, Calculating.And(true, false));
            Assert.AreEqual(false, Calculating.And(false, false));
        }

        private void testAllNotBooleanIsNull(Func<object, object> function) {
            Assert.IsNull(function(do1));
            Assert.IsNull(function(dt1));
            Assert.IsNull(function(ts1));
            Assert.IsNull(function(null));
            Assert.IsNull(function(i1));
            while (IsType.Bool(o1)) o1 = GetRandom.AnyValue();
            Assert.IsNull(function(o1));
            Assert.IsNotNull(function(b1));
        }

        private void testAnyOtherIsNull(Func<object, object, object> function, object o) {
            Assert.IsNull(function(do1, o));
            Assert.IsNull(function(dt1, o));
            Assert.IsNull(function(ts1, o));
            Assert.IsNull(function(null, o));
            Assert.IsNull(function(i1, o));
            Assert.IsNull(function(o1, o));
            Assert.IsNull(function(b1, o));
            Assert.IsNull(function(o, do1));
            Assert.IsNull(function(o, dt1));
            Assert.IsNull(function(o, ts1));
            Assert.IsNull(function(o, null));
            Assert.IsNull(function(o, i1));
            Assert.IsNull(function(o, o1));
            Assert.IsNull(function(o, b1));
        }

        private static void testAnyIsNull(Func<object, object> function, object o) => Assert.IsNull(function(o));

        private void testAllNotBothBooleanIsNull(Func<object, object, object> function) {
            Assert.IsNull(function(do1, do2));
            Assert.IsNull(function(dt1, dt2));
            Assert.IsNull(function(ts1, ts2));
            Assert.IsNull(function(null, null));
            Assert.IsNull(function(i1, i2));
            Assert.IsNull(function(do1, b2));
            Assert.IsNull(function(dt1, b2));
            Assert.IsNull(function(ts1, b2));
            Assert.IsNull(function(null, null));
            Assert.IsNull(function(i1, b2));
            while (IsType.Bool(o1)) o1 = GetRandom.AnyValue();
            Assert.IsNull(function(o1, o2));
            Assert.IsNull(function(o1, b2));
            Assert.IsNotNull(function(b1, b2));
        }

        [TestMethod] public void MultiplyTest() {
            testAnyOtherIsNull(Calculating.Multiply, dt1);
            testAnyOtherIsNull(Calculating.Multiply, s1);
            Assert.AreEqual(10.0, Calculating.Multiply(5.0, 2));
            Assert.AreEqual(10M, Calculating.Multiply(5M, 2));
            var d1 = Doubles.ToDouble(do1);
            var d2 = Doubles.ToDouble(do2);
            var r = Calculating.Multiply(do1, do2);
            Assert.AreEqual(r, d1.Multiply(d2));
            Assert.AreEqual(r, d1 * d2);
            var m1 = Converting.ToDecimal(de1);
            var m2 = Converting.ToDecimal(de2);
            r = Calculating.Multiply(de1, de2);
            Assert.AreEqual(r, m1.Multiply(m2));
            Assert.AreEqual(r, m1 * m2);
            Assert.AreEqual(true, Calculating.Multiply(true, true));
            Assert.AreEqual(false, Calculating.Multiply(false, false));
            Assert.AreEqual(false, Calculating.Multiply(true, false));
            Assert.AreEqual(false, Calculating.Multiply(false, true));
        }

        [TestMethod] public void SubtractTest() {
            testAnyOtherIsNull(Calculating.Subtract, b1);
            testAnyOtherIsNull(Calculating.Subtract, s1);
            Assert.AreEqual(3.0, Calculating.Subtract(5.0, 2));
            Assert.AreEqual(3M, Calculating.Subtract(5M, 2));
            var d1 = Doubles.ToDouble(do1);
            var d2 = Doubles.ToDouble(do2);
            var r = Calculating.Subtract(do1, do2);
            Assert.AreEqual(r, d1.Subtract(d2));
            Assert.AreEqual(r, d1 - d2);
            var m1 = Converting.ToDecimal(de1);
            var m2 = Converting.ToDecimal(de2);
            r = Calculating.Subtract(de1, de2);
            Assert.AreEqual(r, m1.Subtract(m2));
            Assert.AreEqual(r, m1 - m2);
            r = Calculating.Subtract(dt2, dt1);
            Assert.AreEqual(r, dt2.SubtractSafe(dt1));
            Assert.AreEqual(r, dt2.Subtract(TimeSpan.FromTicks(dt1.Ticks)));
        }

        [TestMethod] public void OrTest() {
            testAllNotBothBooleanIsNull(Calculating.Or);
            Assert.AreEqual(Calculating.Or(b1, b2), b1.Or(b2));
            Assert.AreEqual(true, Calculating.Or(true, true));
            Assert.AreEqual(true, Calculating.Or(false, true));
            Assert.AreEqual(true, Calculating.Or(true, false));
            Assert.AreEqual(false, Calculating.Or(false, false));
        }

        [TestMethod] public void XorTest() {
            testAllNotBothBooleanIsNull(Calculating.Xor);
            Assert.AreEqual(Calculating.Xor(b1, b2), b1.Xor(b2));
            Assert.AreEqual(false, Calculating.Xor(true, true));
            Assert.AreEqual(true, Calculating.Xor(false, true));
            Assert.AreEqual(true, Calculating.Xor(true, false));
            Assert.AreEqual(false, Calculating.Xor(false, false));
        }

        [TestMethod] public void NotTest() {
            testAllNotBooleanIsNull(Calculating.Not);
            Assert.AreEqual(Calculating.Not(b1), b1.Not());
            Assert.AreEqual(false, Calculating.Not(true));
            Assert.AreEqual(true, Calculating.Not(false));
        }

        [TestMethod] public void IsEqualTest() {
            Assert.AreEqual(Calculating.IsEqual(dt1, dt2),
                dt1.IsEqual(dt2));
            Assert.AreEqual(Calculating.IsEqual(do1, do2),
                Doubles.ToDouble(do1).IsEqual(Doubles.ToDouble(do2)));
            Assert.AreEqual(Calculating.IsEqual(de1, de2),
                de1.IsEqual(de2));
            Assert.IsNull(Calculating.IsEqual(b1, s1));
        }

        [TestMethod] public void IsGreaterTest() {
            Assert.AreEqual(Calculating.IsGreater(b1, b2), b1.IsGreater(b2));
            Assert.AreEqual(Calculating.IsGreater(s1, s2),
                s1.IsGreater(s2));
            Assert.AreEqual(Calculating.IsGreater(dt1, dt2),
                dt1.IsGreater(dt2));
            Assert.AreEqual(Calculating.IsGreater(do1, do2),
                Doubles.ToDouble(do1).IsGreater(Doubles.ToDouble(do2)));
            Assert.AreEqual(Calculating.IsGreater(de1, de2),
                de1.IsGreater(de2));
            Assert.IsNull(Calculating.IsGreater(b1, s1));
            Assert.IsNull(Calculating.IsGreater(s1, b1));
            Assert.IsNull(Calculating.IsGreater(dt1, s1));
            Assert.IsNull(Calculating.IsGreater(do1, s1));
            Assert.IsNull(Calculating.IsGreater(de1, s1));
        }

        [TestMethod] public void IsLessTest() {
            Assert.AreEqual(Calculating.IsLess(b1, b2), b1.IsLess(b2));
            Assert.AreEqual(Calculating.IsLess(s1, s2),
                s1.IsLess(s2));
            Assert.AreEqual(Calculating.IsLess(dt1, dt2),
                dt1.IsLess(dt2));
            Assert.AreEqual(Calculating.IsLess(do1, do2),
                Doubles.ToDouble(do1).IsLess(Doubles.ToDouble(do2)));
            Assert.AreEqual(Calculating.IsLess(de1, de2),
                de1.IsLess(de2));
            Assert.IsNull(Calculating.IsLess(b1, s1));
            Assert.IsNull(Calculating.IsLess(s1, b1));
            Assert.IsNull(Calculating.IsLess(dt1, s1));
            Assert.IsNull(Calculating.IsLess(do1, s1));
            Assert.IsNull(Calculating.IsLess(de1, s1));
        }

        [TestMethod] public void GetSecondTest() {
            Assert.IsNull(Calculating.GetSecond(do1));
            Assert.IsNull(Calculating.GetSecond(s1));
            Assert.IsNull(Calculating.GetSecond(b1));
            var result = Calculating.GetSecond(dt1);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, dt1.GetSecond());
            Assert.AreEqual(result, dt1.Second);
            result = Calculating.GetSecond(ts1);
            Assert.AreEqual(result, ts1.Seconds);
        }

        [TestMethod] public void GetMinuteTest() {
            Assert.IsNull(Calculating.GetMinute(do1));
            Assert.IsNull(Calculating.GetMinute(s1));
            Assert.IsNull(Calculating.GetMinute(b1));
            var result = Calculating.GetMinute(dt1);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, dt1.GetMinute());
            Assert.AreEqual(result, dt1.Minute);
            result = Calculating.GetMinute(ts1);
            Assert.AreEqual(result, ts1.Minutes);
        }

        [TestMethod] public void GetHourTest() {
            Assert.IsNull(Calculating.GetHour(do1));
            Assert.IsNull(Calculating.GetHour(s1));
            Assert.IsNull(Calculating.GetHour(b1));
            var result = Calculating.GetHour(dt1);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, dt1.GetHour());
            Assert.AreEqual(result, dt1.Hour);
            result = Calculating.GetHour(ts1);
            Assert.AreEqual(result, ts1.Hours);
        }

        [TestMethod] public void GetDayTest() {
            Assert.IsNull(Calculating.GetDay(do1));
            Assert.IsNull(Calculating.GetDay(s1));
            Assert.IsNull(Calculating.GetDay(b1));
            var result = Calculating.GetDay(dt1);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, dt1.GetDay());
            Assert.AreEqual(result, dt1.Day);
            result = Calculating.GetDay(ts1);
            Assert.AreEqual(result, ts1.Days);
        }

        [TestMethod] public void GetMonthTest() {
            Assert.IsNull(Calculating.GetMonth(do1));
            Assert.IsNull(Calculating.GetMonth(s1));
            Assert.IsNull(Calculating.GetMonth(b1));
            var result = Calculating.GetMonth(dt1);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, dt1.GetMonth());
            Assert.AreEqual(result, dt1.Month);
        }

        [TestMethod] public void GetYearTest() {
            Assert.IsNull(Calculating.GetYear(do1));
            Assert.IsNull(Calculating.GetYear(s1));
            Assert.IsNull(Calculating.GetYear(b1));
            var result = Calculating.GetYear(dt1);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, dt1.GetYear());
            Assert.AreEqual(result, dt1.Year);
        }

        [TestMethod]
        public void AddSecondsTest()
        {
            Assert.IsNull(Calculating.AddSeconds(o1, o1));
            var result = Calculating.AddSeconds(dt1, do1);
            Assert.IsNotNull(result);
            var d = Doubles.ToDouble(do1);
            Assert.AreEqual(result, dt1.AddSecondsSafe(d));
            Assert.AreEqual(result, dt1.AddSeconds(d));
        }
        [TestMethod]
        public void AddMinutesTest()
        {
            Assert.IsNull(Calculating.AddMinutes(o1, o1));
            var result = Calculating.AddMinutes(dt1, do1);
            Assert.IsNotNull(result);
            var d = Doubles.ToDouble(do1);
            Assert.AreEqual(result, dt1.AddMinutesSafe(d));
            Assert.AreEqual(result, dt1.AddMinutes(d));
        }
        [TestMethod]
        public void AddHoursTest()
        {
            Assert.IsNull(Calculating.AddHours(o1, o1));
            var result = Calculating.AddHours(dt1, i1);
            Assert.IsNotNull(result);
            var d = Doubles.ToDouble(i1);
            Assert.AreEqual(result, dt1.AddHoursSafe(d));
            Assert.AreEqual(result, dt1.AddHours(d));
        }
        [TestMethod]
        public void AddMonthsTest()
        {
            Assert.IsNull(Calculating.AddMonths(o1, o1));
            var result = Calculating.AddMonths(dt1, i1);
            Assert.IsNotNull(result);
            var i = Integers.ToInteger(i1);
            Assert.AreEqual(result, dt1.AddMonthsSafe(i));
            Assert.AreEqual(result, dt1.AddMonths(i));
        }
        [TestMethod]
        public void AddYearsTest()
        {
            Assert.IsNull(Calculating.AddYears(o1, o1));
            var result = Calculating.AddYears(dt1, i1);
            Assert.IsNotNull(result);
            var i = Integers.ToInteger(i1);
            Assert.AreEqual(result, dt1.AddYearsSafe(i));
            Assert.AreEqual(result, dt1.AddYears(i));
        }
        [TestMethod] public void GetIntervalTest() {
            Assert.IsNull(Calculating.GetInterval(s1, dt1));
            Assert.IsNull(Calculating.GetInterval(b1, dt1));
            Assert.IsNull(Calculating.GetInterval(do1, dt1));
            Assert.IsNull(Calculating.GetInterval(null, dt1));
            var result = dt1.GetInterval(dt2).Ticks;
            Assert.AreEqual(result, Calculating.GetInterval(dt1, dt2));
            Assert.AreEqual(result, dt1.Subtract(dt2).Ticks);
        }

        [TestMethod] public void GetAgeTest() {
            Assert.IsNull(Calculating.GetAge(s1));
            Assert.IsNull(Calculating.GetAge(b1));
            Assert.IsNull(Calculating.GetAge(do1));
            Assert.IsNull(Calculating.GetAge(null));
            var age = GetRandom.Int32(10, 100);
            Assert.AreEqual(age, Calculating.GetAge(DateTime.Now.AddYears(-age)));
        }

        [TestMethod] public void ToSecondsTest() => testToTotalTime(Calculating.ToSeconds, ts1.TotalSeconds);
        [TestMethod] public void ToMinutesTest() => testToTotalTime(Calculating.ToMinutes, ts1.TotalMinutes);
        [TestMethod] public void ToHoursTest() => testToTotalTime(Calculating.ToHours, ts1.TotalHours);
        [TestMethod] public void ToDaysTest() => testToTotalTime(Calculating.ToDays, ts1.TotalDays);
        [TestMethod] public void ToMonthsTest() => testToTotalTime(Calculating.ToMonths, ts1.TotalDays/Astronomical.DaysPerMonth);
        [TestMethod] public void ToYearsTest() => testToTotalTime(Calculating.ToYears, ts1.TotalDays/Astronomical.DaysPerYear);

        private void testToTotalTime(Func<object, object> f, double expected) {
            Assert.IsNull(f(s1));
            Assert.IsNull(f(b1));
            Assert.IsNull(f(do1));
            Assert.IsNull(f(null));
            Assert.AreEqual(expected, f(ts1));
        }

        [TestMethod] public void GetLengthTest() {
            testAllNotStringIsNull(Calculating.GetLength);
            Assert.AreEqual(s1.Length, Calculating.GetLength(s1));
        }
        [TestMethod]
        public void ToUpperTest()
        {
            testAllNotStringIsNull(Calculating.ToUpper);
            Assert.AreEqual(s1.ToUpper(), Calculating.ToUpper(s1));
        }
        [TestMethod]
        public void ToLowerTest()
        {
            testAllNotStringIsNull(Calculating.ToLower);
            Assert.AreEqual(s1.ToLower(), Calculating.ToLower(s1));
        }
        private void testAllNotStringIsNull(Func<object, object> f) {
            Assert.IsNull(f(b1));
            Assert.IsNull(f(do1));
            Assert.IsNull(f(dt1));
            Assert.IsNull(f(ts1));
            Assert.IsNull(f(null));
            Assert.IsNull(f(i1));
            while (IsType.String(o1)) o1 = GetRandom.AnyValue();
            Assert.IsNull(f(o1));
            Assert.IsNotNull(f(s2));
        }
        [TestMethod]
        public void TrimTest()
        {
            testAllNotStringIsNull(Calculating.Trim);
            Assert.AreEqual(s1, Calculating.Trim("   " + s1 + "         "));
        }
        [TestMethod]
        public void SubstringTest()
        {
            Assert.IsNull(Calculating.Substring(i1, i2));
            Assert.IsNull(Calculating.Substring(do1, do2));
            Assert.IsNull(Calculating.Substring(null, null));
            Assert.IsNull(Calculating.Substring(string.Empty, string.Empty));
            var length = (byte)((s1.Length - 1) / 2);
            var len = GetRandom.UInt8(1, length);
            var idx = GetRandom.UInt8(len, length);
            Assert.AreEqual(s1.Substring(idx), Calculating.Substring(s1, idx));
            Assert.AreEqual(s1.Substring(idx, len),
                Calculating.Substring(s1, idx, len));
        }
        [TestMethod]
        public void ContainsTest()
        {
            Assert.IsNull(Calculating.Contains(i1, i2));
            Assert.IsNull(Calculating.Contains(do1, do2));
            Assert.IsNull(Calculating.Contains(null, null));
            Assert.AreEqual(false, Calculating.Contains(string.Empty, string.Empty));
            var length = (byte)((s1.Length - 1) / 2);
            var len = GetRandom.UInt8(1, length);
            var idx = GetRandom.UInt8(len, length);
            var x = s1.Substring(idx, len);
            Assert.AreEqual(true,
                Calculating.Contains(s1, x), $"string:{s1} substring:{x} idx:{idx} len:{len}");
        }
        [TestMethod]
        public void EndsWithTest()
        {
            Assert.IsNull(Calculating.EndsWith(i1, i2));
            Assert.IsNull(Calculating.EndsWith(do1, do2));
            Assert.IsNull(Calculating.EndsWith(null, null));
            Assert.AreEqual(false, Calculating.EndsWith(string.Empty, string.Empty));
            var length = (byte)((s1.Length - 1) / 2);
            var len = GetRandom.UInt8(1, length);
            var idx = GetRandom.UInt8(len, length);
            Assert.AreEqual(true, Calculating.EndsWith(s1, s1.Substring(idx)));
        }
        [TestMethod]
        public void StartsWithTest()
        {
            Assert.IsNull(Calculating.StartsWith(11, 12));
            Assert.IsNull(Calculating.StartsWith(do1, do2));
            Assert.IsNull(Calculating.StartsWith(null, null));
            Assert.AreEqual(false, Calculating.StartsWith(string.Empty, string.Empty));
            var length = (byte)((s1.Length - 1) / 2);
            var len = GetRandom.UInt8(length, (byte)s1.Length);
            Assert.AreEqual(true,
                Calculating.StartsWith(s1, s1.Substring(0, len)));
        }
        [TestMethod] public void DivideTest() {
            Assert.IsNull(Calculating.Divide(s1, s2));
            Assert.IsNull(Calculating.Divide(dt1, dt2));
            Assert.IsNull(Calculating.Divide(b1, b2));
            Assert.AreEqual(5.0M, Calculating.Divide(10, 2));
            Assert.AreEqual(5M, Calculating.Divide(10M, 2));
            var d1 = Doubles.ToDouble(do1);
            var d2 = Doubles.ToDouble(do2);
            Assert.AreEqual(d1 / d2, Calculating.Divide(do1, do2));
        }

        [TestMethod] public void PowerTest() {
            testAnyOtherIsNull(Calculating.Power, b1);
            testAnyOtherIsNull(Calculating.Power, dt1);
            testAnyOtherIsNull(Calculating.Power, s1);
            Assert.AreEqual(25.0, Calculating.Power(5.0, 2.0));
            var d1 = Doubles.ToDouble(do1);
            var d2 = Doubles.ToDouble(do2);
            Assert.AreEqual(Math.Pow(d1, d2), Calculating.Power(do1, do2));
            d1 = Doubles.ToDouble(de1);
            d2 = Doubles.ToDouble(de2);
            Assert.AreEqual(Math.Pow(d1, d2), Calculating.Power(de1, de2));
        }

        [TestMethod] public void OppositeTest() {
            testAnyIsNull(Calculating.Opposite, b1);
            testAnyIsNull(Calculating.Opposite, dt1);
            testAnyIsNull(Calculating.Opposite, s1);
            Assert.AreEqual(-5.0, Calculating.Opposite(5.0));
            Assert.AreEqual(-5M, Calculating.Opposite(5M));
            Assert.AreEqual(-Doubles.ToDouble(do1),
                Calculating.Opposite(do1));
            Assert.AreEqual(-Converting.ToDecimal(de1),
                Calculating.Opposite(de1));
        }

        [TestMethod] public void InverseTest() {
            testAnyIsNull(Calculating.Inverse, b1);
            testAnyIsNull(Calculating.Inverse, dt1);
            testAnyIsNull(Calculating.Inverse, s1);
            Assert.AreEqual(1.0 / 5.0, Calculating.Inverse(5.0));
            Assert.AreEqual(1M / 5M, Calculating.Inverse(5M));
            Assert.AreEqual(1.0 / Doubles.ToDouble(do1),
                Calculating.Inverse(do1));
            Assert.AreEqual(1M / Converting.ToDecimal(de1),
                Calculating.Inverse(de1));
        }

        [TestMethod] public void SquareTest() {
            testAnyIsNull(Calculating.Square, b1);
            testAnyIsNull(Calculating.Square, dt1);
            testAnyIsNull(Calculating.Square, s1);
            Assert.AreEqual(25.0, Calculating.Square(5.0));
            Assert.AreEqual(25D, Calculating.Square(5M));
            var d = Doubles.ToDouble(do1);
            var m = Doubles.ToDouble(de1);
            Assert.AreEqual(d * d, Calculating.Square(do1));
            Assert.AreEqual(m * m, Calculating.Square(de1));
        }

        [TestMethod] public void SqrtTest() {
            testAnyIsNull(Calculating.Sqrt, b1);
            testAnyIsNull(Calculating.Sqrt, dt1);
            testAnyIsNull(Calculating.Sqrt, s1);
            Assert.AreEqual(5.0, Calculating.Sqrt(25.0));
            var d = Doubles.ToDouble(do1);
            Assert.AreEqual(Math.Sqrt(d), Calculating.Sqrt(do1));
            d = Doubles.ToDouble(de1);
            Assert.AreEqual(Math.Sqrt(d), Calculating.Sqrt(de1));
        }

    }

}
