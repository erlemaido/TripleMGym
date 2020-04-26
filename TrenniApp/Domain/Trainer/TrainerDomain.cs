using TrainingApp.Data.Common;
using TrainingApp.Data.Trainer;
using TrainingApp.Domain.Common;

namespace TrainingApp.Domain.Trainer

{
    public sealed class TrainerDomain : Entity<TrainerData>
    {
        public TrainerDomain() : this(null) { }

        public TrainerDomain(TrainerData data) : base(data) { }
    }
}
