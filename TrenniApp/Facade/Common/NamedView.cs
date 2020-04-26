using System.ComponentModel.DataAnnotations;

namespace North.Facade.Common
{
    public abstract class NamedView :UniqueEntityView
    {
        [Required]
        public string Name { get; set; }
    }
}
