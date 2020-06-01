

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
    public class ParticipantOfTrainingsPageTests : AbstractClassTests<ParticipantOfTrainingsPage,
        CommonPage<IParticipantOfTrainingsRepository, ParticipantOfTraining, ParticipantOfTrainingView, ParticipantOfTrainingData>>
    {
        private class TestClass : ParticipantOfTrainingsPage
        {
            internal TestClass(IParticipantOfTrainingsRepository p, ITimetableEntriesRepository timetableEntriesRepository, IClientsRepository clientsRepository) : base(p, timetableEntriesRepository, clientsRepository)
            {
            }
        }

        private class TestClientsRepository : BaseTestRepositoryForUniqueEntity<Client, ClientData>, IClientsRepository { }
        private class TestRepository : BaseTestRepositoryForPeriodEntity<ParticipantOfTraining, ParticipantOfTrainingData>, IParticipantOfTrainingsRepository
        {
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


        private TestRepository participants;
        private TestClientsRepository clients;
        private TestTimetableEntriesRepository entries;
        private TimetableEntryData data;
        private ClientData clientData;


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            participants = new TestRepository();
            clients = new TestClientsRepository();
            clientData = GetRandom.Object<ClientData>();
            var c = new Client(clientData);
            clients.Add(c).GetAwaiter();
            entries = new TestTimetableEntriesRepository();
            data = GetRandom.Object<TimetableEntryData>();
            var tt = new TimetableEntry(data);
            entries.Add(tt).GetAwaiter();
            obj = new TestClass(participants, entries, clients);
        }
        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<ParticipantOfTrainingView>();
            obj.Item = item;
            Assert.AreEqual(item.GetId(), obj.ItemId);
            obj.Item = null;
            Assert.AreEqual(string.Empty, obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Broneeringud", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/SportsClub/ParticipantOfTrainings", obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<ParticipantOfTrainingView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var d = GetRandom.Object<ParticipantOfTrainingData>();
            var view = obj.ToView(new ParticipantOfTraining(d));
            TestArePropertyValuesEqual(view, d);
        }

        [TestMethod]
        public void GetTimetableEntryNameTest()
        {
            var name = obj.GetTimetableEntryName(data.Id);
            Assert.AreEqual(data.Name, name);
        }

        [TestMethod]
        public void GetClientNameTest()
        {
            var name = obj.GetClientName(clientData.Id);
            Assert.AreEqual(clientData.Name, name);
        }

        [TestMethod]
        public void TimetableEntriesTest()
        {
            var list = entries.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.TimetableEntries.Count());
        }

        [TestMethod]
        public void ClientsTest()
        {
            var list = clients.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Clients.Count());
        }

    }
}

