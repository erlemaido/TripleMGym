using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Facade.SportsClub
{
    public static class LocationViewFactory
    {
        public static Location Create(LocationView v)
        {
            var d = new LocationData();
            Copy.Members(v, d);

            return new Location(d);
        }

        public static LocationView Create(Location o)
        {
            var v = new LocationView();
            if (!(o?.Data is null))
                Copy.Members(o.Data, v);

            return v;
        }
    }
}
