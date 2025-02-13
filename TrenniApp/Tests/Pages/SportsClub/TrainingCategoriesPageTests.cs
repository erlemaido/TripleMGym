﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Pages;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Tests.Pages.SportsClub
{
    [TestClass]
    public class TrainingCategoriesPageTests : AbstractClassTests<TrainingCategoriesPage, CommonPage<ITrainingCategoriesRepository, 
        TrainingCategory, TrainingCategoryView,TrainingCategoryData>>
    {
        private class TestClass : TrainingCategoriesPage
        {
            internal TestClass(ITrainingCategoriesRepository t) : base(t)
            {

            }
        }

        private class TestRepository : BaseTestRepositoryForUniqueEntity<TrainingCategory, TrainingCategoryData>, ITrainingCategoriesRepository { }

        private TestRepository trainingCategories;
        private TrainingCategoryData data;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            trainingCategories = new TestRepository();
            data = GetRandom.Object<TrainingCategoryData>();
            var l = new TrainingCategory(data);
            trainingCategories.Add(l).GetAwaiter();
            obj = new TestClass(trainingCategories);
        }

        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<TrainingCategoryView>();
            obj.Item = item;
            Assert.AreEqual(item.GetId(), obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Trenni kategooriad", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/SportsClub/TrainingCategories", obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<TrainingCategoryView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var d = GetRandom.Object<TrainingCategoryData>();
            var view = obj.ToView(new TrainingCategory(d));
            TestArePropertyValuesEqual(view, d);
        }
    }
}
