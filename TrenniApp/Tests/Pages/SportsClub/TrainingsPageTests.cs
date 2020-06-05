using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Formatters.Internal;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages;
using TrainingApp.Pages.SportsClub;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Data.SportsClub;
using TrainingApp.Infra.SportsClub;
using TrainingApp.Aids;
using TrainingApp.Tests.Data.SportsClub;

namespace TrainingApp.Tests.Pages.SportsClub
{
    [TestClass]
    public class TrainingsPageTests : AbstractClassTests<TrainingsPage, CommonPage<ITrainingsRepository, Training, TrainingView, TrainingData>>
    {
        private class TestClass : TrainingsPage
        {
            internal TestClass(ITrainingsRepository r, ITimetableEntriesRepository timetableEntriesRepository,
                ITrainingCategoriesRepository trainingCategoriesRepository,
                ICoachesRepository coachesRepository,ITrainingTypesRepository trainingTypesRepository, ILocationsRepository locationsRepository)
                : base(r, timetableEntriesRepository,trainingCategoriesRepository, coachesRepository, trainingTypesRepository, locationsRepository) { }
            
        }
        private class TestRepository : BaseTestRepositoryForUniqueEntity<Training, TrainingData>, ITrainingsRepository { }
        private class TestTrainingTypesRepository : BaseTestRepositoryForUniqueEntity<TrainingType, TrainingTypeData>, ITrainingTypesRepository { }

        private class TestTimetableEntriesRepository : BaseTestRepositoryForUniqueEntity<TimetableEntry, TimetableEntryData>, ITimetableEntriesRepository { }

        private class TestLocationsRepository : BaseTestRepositoryForUniqueEntity<Location, LocationData>, ILocationsRepository { }
        private class TestCoachesRepository : BaseTestRepositoryForUniqueEntity<Coach, CoachData>, ICoachesRepository { }
        private class TestTrainingCategoriesRepository : BaseTestRepositoryForUniqueEntity<TrainingCategory, TrainingCategoryData>, ITrainingCategoriesRepository { }

        private TestRepository trainings;
        private TestTimetableEntriesRepository entries;
        private TestTrainingTypesRepository types;
        private TestCoachesRepository coaches;
        private TestTrainingCategoriesRepository categories;
        private TestLocationsRepository locations;
        private TrainingData trainingData;
        private CoachData coachData;
        private TimetableEntryData entryData;
        private TrainingCategoryData categoryData;
        private LocationData locationData;
        private TrainingTypeData typeData;



        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            trainings = new TestRepository();
            entries = new TestTimetableEntriesRepository();
            types = new TestTrainingTypesRepository();
            coaches = new TestCoachesRepository();
            categories = new TestTrainingCategoriesRepository();
            locations = new TestLocationsRepository();
            trainingData = GetRandom.Object<TrainingData>();
            var t = new Training(trainingData);
            trainings.Add(t).GetAwaiter();
            typeData = GetRandom.Object<TrainingTypeData>();
            var tt = new TrainingType(typeData);
            types.Add(tt).GetAwaiter();
            locationData = GetRandom.Object<LocationData>();
            var l = new Location(locationData);
            locations.Add(l).GetAwaiter();
            coachData = GetRandom.Object<CoachData>();
            var c = new Coach(coachData);
            coaches.Add(c).GetAwaiter();
            categoryData = GetRandom.Object<TrainingCategoryData>();
            var tc = new TrainingCategory(categoryData);
            categories.Add(tc).GetAwaiter();
            obj = new TestClass(trainings, entries, categories, coaches, types, locations);

        }
        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<TrainingView>();
            obj.Item = item;
            Assert.AreEqual(item.GetId(), obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Treeningud", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/SportsClub/Trainings", obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<TrainingView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var d = GetRandom.Object<TrainingData>();
            var view = obj.ToView(new Training(d));
            TestArePropertyValuesEqual(view, d);
        }
        
        [TestMethod]
        public void CoachesTest()
        {
            var list = coaches.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Coaches.Count());
        }

        [TestMethod]
        public void TrainingCategoriesTest()
        {
            var list = trainings.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.TrainingCategories.Count());
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
        public void TimetableTrainingsTest()
        {
            var list = entries.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.TimetableTrainings.Count());
        }

        [TestMethod]
        public void GetTrainingCategoryNameTest()
        {
            var name = obj.GetTrainingCategoryName(categoryData.Id);
            Assert.AreEqual(categoryData.Name, name);
        }
        [TestMethod]
        public void GetTrainingTypeNameTest()
        {
            var name = obj.GetTrainingTypeName(typeData.Id);
            Assert.AreEqual(typeData.Name, name);
        }

        [TestMethod]
        public void GetLocationNameTest()
        {
            var name = obj.GetLocationName(locationData.Id);
            Assert.AreEqual(locationData.Name, name);
        }
        [TestMethod]
        public void GetCoachNameTest()
        {
            var name = obj.GetCoachName(coachData.Id);
            Assert.AreEqual(coachData.Name, name);
        }
        [TestMethod]
        public void LoadDetailsTest()
        {
            var list = entries.Get().GetAwaiter().GetResult();
            var item = GetRandom.Object<TrainingView>();
            obj.LoadDetails(item);
            Assert.AreNotEqual(list, obj.timetableTrainings);
        }
    }
}

