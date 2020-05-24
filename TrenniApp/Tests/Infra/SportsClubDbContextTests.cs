using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Infra.SportsClub;

namespace TrainingApp.Tests.Infra
{
    [TestClass]
    public class SportsClubDbContextTests : BaseClassTests<SportsClubDbContext, DbContext>
    {

        private DbContextOptions<SportsClubDbContext> options;

        private class TestClass : SportsClubDbContext
        {
            public TestClass(DbContextOptions<SportsClubDbContext> o) : base(o) { }

            public ModelBuilder RunOnModelCreating()
            {
                var set = new ConventionSet();
                var mb = new ModelBuilder(set);
                OnModelCreating(mb);

                return mb;
            }
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            options = new DbContextOptionsBuilder<SportsClubDbContext>().UseInMemoryDatabase("TestDb").Options;
            obj = new SportsClubDbContext(options);
        }

        [TestMethod]
        public void InitializeTablesTest()
        {
            static void TestKey<T>(IMutableEntityType entity, params Expression<Func<T, object>>[] values)
            {
                var key = entity.FindPrimaryKey();

                if (values is null) Assert.IsNull(key);
                else
                    foreach (var v in values)
                    {
                        var name = GetMember.Name(v);
                        Assert.IsNotNull(key.Properties.FirstOrDefault(x => x.Name == name));
                    }
            }

            static void TestEntity<T>(ModelBuilder b, params Expression<Func<T, object>>[] values)
            {
                var name = typeof(T).FullName ?? string.Empty;
                var entity = b.Model.FindEntityType(name);
                Assert.IsNotNull(entity, name);
                TestKey(entity, values);
            }

            SportsClubDbContext.InitializeTables(null);
            var o = new TestClass(options);
            var builder = o.RunOnModelCreating();
            SportsClubDbContext.InitializeTables(builder);
            TestEntity<ClientData>(builder, x => x.DateOfJoining, x => x.Email);
            TestEntity<CoachData>(builder, x=> x.CoachCertificateNumber, x=> x.Email, x=> x.Age, x=> x.HireDate);
            TestEntity<LocationData>(builder);
            TestEntity<ParticipantOfTrainingData>(builder, x=> x.TimetableEntryId, x=> x.ClientId);
            TestEntity<TimetableEntryData>(builder, x=> x.TrainingId, x => x.EndTime, x => x.StartTime, x => x.MaxNumberOfParticipants,
                x => x.TrainingTypeId, x => x.TrainingLevel, x => x.CoachId, x => x.LocationId);
            TestEntity<TrainingCategoryData>(builder);
            TestEntity<TrainingTypeData>(builder);
            TestEntity<TrainingData>(builder, x => x.TrainingCategoryId, x => x.Code, x=> x.DurationInMinutes);
        }

        [TestMethod]
        public void ClientsTest() =>
            isNullableProperty(obj, nameof(obj.Clients), typeof(DbSet<ClientData>));

        [TestMethod]
        public void CoachesTest() =>
            isNullableProperty(obj, nameof(obj.Coaches), typeof(DbSet<CoachData>));

        [TestMethod]
        public void LocationsTest() =>
            isNullableProperty(obj, nameof(obj.Locations), typeof(DbSet<LocationData>));

        [TestMethod]
        public void ParticipantsOfTrainingTest() =>
            isNullableProperty(obj, nameof(obj.ParticipantsOfTraining), typeof(DbSet<ParticipantOfTrainingData>));

        [TestMethod]
        public void TimetableEntriesTest() =>
            isNullableProperty(obj, nameof(obj.TimetableEntries), typeof(DbSet<TimetableEntryData>));

        [TestMethod]
        public void TrainingCategoriesTest() =>
            isNullableProperty(obj, nameof(obj.TrainingCategories), typeof(DbSet<TrainingCategoryData>));

        [TestMethod]
        public void TrainingTypesTest() =>
            isNullableProperty(obj, nameof(obj.TrainingTypes), typeof(DbSet<TrainingTypeData>));

        [TestMethod]
        public void TrainingsTest() =>
            isNullableProperty(obj, nameof(obj.Trainings), typeof(DbSet<TrainingData>));
    }
}
