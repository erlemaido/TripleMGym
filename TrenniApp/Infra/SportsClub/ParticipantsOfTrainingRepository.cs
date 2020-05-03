using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Infra.SportsClub
{
    public sealed class ParticipantsOfTrainingRepository : UniqueEntityRepository<ParticipantOfTraining, ParticipantOfTrainingData>, IParticipantsOfTrainingRepository
    {
        public ParticipantsOfTrainingRepository(SportsClubDbContext c) : base(c, c.ParticipantsOfTraining)
        {
        }
        protected internal override ParticipantOfTraining ToDomainObject(ParticipantOfTrainingData d) => new ParticipantOfTraining(d);
    }
}
