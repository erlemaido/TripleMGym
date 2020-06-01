using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids.Methods;

namespace TrainingApp.Tests.Aids.Methods {

    [TestClass] public class SortTests : BaseTests {

        [TestInitialize] public void TestInitialize() {
            type = typeof(Sort);
        }

        [TestMethod] public void AscendingTest() {
            SortAscendingTest(DateTime.MaxValue, DateTime.MinValue);
            SortAscendingTest(double.MaxValue, double.MinValue);
            SortAscendingTest(int.MaxValue, int.MinValue);
        }

        private static void SortAscendingTest<T>(T max, T min) where T : IComparable {
            Assert.IsTrue(max.CompareTo(min) >= 0);
            Sort.Ascending(ref max, ref min);
            Assert.IsTrue(max.CompareTo(min) <= 0);
        }
    }
}
