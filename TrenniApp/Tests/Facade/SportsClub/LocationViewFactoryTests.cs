using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Tests.Facade.SportsClub
{
    [TestClass]
    public class LocationViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(LocationViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<LocationView>();
            var data = LocationViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);

        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<LocationData>();
            var view = LocationViewFactory.Create(new Location(data));
            TestArePropertyValuesEqual(view, data);

        }
    }
}
