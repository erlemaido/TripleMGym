using System;
using Abc.Aids.Constants;
using Abc.Aids.Random;
using Abc.Aids.Regions;
using Abc.Aids.Values;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Aids.Values
{
    [TestClass]
    public class ConvertingTests : BaseTests
    {
        private decimal m;
        private TimeSpan ts;
        [TestInitialize] public void TestInitialize() {
            type = typeof(Converting);
            m = GetRandom.Decimal() / 2M;
            ts = GetRandom.TimeSpan();
        }
        [TestMethod]
        public void ToDecimalTest()
        {
            var d = GetRandom.Double(Convert.ToSingle(decimal.MinValue),
                Convert.ToSingle(decimal.MaxValue));
            var f = GetRandom.Float(Convert.ToSingle(decimal.MinValue),
                Convert.ToSingle(decimal.MaxValue));
            var l = GetRandom.Int64();
            var i = GetRandom.Int32();
            var s = GetRandom.Int16();
            var b = GetRandom.Int8();
            var ul = GetRandom.UInt64();
            var ui = GetRandom.UInt32();
            var us = GetRandom.UInt16();
            var ub = GetRandom.UInt8();
            Assert.AreEqual(m, Converting.ToDecimal(m));
            Assert.AreEqual(Convert.ToDecimal(d), Converting.ToDecimal(d));
            Assert.AreEqual(Convert.ToDecimal(f), Converting.ToDecimal(f));
            Assert.AreEqual(Convert.ToDecimal(l), Converting.ToDecimal(l));
            Assert.AreEqual(Convert.ToDecimal(i), Converting.ToDecimal(i));
            Assert.AreEqual(Convert.ToDecimal(s), Converting.ToDecimal(s));
            Assert.AreEqual(Convert.ToDecimal(b), Converting.ToDecimal(b));
            Assert.AreEqual(Convert.ToDecimal(ul), Converting.ToDecimal(ul));
            Assert.AreEqual(Convert.ToDecimal(ui), Converting.ToDecimal(ui));
            Assert.AreEqual(Convert.ToDecimal(us), Converting.ToDecimal(us));
            Assert.AreEqual(Convert.ToDecimal(ub), Converting.ToDecimal(ub));
            Assert.AreEqual(1.2345M, Converting.ToDecimal("1.2345"));
            Assert.AreEqual(1.2345M, Converting.ToDecimal(1.2345D));
            Assert.AreEqual(1.2345M, Converting.ToDecimal(1.2345F));
        }

        [TestMethod]
        public void ToStringTest()
        {
            static void action(decimal x)
            {
                Assert.AreEqual(x.ToString(UseCulture.Invariant), Converting.ToString(x));
            }

            action(GetRandom.Decimal());
            action(1234.567m);
            action(1234567m);
            action(123456.7m);
            Assert.AreEqual(m.ToString(UseCulture.English), Converting.ToString(m));
        }

        [TestMethod]
        public void TryParseTest()
        {
            static void action(decimal x, string s)
            {
                Assert.IsTrue(Converting.ToDecimal(s, out var y));
                Assert.AreEqual(x, y);
            }

            action(m, m.ToString(UseCulture.Invariant));
            action(1234.567m, "1234.567");
            action(1234567m, "1234,567");
            action(123456.7m, "1234,56.7");
        }

        [TestMethod] public void ToYearsTest() =>
            Assert.AreEqual(ts.TotalDays / Astronomical.DaysPerYear, ts.ToYears());

        [TestMethod]
        public void ToMonthsTest() => Assert.AreEqual(ts.TotalDays / Astronomical.DaysPerMonth, ts.ToMonths());

        [TestMethod]
        public void ToDaysTest() => Assert.AreEqual(ts.TotalDays, ts.ToDays());

        [TestMethod]
        public void ToHoursTest() => Assert.AreEqual(ts.TotalHours, ts.ToHours());

        [TestMethod]
        public void ToMinutesTest() => Assert.AreEqual(ts.TotalMinutes, ts.ToMinutes());

        [TestMethod]
        public void ToSecondsTest() => Assert.AreEqual(ts.TotalSeconds, ts.ToSeconds());

    }

}