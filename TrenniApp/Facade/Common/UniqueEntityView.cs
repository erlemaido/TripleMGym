using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingApp.Facade.Common
{
    public abstract class UniqueEntityView
    {
        public string Id { get; set; }
    }
}
