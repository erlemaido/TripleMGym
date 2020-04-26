using TrainingApp.Data.Common;

namespace TrainingApp.Domain.Training
{
    public sealed class Training : TitledEntityData
    {
        public TrainingType TrainingType { get; set; }
    }
}
