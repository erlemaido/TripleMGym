using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Infra;
using TrainingApp.Infra.SportsClub;

namespace TrainingApp.Tests.Infra.SportsClub
{
    [TestClass]
    public class TrainingsRepositoryTests : RepositoryTests<TrainingsRepository, Training, TrainingData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SportsClubDbContext>()
                .UseInMemoryDatabase("TestDb") 
                .Options;
            db = new SportsClubDbContext(options);
            dbSet = ((SportsClubDbContext) db).Trainings;
            obj = new TrainingsRepository((SportsClubDbContext) db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<Training, TrainingData>);
        }

        protected override string GetId(TrainingData d) => d.Id;

        protected override Training GetObject(TrainingData d) => new Training(d);

        protected override void SetId(TrainingData d, string id) => d.Id = id;
    }
}
