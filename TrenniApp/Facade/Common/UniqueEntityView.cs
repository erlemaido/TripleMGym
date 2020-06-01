using System.ComponentModel.DataAnnotations;

namespace TrainingApp.Facade.Common
{
    public abstract class UniqueEntityView : PeriodView
    {
        [Required]
        public string Id { get; set; }
    }
}
