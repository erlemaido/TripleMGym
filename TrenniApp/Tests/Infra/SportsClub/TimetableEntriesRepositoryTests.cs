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
    public class TimetableEntriesRepositoryTests : RepositoryTests<TimetableEntriesRepository, TimetableEntry, TimetableEntryData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SportsClubDbContext>()
                .UseInMemoryDatabase("TestDb") 
                .Options;
            db = new SportsClubDbContext(options);
            dbSet = ((SportsClubDbContext) db).TimetableEntries;
            obj = new TimetableEntriesRepository((SportsClubDbContext) db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<TimetableEntry, TimetableEntryData>);
        }

        protected override string GetId(TimetableEntryData d) => d.Id;

        protected override TimetableEntry GetObject(TimetableEntryData d) => new TimetableEntry(d);

        protected override void SetId(TimetableEntryData d, string id) => d.Id = id;
    }
}
