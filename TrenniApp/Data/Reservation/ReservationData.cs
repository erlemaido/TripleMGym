using System;
using TrainingApp.Data.Common;

namespace TrainingApp.Data.Reservation
{
    public sealed class ReservationData : UniqueEntityData
    {
        public string TrainingId { get; set; }
        public string TrainerId { get; set; }
        public string SportsClubId { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
