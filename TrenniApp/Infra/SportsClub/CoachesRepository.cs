using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Infra.SportsClub
{
    public sealed class CoachesRepository : UniqueEntityRepository<Coach, CoachData>, ICoachesRepository
    {
        public CoachesRepository(SportsClubDbContext c) : base(c, c?.Coaches) { }

        protected internal override Coach ToDomainObject(CoachData d) => new Coach(d);
    }
}
