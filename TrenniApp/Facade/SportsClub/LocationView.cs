using System.ComponentModel.DataAnnotations;
using TrainingApp.Facade.Common;

namespace TrainingApp.Facade.SportsClub
{
    public sealed class LocationView : NamedEntityView
    {
        public string GetId()
        {
            return Id;
        }
    }
}
