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
    public class LocationsRepositoryTests : RepositoryTests<LocationsRepository, Location, LocationData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SportsClubDbContext>()
                .UseInMemoryDatabase("TestDb") 
                .Options;
            db = new SportsClubDbContext(options);
            dbSet = ((SportsClubDbContext) db).Locations;
            obj = new LocationsRepository((SportsClubDbContext) db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<Location, LocationData>);
        }

        protected override string GetId(LocationData d) => d.Id;

        protected override Location GetObject(LocationData d) => new Location(d);

        protected override void SetId(LocationData d, string id) => d.Id = id;
    }
}
