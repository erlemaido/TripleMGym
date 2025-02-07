﻿using System;
using TrainingApp.Data.Common;

namespace TrainingApp.Data.SportsClub
{
    public sealed class CoachData : DefinedEntityData
    {
        public int Age { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public string CoachCertificateNumber { get; set; }
    }
}
