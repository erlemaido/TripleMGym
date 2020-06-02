using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Infra;
using TrainingApp.Infra.SportsClub;

namespace TrainingApp.Tests.Infra.SportsClub
{
    [TestClass]
    public class ParticipantOfTrainingsRepositoryTests : RepositoryTests<ParticipantOfTrainingsRepository, ParticipantOfTraining, ParticipantOfTrainingData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SportsClubDbContext>()
                .UseInMemoryDatabase("TestDb") 
                .Options;
            db = new SportsClubDbContext(options);
            dbSet = ((SportsClubDbContext) db).ParticipantsOfTraining;
            obj = new ParticipantOfTrainingsRepository((SportsClubDbContext) db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(PaginatedRepository<ParticipantOfTraining, ParticipantOfTrainingData>);
        }

        protected override string GetId(ParticipantOfTrainingData d) => $"{d.ClientId}.{d.TimetableEntryId}";

        protected override ParticipantOfTraining GetObject(ParticipantOfTrainingData d) => new ParticipantOfTraining(d);

        protected override void SetId(ParticipantOfTrainingData d, string id)
        {
            var clientId = GetString.Head(id);
            var timetableEntryId = GetString.Tail(id);
            d.ClientId = clientId;
            d.TimetableEntryId = timetableEntryId;
        }
    }
}
