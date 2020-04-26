using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.Common;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Facade.SportsClub {

    public static class SportsClubViewFactory
    {
        public static SportsClubDomain Create(SportsClubView view)
        {
            var d = new SportsClubData();
            Copy.Members(view, d);
            return new SportsClubDomain(d);
        }

        public static SportsClubView Create(SportsClubDomain obj)
        {
            var v = new SportsClubView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}