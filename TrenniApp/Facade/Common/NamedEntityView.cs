using System.ComponentModel.DataAnnotations;

namespace TrainingApp.Facade.Common
{
    public abstract class NamedEntityView : DefinedEntityView
    {
        [Required]
        public string Name { get; set; }
    }
}
