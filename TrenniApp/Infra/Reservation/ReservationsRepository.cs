using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Data.Reservation;

namespace TrainingApp.Infra.Reservation
{
    public sealed class ReservationsRepository : UniqueEntityRepository<Reservation,ReservationData>, IReservationsRepository
    {
        public ReservationsRepository(TrainingAppDbContext c) : base(c, c.Reservations) { }
        protected internal override Reservation toDomainObject(ReservationData d) => new Reservation(d);

    }
}
