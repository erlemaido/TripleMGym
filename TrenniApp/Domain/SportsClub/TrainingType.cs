using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.Common;

namespace TrainingApp.Domain.SportsClub
{
    public sealed class TrainingType : Entity<TrainingTypeData>
    {
        public TrainingType() : this(null) { }

        public TrainingType(TrainingTypeData data) : base(data) { }
    }
}
