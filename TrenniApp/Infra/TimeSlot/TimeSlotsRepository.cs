using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Data.TimeSlot;

namespace TrainingApp.Infra.TimeSlot
{
    public sealed class TimeSlotsRepository : UniqueEntityRepository<TimeSlot, TimeSlotData>, ITimeslotsRepository
    {
        public TimeSlotsRepository(TrainingAppDbContext c) : base(c, c.Timeslots) { }

        protected internal override TimeSlot toDomainObject(TimeSlotData d) => new TimeSlot(d);

    }
}
