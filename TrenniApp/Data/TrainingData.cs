
using TrainingApp.Data.Common;

namespace TrainingApp.Data
{
    public sealed class TrainingData : DefinedEntityData
    {
        public string TrainingCategoryId { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }

        public TrainingType TrainingType { get; set; }
        public int DurationInMinutes { get; set; } 
        public int MaxNumberOfParticipants { get; set; }
    }
}
