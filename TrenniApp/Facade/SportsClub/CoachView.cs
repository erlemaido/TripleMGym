using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TrainingApp.Facade.Common;

namespace TrainingApp.Facade.SportsClub
{
    public sealed class CoachView : DefinedEntityView
    {
        [Required]
        public int Age { get; set; }

        [Required]
        public string Email { get; set; }

        [DisplayName("Treeneri sertifikaadi number")]
        public string CoachCertificateNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Töö alustamise kuupäev")]
        public DateTime HireDate { get; set; }
    }
}
