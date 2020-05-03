using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Facade.SportsClub
{
    public static class TrainingCategoryViewFactory
    {
        public static TrainingCategory Create(TrainingCategoryView v)
        {
            var d = new TrainingCategoryData();
            Copy.Members(v, d);

            return new TrainingCategory(d);
        }

        public static TrainingCategoryView Create(TrainingCategory o)
        {
            var v = new TrainingCategoryView();
            if (!(o?.Data is null))
                Copy.Members(o.Data, v);

            return v;
        }
    }
}
