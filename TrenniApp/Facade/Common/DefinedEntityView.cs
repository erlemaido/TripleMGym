using System.ComponentModel.DataAnnotations;

namespace TrainingApp.Facade.Common
{
    public abstract class DefinedEntityView : UniqueEntityView
    {
        [Required]
        public string Description { get; set; }
    }
}
