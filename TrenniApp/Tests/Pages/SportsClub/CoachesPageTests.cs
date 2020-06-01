

using System.Linq;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
    public class CoachesPageTests : AbstractClassTests<CoachesPage,
        CommonPage<ICoachesRepository, Coach, CoachView, CoachData>>
    {
        private class TestClass : CoachesPage
        {
            internal TestClass(ICoachesRepository c, ITimetableEntriesRepository te, ITrainingsRepository t, ILocationsRepository l, ITrainingTypesRepository tt) : base(c, te, t, l, tt)
            {
            }
        }

        private class TestRepository : BaseTestRepositoryForUniqueEntity<Coach, CoachData>, ICoachesRepository { }
        private class TestTrainingTypesRepository : BaseTestRepositoryForUniqueEntity<TrainingType, TrainingTypeData>, ITrainingTypesRepository { }

        private class TestTimetableEntriesRepository : BaseTestRepositoryForUniqueEntity<TimetableEntry, TimetableEntryData>, ITimetableEntriesRepository { }
        private class TestLocationsRepository : BaseTestRepositoryForUniqueEntity<Location, LocationData>, ILocationsRepository { }
        private class TestTrainingsRepository : BaseTestRepositoryForUniqueEntity<Training, TrainingData>, ITrainingsRepository { }

        private TestRepository coaches;
        private TestTrainingTypesRepository types;
        private TestTimetableEntriesRepository entries;
        private TestLocationsRepository locations;
        private CoachData data;
        private TrainingData trainingData;
        private TrainingTypeData trainingTypeData;
        private LocationData locationData;
        private TestTrainingsRepository trainings;


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            coaches = new TestRepository();
            entries = new TestTimetableEntriesRepository();
            trainings = new TestTrainingsRepository();
            locations = new TestLocationsRepository();
            types = new TestTrainingTypesRepository();
            data = GetRandom.Object<CoachData>();
            var c = new Coach(data);
            coaches.Add(c).GetAwaiter();
            trainingData = GetRandom.Object<TrainingData>();
            var t = new Training(trainingData);
            trainings.Add(t).GetAwaiter();
            trainingTypeData = GetRandom.Object<TrainingTypeData>();
            var tt = new TrainingType(trainingTypeData);
            types.Add(tt).GetAwaiter();
            locationData = GetRandom.Object<LocationData>();
            var l = new Location(locationData);
            locations.Add(l).GetAwaiter();
            obj = new TestClass(coaches, entries, trainings, locations, types);
        }
        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<CoachView>();
            obj.Item = item;
            Assert.AreEqual(item.GetId(), obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Treenerid", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/SportsClub/Coaches", obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<CoachView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var d = GetRandom.Object<CoachData>();
            var view = obj.ToView(new Coach(d));
            TestArePropertyValuesEqual(view, d);
        }

        [TestMethod]
        public void TimetableEntriesTest()
        {
            var list = entries.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.TimetableEntries.Count());
        }

        [TestMethod]
        public void TrainingsTest()
        {
            var list = trainings.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Trainings.Count());
        }

        [TestMethod]
        public void LocationsTest()
        {
            var list = locations.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Locations.Count());
        }

        [TestMethod]
        public void TrainingTypesTest()
        {
            var list = types.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.TrainingTypes.Count());
        }

        [TestMethod]
        public void GetTrainingNameTest()
        {
            var name = obj.GetTrainingName(trainingData.Id);
            Assert.AreEqual(trainingData.Name, name);
        }

        [TestMethod]
        public void GetTrainingTypeNameTest()
        {
            var name = obj.GetTrainingTypeName(trainingTypeData.Id);
            Assert.AreEqual(trainingTypeData.Name, name);
        }

        [TestMethod]
        public void GetLocationNameTest()
        {
            var name = obj.GetLocationName(locationData.Id);
            Assert.AreEqual(locationData.Name, name);
        }

        [TestMethod]
        public void LoadDetailsTest()
        {
            var list = entries.Get().GetAwaiter().GetResult();
            var item = GetRandom.Object<CoachView>();
            obj.LoadDetails(item);
            Assert.AreNotEqual(list, obj.timetableEntries);
        }
    }
}

