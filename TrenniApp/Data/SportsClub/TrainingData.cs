using TrainingApp.Data.Common;

namespace TrainingApp.Data.SportsClub
{
    public sealed class TrainingData : DefinedEntityData
    {
        public string TrainingCategoryId { get; set; }
        public string Code { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
