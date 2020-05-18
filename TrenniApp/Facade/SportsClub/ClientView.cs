using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TrainingApp.Facade.Common;

namespace TrainingApp.Facade.SportsClub
{
    public sealed class ClientView : NamedEntityView
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Liitumise kuupäev")]
        public DateTime DateOfJoining { get; set; }
    }
}
