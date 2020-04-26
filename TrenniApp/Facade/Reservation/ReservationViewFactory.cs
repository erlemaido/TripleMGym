using TrainingApp.Aids;
using TrainingApp.Data.Reservation;
using TrainingApp.Domain.Common;
using TrainingApp.Domain.Reservation;

namespace TrainingApp.Facade.Reservation {

    public static class ReservationViewFactory
    {
        public static ReservationDomain Create(ReservationView view)
        {
            var d = new ReservationData();
            Copy.Members(view, d);
            return new ReservationDomain(d);
        }

        public static ReservationView Create(ReservationDomain obj)
        {
            var v = new ReservationView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
