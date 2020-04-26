using TrainingApp.Data.Common;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.Common;

namespace TrainingApp.Domain.SportsClub
{
    public class SportsClubDomain : Entity<SportsClubData>
    {
        public SportsClubDomain() : this(null) { }

        public SportsClubDomain(SportsClubData data) : base(data) { }
    }
}
