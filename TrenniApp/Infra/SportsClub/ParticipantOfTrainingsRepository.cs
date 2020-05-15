using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Infra.SportsClub
{
    public sealed class ParticipantOfTrainingsRepository : PaginatedRepository<ParticipantOfTraining, ParticipantOfTrainingData>, IParticipantOfTrainingsRepository
    {
        public ParticipantOfTrainingsRepository() : this(null) { }

        public ParticipantOfTrainingsRepository(SportsClubDbContext c) : base(c, c.ParticipantsOfTraining) { }

        protected override async Task<ParticipantOfTrainingData> GetData(string participantOfTrainingId)
        {
            return await DbSet.SingleOrDefaultAsync(x => x.Id == participantOfTrainingId);
        }

        protected override string GetId(ParticipantOfTraining obj)
        {
            return obj?.Data is null ? string.Empty : obj.Data.Id;
        }

        protected internal override ParticipantOfTraining ToDomainObject(ParticipantOfTrainingData data) => new ParticipantOfTraining(data);
    }
}
