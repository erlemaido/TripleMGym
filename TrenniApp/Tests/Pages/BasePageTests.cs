using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Pages;

namespace TrainingApp.Tests.Pages {

    [TestClass]
    public class BasePageTests : AbstractPageTests<BasePage<IClientsRepository, Client, ClientView, ClientData>, PageModel> 
    {

        [TestInitialize] 
        public override void TestInitialize() 
        {
            base.TestInitialize();
            obj = new TestClass(db);
        }

        [TestMethod] 
        public void FixedValueTest() 
        {
            var s = GetRandom.String();
            obj.FixedValue = s;
            Assert.AreEqual(s, db.FixedValue);
            Assert.AreEqual(s, obj.FixedValue);
        }

        [TestMethod] 
        public void FixedFilterTest() 
        {
            var s = GetRandom.String();
            obj.FixedFilter = s;
            Assert.AreEqual(s, db.FixedFilter);
            Assert.AreEqual(s, obj.FixedFilter);
        }

        [TestMethod] 
        public void SetFixedFilterTest() 
        {
            var filter = GetRandom.String();
            var value = GetRandom.String();
            obj.SetFixedFilter(filter, value);
            Assert.AreEqual(filter, obj.FixedFilter);
            Assert.AreEqual(value, obj.FixedValue);
        }

        [TestMethod] 
        public void SortOrderTest() 
        {
            var s = GetRandom.String();
            obj.SortOrder = s;
            Assert.AreEqual(s, db.SortOrder);
            Assert.AreEqual(s, obj.SortOrder);
        }

        [TestMethod] 
        public void GetSortOrderTest() 
        {
            void Test(string sortOrder, string name, bool isDesc) 
            {
                obj.SortOrder = sortOrder;
                var actual = obj.GetSortOrder(name);
                var expected = isDesc ? name + "_desc" : name;
                Assert.AreEqual(expected, actual);
            }

            Test(null, GetRandom.String(), false);
            Test(GetRandom.String(), GetRandom.String(), false);
            var s = GetRandom.String();
            Test(s, s, true);
            Test(s+"_desc", s, false);
        }

        [TestMethod] 
        public void SearchStringTest() 
        {
            var s = GetRandom.String();
            obj.SearchString = s;
            Assert.AreEqual(s, db.SearchString);
            Assert.AreEqual(s, obj.SearchString);
        }

        [TestMethod] 
        public void GetSortStringTest() 
        {
            const string page = "xxx/yyy";
            obj.SortOrder = "Name";
            obj.SearchString = "AAA";
            obj.FixedFilter = "BBB";
            obj.FixedValue = "CCC";
            var sortString = obj.GetSortString(x=>x.Name, page);
            var s = "xxx/yyy?sortOrder=Name_desc&currentFilter=AAA&fixedFilter=BBB&fixedValue=CCC";
            Assert.AreEqual(s, sortString);
        }

        [TestMethod] 
        public void GetSearchStringTest() 
        {
            static void Test(string filter, string searchString, int? pageIndex, bool isFirst) 
            {
                var expectedSearchString = isFirst ? searchString: filter;
                var expectedIndex = isFirst ? 1 : pageIndex;
                var actual = BasePage<IClientsRepository, Client, ClientView, ClientData>.GetSearchString(filter, searchString, ref pageIndex);
                Assert.AreEqual(expectedSearchString, actual);
                Assert.AreEqual(expectedIndex, pageIndex);
            }

            Test(GetRandom.String(), GetRandom.String(), GetRandom.UInt8(3), true);
            Test(GetRandom.String(), null, GetRandom.UInt8(3), false);
        }
    }
}
