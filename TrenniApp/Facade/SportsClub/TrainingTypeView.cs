using System.ComponentModel.DataAnnotations;
using TrainingApp.Facade.Common;

namespace TrainingApp.Facade.SportsClub
{
    public sealed class TrainingTypeView : UniqueEntityView
    {
        [Required]
        public string Type { get; set; }
    }
}
