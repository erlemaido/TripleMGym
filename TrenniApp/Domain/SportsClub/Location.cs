using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.Common;

namespace TrainingApp.Domain.SportsClub
{
    public sealed class Location : Entity<LocationData>
    {
        public Location() : this(null)
        {

        }

        public Location(LocationData data) : base(data)
        {

        }
    }
}
