using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TrainingApp.Facade.Common
{
    public abstract class NamedEntityView : UniqueEntityView
    {
        [Required]
        [DisplayName("Nimi")]
        public string Name { get; set; }
    }
}
