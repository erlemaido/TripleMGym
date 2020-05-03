using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Infra.SportsClub
{
    public sealed class TrainingTypesRepository : UniqueEntityRepository<TrainingType,TrainingTypeData>, ITrainingTypesRepository
    {
        public TrainingTypesRepository(SportsClubDbContext c) : base(c, c.TrainingTypes) { }

        protected internal override TrainingType ToDomainObject(TrainingTypeData d) => new TrainingType(d);
    }
}
