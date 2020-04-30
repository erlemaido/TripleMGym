using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.Common;

namespace TrainingApp.Domain.SportsClub
{
    public sealed class TrainingCategory : Entity<TrainingCategoryData>
    {
        public TrainingCategory() : this(null)
        {

        }

        public TrainingCategory(TrainingCategoryData data) : base(data)
        {

        }
    }
}
