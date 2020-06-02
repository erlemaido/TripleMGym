using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Pages;

namespace TrainingApp.Tests.Pages {

    [TestClass]
    public class CommonPageTests : AbstractPageTests<CommonPage<IClientsRepository, Client, ClientView, ClientData>, 
        PaginatedPage<IClientsRepository, Client, ClientView, ClientData>> 
    {

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass(new TestRepository());
        }

        [TestMethod] 
        public void ItemIdTest() 
        {
            obj.Item = GetRandom.Object<ClientView>();
            Assert.AreEqual(obj.Item.GetId(), obj.ItemId);
        }

        [TestMethod] 
        public void PageTitleTest() 
        {
            IsNullableProperty(()=> obj.PageTitle, x => obj.PageTitle = x);
        }

        [TestMethod] 
        public void PageSubTitleTest() 
        {
            IsReadOnlyProperty(obj, nameof(obj.PageSubTitle), obj.GetPageSubTitle());
        }

        [TestMethod] 
        public void GetPageSubtitleTest() 
        {
            Assert.AreEqual(obj.PageSubTitle, obj.GetPageSubTitle());
        }

        [TestMethod] 
        public void PageUrlTest() 
        {
            IsReadOnlyProperty(obj, nameof(obj.PageUrl), obj.GetPageUrl());
        }

        [TestMethod] 
        public void GetPageUrlTest() 
        {
            Assert.AreEqual(obj.PageUrl, obj.GetPageUrl());
        }

        [TestMethod] 
        public void IndexUrlTest() 
        {
            IsReadOnlyProperty(obj, nameof(obj.IndexUrl), obj.GetIndexUrl());
        }

        [TestMethod] 
        public void GetIndexUrlTest() 
        {
            Assert.AreEqual(obj.IndexUrl, obj.GetIndexUrl());
        }
    }
}
