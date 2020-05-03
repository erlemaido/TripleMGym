using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Facade.SportsClub
{
    public static class TrainingTypeViewFactory
    {
        public static TrainingType Create(TrainingTypeView v)
        {
            var d = new TrainingTypeData();
            Copy.Members(v, d);

            return new TrainingType(d);
        }

        public static TrainingTypeView Create(TrainingType o)
        {
            var v = new TrainingTypeView();
            if (!(o?.Data is null))
                Copy.Members(o.Data, v);

            return v;
        }
    }
}
