﻿using System;
using TrainingApp.Data.Common;

namespace TrainingApp.Data
{
    public sealed class ParticipantOfTrainingData : UniqueEntityData
    {
        public string ClientId { get; set; }
        public string CoachTrainingId { get; set; }
        public DateTime RegistrationTime { get; set; }
    }
}
