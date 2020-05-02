using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids.Extensions;
using TrainingApp.Aids.Random;

namespace TrainingApp.Tests.Aids.Extensions {

    [TestClass]
    public class VariableTests : BaseTests {

        [TestInitialize] public virtual void TestInitialize() => type = typeof(Variable);

        [TestMethod] public void ToStringTest() {
            static void test<T>(T x) {
                var expected = x.ToString();
                var actual = Variable.ToString(x);
                Assert.AreEqual(expected, actual);
            }

            test(GetRandom.Int32());
            test(GetRandom.Decimal());
            test(GetRandom.UInt32());
            test(GetRandom.Bool());
            test(GetRandom.Double(-1000000000, 100000000000));
            test(GetRandom.DateTime(DateTime.Now.AddYears(-10), DateTime.Now.AddYears(10)).Date);
            Assert.AreEqual(string.Empty, Variable.ToString((int?)null));
            Assert.AreEqual(string.Empty, Variable.ToString((decimal?)null));
            Assert.AreEqual(string.Empty, Variable.ToString((double?)null));
            Assert.AreEqual(string.Empty, Variable.ToString((DateTime?)null));

        }

        [TestMethod] public void TryParseTest() {
            static void test<T>(T x) {
                var s = x.ToString();
                var actual = Variable.TryParse<T>(s);
                Assert.AreEqual(x, actual);
            }

            test(GetRandom.Int32());
            test(GetRandom.Decimal());
            test(GetRandom.UInt32());
            test(GetRandom.Bool());
            test(GetRandom.Double(-1000000000, 100000000000));
            test(GetRandom.DateTime(DateTime.Now.AddYears(-10), DateTime.Now.AddYears(10)).Date);
            Assert.AreEqual(0, Variable.TryParse<int>((string)null));
            Assert.AreEqual(0D, Variable.TryParse<double>((string)null));
            Assert.AreEqual(0M, Variable.TryParse<decimal>((string)null));
            Assert.AreEqual(DateTime.MinValue, Variable.TryParse<DateTime>((string)null));
        }

    }

}
