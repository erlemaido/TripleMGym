using System;
using TrainingApp.Data.Common;

namespace TrainingApp.Data.SportsClub
{
    public sealed class TimetableEntryData : DefinedEntityData
    {
        public string CoachId { get; set; }
        public string TrainingId { get; set; }
        public string LocationId { get; set; }
        public string TrainingTypeId { get; set; }
        public TrainingLevel TrainingLevel { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MaxNumberOfParticipants { get; set; }
    }
}
