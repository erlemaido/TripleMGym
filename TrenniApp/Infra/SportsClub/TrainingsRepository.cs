using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Infra.SportsClub
{
    public sealed class TrainingsRepository : PaginatedRepository<Training, TrainingData>, ITrainingsRepository
    {
        public TrainingsRepository() : this(null) { }

        public TrainingsRepository(SportsClubDbContext c) : base(c, c.Trainings) { }

        protected override async Task<TrainingData> GetData(string trainingId)
        {
            var id = GetString.Head(trainingId);
            var trainingCategoryId = GetString.Tail(trainingId);
            return await DbSet.SingleOrDefaultAsync(x => x.Id == id && x.TrainingCategoryId == trainingCategoryId);

        }

        protected override string GetId(Training obj)
        {
            return obj?.Data is null ? string.Empty : $"{obj.Data.Id}.{obj.Data.TrainingCategoryId}";
        }

        protected internal override Training ToDomainObject(TrainingData d) => new Training(d);
    }
}
