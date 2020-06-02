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
    public class TrainingTypesRepositoryTests : RepositoryTests<TrainingTypesRepository, TrainingType, TrainingTypeData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SportsClubDbContext>()
                .UseInMemoryDatabase("TestDb") 
                .Options;
            db = new SportsClubDbContext(options);
            dbSet = ((SportsClubDbContext) db).TrainingTypes;
            obj = new TrainingTypesRepository((SportsClubDbContext) db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<TrainingType, TrainingTypeData>);
        }

        protected override string GetId(TrainingTypeData d) => d.Id;

        protected override TrainingType GetObject(TrainingTypeData d) => new TrainingType(d);

        protected override void SetId(TrainingTypeData d, string id) => d.Id = id;
    }
}
