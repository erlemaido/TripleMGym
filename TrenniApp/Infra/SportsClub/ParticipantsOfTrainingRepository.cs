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
            // Vaja lisada ka clientId, timetableEntryId
            var id = GetString.Head(participantOfTrainingId);
            var clientId = "";
            var timetableEntryId = "";
            var coachId = GetString.Tail(participantOfTrainingId);
            return await DbSet.SingleOrDefaultAsync(x => x.Id == id && x.ClientId == clientId && x.TimetableEntryId == timetableEntryId && x.CoachId == coachId);
        }

        protected override string GetId(ParticipantOfTraining obj)
        {
            return obj?.Data is null ? string.Empty : $"{obj.Data.Id}.{obj.Data.ClientId}.{obj.Data.TimetableEntryId}.{obj.Data.CoachId}";
        }

        protected internal override ParticipantOfTraining ToDomainObject(ParticipantOfTrainingData data) => new ParticipantOfTraining(data);
    }
}
