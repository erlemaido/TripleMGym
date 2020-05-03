using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Facade.SportsClub
{
    public static class TrainingViewFactory
    {
        public static Training Create(TrainingView v)
        {
            var d = new TrainingData();
            Copy.Members(v, d);

            return new Training(d);
        }

        public static TrainingView Create(Training o)
        {
            var v = new TrainingView();
            if (!(o?.Data is null))
                Copy.Members(o.Data, v);

            return v;
        }
    }
}
