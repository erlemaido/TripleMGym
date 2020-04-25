using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Data.Common;

namespace TrainingApp.Data.Sport
{
    public sealed class TimeSlotData : UniqueEntityData
    {
        public DateTime StartTime { get; set; }
        public TimeSlotType TimeSlotType { get; set; }

    }
}
