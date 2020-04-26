using System.ComponentModel.DataAnnotations;

namespace TrainingApp.Facade.Common
{
    public abstract class UniqueEntityView
    {
        [Required]
        public string Id { get; set; }
    }
}
