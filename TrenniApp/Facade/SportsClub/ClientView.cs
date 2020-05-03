using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TrainingApp.Facade.Common;

namespace TrainingApp.Facade.SportsClub
{
    public sealed class ClientView : UniqueEntityView
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("ID Code")]
        public string IdCode { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date of Joining")]
        public DateTime DateOfJoining { get; set; }
    }
}
