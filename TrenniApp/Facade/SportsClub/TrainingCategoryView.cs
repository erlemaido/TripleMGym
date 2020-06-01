using TrainingApp.Facade.Common;

namespace TrainingApp.Facade.SportsClub
{
    public sealed class TrainingCategoryView : NamedEntityView
    {
        public string GetId()
        {
            return Id;
        }
    }
}
