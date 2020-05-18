using System;
using TrainingApp.Data.Common;

namespace TrainingApp.Data.SportsClub
{
    public sealed class ParticipantOfTrainingData : PeriodData
    {
        public string ClientId { get; set; }
        public string TimetableEntryId { get; set; }
    }
}
