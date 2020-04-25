using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Data.Common;

namespace TrainingApp.Data.Sport
{
    public sealed class ReservationData : UniqueEntityData
    {
        public string TrainingId { get; set; }
        public string TrainerId { get; set; }
        public string SportsClubId { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
