using TrainingApp.Facade.Common;

namespace TrainingApp.Facade.SportsClub
{
    public sealed class TrainingTypeView : NamedEntityView
    {
        public string GetId()
        {
            return Id;
        }
    }
}
