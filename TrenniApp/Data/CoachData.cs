using System;
using TrainingApp.Data.Common;

namespace TrainingApp.Data
{
    public sealed class CoachData : DefinedEntityData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public string? CoachCertificateNumber { get; set; }
    }
}
