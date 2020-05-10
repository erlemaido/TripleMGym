using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Infra.SportsClub
{
    public sealed class TrainingCategoriesRepository : UniqueEntityRepository<TrainingCategory, TrainingCategoryData>, ITrainingCategoriesRepository
    {
        public TrainingCategoriesRepository(SportsClubDbContext c) : base(c, c.TrainingCategories) { }

        protected internal override TrainingCategory ToDomainObject(TrainingCategoryData d) => new TrainingCategory(d);
    }
}
