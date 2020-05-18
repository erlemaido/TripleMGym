using System.ComponentModel;

namespace TrainingApp.Facade.Common
{
    public abstract class DefinedEntityView : NamedEntityView
    {
        [DisplayName("Kirjeldus")]
        public string Description { get; set; }
    }
}
