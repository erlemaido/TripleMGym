using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Data.Reservation;
using TrainingApp.Domain.Reservation;

namespace TrainingApp.Infra.Reservation
{
    public sealed class ReservationsRepository : UniqueEntityRepository<ReservationDomain,ReservationData>, IReservationsRepository
    {
        public ReservationsRepository(TrainingAppDbContext c) : base(c, c.Reservations) { }
        protected internal override ReservationDomain ToDomainObject(ReservationData d) => new ReservationDomain(d);

        public object GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
