using System;
using TrainingApp.Data.Common;

namespace TrainingApp.Data.SportsClub
{
    public sealed class ParticipantOfTrainingData : NamedEntityData
    {
        public string ClientId { get; set; }
        public string TimetableEntryId { get; set; }
        public DateTime RegistrationTime { get; set; }
    }
}
