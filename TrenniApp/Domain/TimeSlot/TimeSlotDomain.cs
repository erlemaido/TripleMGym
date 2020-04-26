using System;
using TrainingApp.Data.Common;
using TrainingApp.Data.TimeSlot;
using TrainingApp.Domain.Common;

namespace TrainingApp.Domain.TimeSlot
{
    public sealed class TimeSlotDomain : Entity<TimeSlotData>
    {
        public TimeSlotDomain() : this(null) { }

        public TimeSlotDomain(TimeSlotData data) : base(data) { }
    }
}
