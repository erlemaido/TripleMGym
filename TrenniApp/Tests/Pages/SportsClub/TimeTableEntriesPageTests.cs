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
    public class TimetableEntriesPageTests : AbstractClassTests<TimeTableEntriesPage, CommonPage<ITimetableEntriesRepository, TimetableEntry, TimetableEntryView, TimetableEntryData>>
    {
        private class TestClass : TimeTableEntriesPage
        {
            internal TestClass(IClientsRepository c, ITimetableEntriesRepository te, ITrainingsRepository trainingsRepository, ILocationsRepository locationsRepository, ITrainingTypesRepository trainingTypesRepository,
                ICoachesRepository co, IParticipantOfTrainingsRepository participantsRepository) : base(te, participantsRepository, trainingsRepository, co, locationsRepository , trainingTypesRepository, c)
            {
            }
        }

        private class TestRepository : BaseTestRepositoryForUniqueEntity<TimetableEntry, TimetableEntryData>, ITimetableEntriesRepository { }
        
        private class TestTrainingTypesRepository : BaseTestRepositoryForUniqueEntity<TrainingType, TrainingTypeData>, ITrainingTypesRepository { }

        private class TestTimetableEntriesRepository : BaseTestRepositoryForUniqueEntity<TimetableEntry, TimetableEntryData>, ITimetableEntriesRepository { }
        
        private class TestLocationsRepository : BaseTestRepositoryForUniqueEntity<Location, LocationData>, ILocationsRepository { }
        
        private class TestTrainingsRepository : BaseTestRepositoryForUniqueEntity<Training, TrainingData>, ITrainingsRepository { }
        
        private class TestCoachesRepository : BaseTestRepositoryForUniqueEntity<Coach, CoachData>, ICoachesRepository { }

        private class TestClientsRepository : BaseTestRepositoryForUniqueEntity<Client, ClientData>, IClientsRepository { }
        
        private class TestParticipantsRepository : BaseTestRepositoryForPeriodEntity<ParticipantOfTraining, ParticipantOfTrainingData>, IParticipantOfTrainingsRepository {
            protected override bool IsThis(ParticipantOfTraining entity, string id)
            {
                return true;
            }

            protected override string GetId(ParticipantOfTraining entity)
            {
                return string.Empty;
            }
        }

        private TestRepository entries;
        private TestParticipantsRepository participants;
        private TestTrainingTypesRepository types;
        private TestCoachesRepository coaches;
        private TestLocationsRepository locations;
        private TestClientsRepository clients;
        private TimetableEntryData data;
        private ClientData clientData;
        private CoachData coachData;
        private LocationData locationData;
        private TrainingTypeData trainingTypeData;
        private TrainingData trainingData;
        private TestTrainingsRepository trainings;


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            entries = new TestRepository();
            trainings = new TestTrainingsRepository();
            locations = new TestLocationsRepository();
            coaches = new TestCoachesRepository();
            types = new TestTrainingTypesRepository();
            participants = new TestParticipantsRepository();
            clients = new TestClientsRepository();
            data = GetRandom.Object<TimetableEntryData>();
            var e = new TimetableEntry(data);
            entries.Add(e).GetAwaiter();
            clientData = GetRandom.Object<ClientData>();
            var c = new Client(clientData);
            clients.Add(c).GetAwaiter();
            coachData = GetRandom.Object<CoachData>();
            var co = new Coach(coachData);
            coaches.Add(co).GetAwaiter();
            trainingData = GetRandom.Object<TrainingData>();
            var t = new Training(trainingData);
            trainings.Add(t).GetAwaiter();
            trainingTypeData = GetRandom.Object<TrainingTypeData>();
            var tt = new TrainingType(trainingTypeData);
            types.Add(tt).GetAwaiter();
            locationData = GetRandom.Object<LocationData>();
            var l = new Location(locationData);
            locations.Add(l).GetAwaiter();
            obj = new TestClass(clients, entries, trainings, locations, types, coaches, participants);
        }

        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<TimetableEntryView>();
            obj.Item = item;
            Assert.AreEqual(item.GetId(), obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Tunniplaan", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/SportsClub/TimetableEntries", obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<TimetableEntryView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var d = GetRandom.Object<TimetableEntryData>();
            var view = obj.ToView(new TimetableEntry(d));
            TestArePropertyValuesEqual(view, d);
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
        public void ParticipantsTest()
        {
            var list = participants.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Participants.Count());
        }

        [TestMethod]
        public void CoachesTest()
        {
            var list = coaches.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Coaches.Count());
        }

        [TestMethod]
        public void ClientsTest()
        {
            var list = clients.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Clients.Count());
        }

        [TestMethod]
        public void TrainingLevelsTest()
        {
            var list = 
        }


        [TestMethod]
        public void GetClientNameTest()
        {
            var name = obj.GetClientName(clientData.Id);
            Assert.AreEqual(clientData.Name, name);
        }

        [TestMethod]
        public void GetCoachNameTest()
        {
            var name = obj.GetCoachName(coachData.Id);
            Assert.AreEqual(coachData.Name, name);
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
            var item = GetRandom.Object<TimetableEntryView>();
            obj.LoadDetails(item);
            Assert.AreNotEqual(list, obj.Participants);
        }
    }
}
