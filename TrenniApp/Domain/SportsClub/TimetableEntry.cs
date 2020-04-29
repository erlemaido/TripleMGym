using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.Common;

namespace TrainingApp.Domain.SportsClub
{
    public sealed class TimetableEntry : Entity<TimetableEntryData>
    {
        public TimetableEntry() : this(null)
        {

        }

        public TimetableEntry(TimetableEntryData data) : base(data)
        {

        }
    }
}
