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
    public class TrainingCategoriesRepositoryTests : RepositoryTests<TrainingCategoriesRepository, TrainingCategory, TrainingCategoryData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SportsClubDbContext>()
                .UseInMemoryDatabase("TestDb") 
                .Options;
            db = new SportsClubDbContext(options);
            dbSet = ((SportsClubDbContext) db).TrainingCategories;
            obj = new TrainingCategoriesRepository((SportsClubDbContext) db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<TrainingCategory, TrainingCategoryData>);
        }

        protected override string GetId(TrainingCategoryData d) => d.Id;

        protected override TrainingCategory GetObject(TrainingCategoryData d) => new TrainingCategory(d);

        protected override void SetId(TrainingCategoryData d, string id) => d.Id = id;
    }
}