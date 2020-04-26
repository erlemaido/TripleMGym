using TrainingApp.Data.Common;
using TrainingApp.Data.Training;
using TrainingApp.Domain.Common;

namespace TrainingApp.Domain.Training
{
    public sealed class TrainingDomain : Entity<TrainingData>
    {
        public TrainingDomain() : this(null) { }

        public TrainingDomain(TrainingData data) : base(data) { }
    }
}
