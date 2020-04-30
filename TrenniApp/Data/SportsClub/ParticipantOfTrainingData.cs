using System;
using TrainingApp.Data.Common;

namespace TrainingApp.Data.SportsClub
{
    public sealed class ParticipantOfTrainingData : UniqueEntityData
    {
        public string ClientId { get; set; }
        public string TimetableEntryId { get; set; }
        public string CoachId { get; set; }
        public DateTime RegistrationTime { get; set; }
    }
}
