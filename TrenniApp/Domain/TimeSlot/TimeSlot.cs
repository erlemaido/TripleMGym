using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Data.Common;

namespace TrainingApp.Data.Sport
{
    public sealed class TimeSlot : UniqueEntityData
    {
        public DateTime StartTime { get; set; }
        public TimeSlotType TimeSlotType { get; set; }

    }
}
