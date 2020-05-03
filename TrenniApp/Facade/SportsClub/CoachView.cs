using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TrainingApp.Facade.Common;

namespace TrainingApp.Facade.SportsClub
{
    public sealed class CoachView : DefinedEntityView
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Email { get; set; }

        [DisplayName("Coach Certificate Number")]
        public string CoachCertificateNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Hire Date")]
        public DateTime HireDate { get; set; }
    }
}
