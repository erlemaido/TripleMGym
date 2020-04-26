using System;
using TrainingApp.Data.Common;
using TrainingApp.Data.Reservation;
using TrainingApp.Data.Training;
using TrainingApp.Domain.Common;

namespace TrainingApp.Domain.Reservation
{
    public sealed class ReservationDomain : Entity<ReservationData>
    {
        public ReservationDomain() : this(null) { }

        public ReservationDomain(ReservationData data) : base(data) { }
    }
}
