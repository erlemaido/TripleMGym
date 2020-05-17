﻿using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TrainingApp.Aids;
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
            var id = GetString.Head(participantOfTrainingId);
            var clientId = "";
            var timetableId = GetString.Tail(participantOfTrainingId);
            return await DbSet.SingleOrDefaultAsync(x => x.Id == id && x.ClientId == clientId && x.TimetableEntryId == timetableId);
        }

        protected override string GetId(ParticipantOfTraining obj)
        {
            return obj?.Data is null ? string.Empty : $"{obj.Data.Id}.{obj.Data.ClientId}.{obj.Data.TimetableEntryId}";
        }

        protected internal override ParticipantOfTraining ToDomainObject(ParticipantOfTrainingData data) => new ParticipantOfTraining(data);
    }
}
