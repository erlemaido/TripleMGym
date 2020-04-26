using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Data.TimeSlot;
using TrainingApp.Domain.TimeSlot;

namespace TrainingApp.Infra.TimeSlot
{
    public sealed class TimeSlotsRepository : UniqueEntityRepository<TimeSlotDomain, TimeSlotData>, ITimeSlotsRepository
    {
        public TimeSlotsRepository(TrainingAppDbContext c) : base(c, c.TimeSlots) { }

        protected internal override TimeSlotDomain ToDomainObject(TimeSlotData d) => new TimeSlotDomain(d);

        public object GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
