using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids.Extensions;

namespace TrainingApp.Tests.Aids.Extensions {

    [TestClass] public class ListsTests : BaseTests {

        private List<int> list;

        [TestInitialize] public void TestInitialize() {
            type = typeof(Lists);
            list = new List<int> {1, 3, 2, 4, 1, 6};
        }

        [TestMethod] public void OrderByTest() {
            list = Lists.OrderBy(list, x => x.ToString()).ToList();
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(1, list[1]);
            Assert.AreEqual(2, list[2]);
            Assert.AreEqual(3, list[3]);
            Assert.AreEqual(4, list[4]);
            Assert.AreEqual(6, list[5]);
        }

        [TestMethod] public void DistinctTest() {
            list = Lists.Distinct(list).ToList();
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(3, list[1]);
            Assert.AreEqual(2, list[2]);
            Assert.AreEqual(4, list[3]);
            Assert.AreEqual(6, list[4]);
        }

        [TestMethod] public void ConvertTest() {
            var l = Lists.Convert(list, x => x.ToString()).ToList();
            Assert.AreEqual(6, l.Count);
            Assert.AreEqual("1", l[0]);
            Assert.AreEqual("3", l[1]);
            Assert.AreEqual("2", l[2]);
            Assert.AreEqual("4", l[3]);
            Assert.AreEqual("1", l[4]);
            Assert.AreEqual("6", l[5]);
        }

        [TestMethod] public void OrderByWithNullsTest() {
            Assert.AreEqual(0, Lists.OrderBy(list, null).Count());
            Assert.AreEqual(0, Lists.OrderBy<int>(null, x => x.ToString()).Count());
            Assert.AreEqual(0, Lists.OrderBy<int>(null, null).Count());
        }

        [TestMethod] public void DistinctWithNullsTest() {
            Assert.AreEqual(0, Lists.Distinct((IEnumerable<int>) null).Count());
        }

        [TestMethod] public void ConvertWithNullsTest() {
            Assert.AreEqual(0, Lists.Convert<int, string>(list, null).Count());
            Assert.AreEqual(0, Lists.Convert<int, string>(null, x => x.ToString()).Count());
            Assert.AreEqual(0, Lists.Convert<int, string>(null, null).Count());
        }

    }

}





