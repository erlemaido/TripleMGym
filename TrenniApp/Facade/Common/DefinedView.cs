using System.ComponentModel.DataAnnotations;

namespace North.Facade.Common
{
    public abstract class DefinedView :NamedView
    {
        [Required]
        public string Definition { get; set; }
    }
}
