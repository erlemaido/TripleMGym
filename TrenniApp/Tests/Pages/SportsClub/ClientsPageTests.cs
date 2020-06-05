using System.Linq;
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
    public class ClientsPageTests : AbstractClassTests<ClientsPage, CommonPage<IClientsRepository, Client, ClientView, ClientData>> 
    {
        private class TestClass : ClientsPage
        {
            internal TestClass(IClientsRepository r, IParticipantOfTrainingsRepository participantsRepository, ITimetableEntriesRepository timetableEntriesRepository) : base(r, participantsRepository, timetableEntriesRepository)
            {
            }
        }

        private class TestRepository : BaseTestRepositoryForUniqueEntity<Client, ClientData>, IClientsRepository { }

        private class TestParticipantOfTrainingsRepository : BaseTestRepositoryForPeriodEntity<ParticipantOfTraining, ParticipantOfTrainingData>, IParticipantOfTrainingsRepository 
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

       private TestRepository clients;
       private TestParticipantOfTrainingsRepository participants;
       private TestTimetableEntriesRepository entries;
       private TimetableEntryData data;


       [TestInitialize]
       public override void TestInitialize()
       {
           base.TestInitialize();
           clients = new TestRepository();
           participants = new TestParticipantOfTrainingsRepository();
           entries = new TestTimetableEntriesRepository();
           data = GetRandom.Object<TimetableEntryData>();
           var m = new TimetableEntry(data);
           entries.Add(m).GetAwaiter();
           obj = new TestClass(clients, participants, entries);
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
       public void PageTitleTest() => Assert.AreEqual("Kliendid", obj.PageTitle);

       [TestMethod]
       public void PageUrlTest() => Assert.AreEqual("/SportsClub/Clients", obj.PageUrl);

       [TestMethod]
       public void ToObjectTest()
       {
           var view = GetRandom.Object<ClientView>();
           var o = obj.ToObject(view);
           TestArePropertyValuesEqual(view, o.Data);
       }

       [TestMethod]
       public void ToViewTest()
       {
           var d = GetRandom.Object<ClientData>();
           var view = obj.ToView(new Client(d));
           TestArePropertyValuesEqual(view, d);
       }
       
       [TestMethod]
       public void GetTimetableEntryNameTest()
       {
           var name = obj.GetTimetableEntryName(data.Id);
           Assert.AreEqual(data.Name, name);
       }

       [TestMethod]
       public void TimetableEntriesTest()
       {
           var list = entries.Get().GetAwaiter().GetResult();
           Assert.AreEqual(list.Count, obj.TimetableEntries.Count());
       }

       [TestMethod]
       public void ParticipantsTest()
       {
           var list = participants.Get().GetAwaiter().GetResult();
           Assert.AreEqual(list.Count, obj.Participants.Count());
       }

       [TestMethod]
       public void LoadDetailsTest()
       {
           var list = participants.Get().GetAwaiter().GetResult();
           var item = GetRandom.Object<ClientView>();
           obj.LoadDetails(item);
           Assert.AreNotEqual(list, obj.participants);
       }
    }
}
