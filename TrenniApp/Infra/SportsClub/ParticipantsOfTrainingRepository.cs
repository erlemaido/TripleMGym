using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Infra.SportsClub
{
    public sealed class ParticipantsOfTrainingRepository : PaginatedRepository<ParticipantOfTraining, ParticipantOfTrainingData>, IParticipantsOfTrainingRepository
    {
        public ParticipantsOfTrainingRepository() : this(null) { }

        public ParticipantsOfTrainingRepository(SportsClubDbContext c) : base(c, c.ParticipantsOfTraining) { }

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
