using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Facade.SportsClub
{
    public static class CoachViewFactory
    {
        public static Coach Create(CoachView v)
        {
            var d = new CoachData();
            Copy.Members(v, d);

            return new Coach(d);
        }

        public static CoachView Create(Coach o)
        {
            var v = new CoachView();
            if (!(o?.Data is null))
                Copy.Members(o.Data, v);

            return v;
        }
    }
}
