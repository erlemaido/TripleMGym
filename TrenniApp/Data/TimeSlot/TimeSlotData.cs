using System;
using TrainingApp.Data.Common;

namespace TrainingApp.Data.TimeSlot
{
    public sealed class TimeSlotData : UniqueEntityData
    {
        public DateTime StartTime { get; set; }
        public TimeSlotType TimeSlotType { get; set; }

    }
}
