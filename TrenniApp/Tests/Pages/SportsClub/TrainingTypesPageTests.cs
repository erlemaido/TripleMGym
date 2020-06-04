using System;
using System.Collections.Generic;
using System.Text;
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
    public class TrainingTypesPageTests : AbstractClassTests<TrainingTypesPage, CommonPage<ITrainingTypesRepository, TrainingType, TrainingTypeView, TrainingTypeData>>
    {
        private class TestClass : TrainingTypesPage
        {
            internal TestClass(ITrainingTypesRepository t) : base(t)
            {
            }
        }

        private class TestRepository : BaseTestRepositoryForUniqueEntity<TrainingType, TrainingTypeData>, ITrainingTypesRepository { }

        private TestRepository trainingTypes;
        private TrainingTypeData data;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            trainingTypes = new TestRepository();
            data = GetRandom.Object<TrainingTypeData>();
            var l = new TrainingType(data);
            trainingTypes.Add(l).GetAwaiter();
            obj = new TestClass(trainingTypes);
        }

        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<TrainingTypeView>();
            obj.Item = item;
            Assert.AreEqual(item.GetId(), obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Trenni tüübid", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/SportsClub/TrainingTypes", obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<TrainingTypeView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var d = GetRandom.Object<TrainingTypeData>();
            var view = obj.ToView(new TrainingType(d));
            TestArePropertyValuesEqual(view, d);
        }
    }
    
}
