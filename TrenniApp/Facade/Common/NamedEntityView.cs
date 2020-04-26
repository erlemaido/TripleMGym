using System.ComponentModel.DataAnnotations;

namespace TrainingApp.Facade.Common
{
    public abstract class NamedEntityView : DefinedEntityView
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
