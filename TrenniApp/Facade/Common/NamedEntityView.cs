using System.ComponentModel.DataAnnotations;

namespace TrainingApp.Facade.Common
{
    public abstract class NamedEntityView : UniqueEntityView
    {
        [Required]
        public string Name { get; set; }
    }
}
