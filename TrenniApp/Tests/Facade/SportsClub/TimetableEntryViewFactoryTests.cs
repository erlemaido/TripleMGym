using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Aids;
namespace TrainingApp.Tests.Facade.SportsClub
{
    [TestClass]
    public class TimetableEntryViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(TimetableEntryViewFactory);
        }
        [TestMethod]
        public void CreateTest()
        {
        }
        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<TimetableEntryView>();
            var data = TimetableEntryViewFactory.Create(view).Data;
            testArePropertyValuesEqual(view, data);

        }
        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<TimetableEntryData>();
            var view = TimetableEntryViewFactory.Create(new TimetableEntry(data));
            testArePropertyValuesEqual(view, data);

        }
    }
}
