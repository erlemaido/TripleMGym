using System;
using TrainingApp.Data.Common;

namespace TrainingApp.Domain.TimeSlot
{
    public sealed class TimeSlot : UniqueEntityData
    {
        public DateTime StartTime { get; set; }
        public TimeSlotType TimeSlotType { get; set; }

    }
}
