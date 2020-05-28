

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
    public class ClientsPageTests : AbstractClassTests<ClientsPage,
        CommonPage<IClientsRepository, Client, ClientView, ClientData>>
    {
        private class TestClass : ClientsPage
        {
            internal TestClass(IClientsRepository r, IParticipantOfTrainingsRepository p, ITimetableEntriesRepository t) : base(r, p, t)
            {
            }
        }

        private class TestRepository : BaseTestRepositoryForUniqueEntity<Client, ClientData>, IClientsRepository { }
        private class TestParticipantOfTrainingsRepository : BaseTestRepositoryForPeriodEntity<ParticipantOfTraining, ParticipantOfTrainingData>, IParticipantOfTrainingsRepository {
            protected override bool IsThis(ParticipantOfTraining entity, string id)
            {
                throw new System.NotImplementedException();
            }

            protected override string GetId(ParticipantOfTraining entity)
            {
                throw new System.NotImplementedException();
            }
        }
       private class TestTimetableEntriesRepository : BaseTestRepositoryForUniqueEntity<TimetableEntry, TimetableEntryData>, ITimetableEntriesRepository { }


        private TestRepository clients;
        private TestParticipantOfTrainingsRepository participants;
        private TestTimetableEntriesRepository entry;


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            clients = new TestRepository();
            participants = new TestParticipantOfTrainingsRepository();
            entry = new TestTimetableEntriesRepository();
            organizations = new TestOrganizationsRepository();
            eventLists = new TestClientListsRepository();
            data = GetRandom.Object<SportCategoryData>();
            var m = new SportCategoryDomain(data);
            categories.Add(m).GetAwaiter();
            obj = new TestClass(events, categories, organizations, eventLists, locations);
        }
        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<ClientView>();
            obj.Item = item;
            Assert.AreEqual(item.GetId(), obj.ItemId);
            obj.Item = null;
            Assert.AreEqual(string.Empty, obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Üritused", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Client/Clients", obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<ClientView>();
            var o = obj.toObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var d = GetRandom.Object<ClientData>();
            var view = obj.toView(new ClientDomain(d));
            TestArePropertyValuesEqual(view, d);
        }
        [TestMethod]
        public void GetSportCategoryNameTest()
        {
            var name = obj.GetSportCategoryName(data.Id);
            Assert.AreEqual(data.Name, name);
        }
        [TestMethod]
        public void SportCategoriesTest()
        {
            var list = categories.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.SportCategories.Count());
        }
        [TestMethod]
        public void LocationsTest()
        {
            var list = locations.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Locations.Count());
        }
        [TestMethod]
        public void OrganizationsTest()
        {
            var list = organizations.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Organizations.Count());
        }
        [TestMethod]
        public void ClientListsTest()
        {
            var list = eventLists.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.ClientLists.Count());
        }
    }
}

