using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.Common;

namespace TrainingApp.Domain.SportsClub
{
    public sealed class Coach : Entity<CoachData>
    {
        public Coach() : this(null)
        {

        }

        public Coach(CoachData data) : base(data)
        {

        }
    }
}
