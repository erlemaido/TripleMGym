using System;
using TrainingApp.Data.Common;

namespace TrainingApp.Data
{
    public sealed class CoachTrainingData : DefinedEntityData
    {
        public string CoachId { get; set; }
        public string TrainingId { get; set; }
        public string LocationId { get; set; }
        public TrainingLevel TrainingLevel { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int NumberOfParticipants { get; set; }
        public string? Comment { get; set; }
    }
}
