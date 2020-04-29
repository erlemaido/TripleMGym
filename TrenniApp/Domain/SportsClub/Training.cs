using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.Common;

namespace TrainingApp.Domain.SportsClub
{
    public sealed class Training : Entity<TrainingData>
    {
        public Training() : this(null)
        {

        }

        public Training(TrainingData data) : base(data)
        {

        }
    }
}
