using System.ComponentModel.DataAnnotations;
using TrainingApp.Facade.Common;

namespace TrainingApp.Facade.SportsClub
{
    public sealed class LocationView : UniqueEntityView
    {
        [Required]
        public string Code { get; set; }
    }
}
