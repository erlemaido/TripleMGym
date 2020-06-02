using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Pages;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Tests.Pages.SportsClub
{
    [TestClass]
    public class LocationsPageTests : AbstractClassTests<LocationsPage, CommonPage<ILocationsRepository, Location, LocationView, LocationData>>
    {
        private class TestClass : LocationsPage
        {
            internal TestClass(ILocationsRepository l) : base(l)
            {
            }
        }

        private class TestRepository : BaseTestRepositoryForUniqueEntity<Location, LocationData>, ILocationsRepository { }
      
        private TestRepository locations;
        private LocationData data;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            locations = new TestRepository();
            data = GetRandom.Object<LocationData>();
            var l = new Location(data);
            locations.Add(l).GetAwaiter();
            obj = new TestClass(locations);
        }

        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<LocationView>();
            obj.Item = item;
            Assert.AreEqual(item.GetId(), obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Asukohad", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/SportsClub/Locations", obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<LocationView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var d = GetRandom.Object<LocationData>();
            var view = obj.ToView(new Location(d));
            TestArePropertyValuesEqual(view, d);
        }
    }
}
