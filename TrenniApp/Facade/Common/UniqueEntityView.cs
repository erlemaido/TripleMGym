using System.ComponentModel.DataAnnotations;

namespace North.Facade.Common
{
    public abstract class UniqueEntityView
    {
        [Required]
        public string Id { get; set; }
    }
}
