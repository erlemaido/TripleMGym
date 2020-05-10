using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Pages.SportsClub
{
    public class TrainingCategoriesPage : CommonPage<ITrainingCategoriesRepository, TrainingCategory, TrainingCategoryView, TrainingCategoryData>
    {

        protected internal TrainingCategoriesPage(ITrainingCategoriesRepository r) : base(r)
        {
            PageTitle = "Training Categories";
        }

        public override string ItemId => Item.Id;

        protected internal override string GetPageUrl() => "/SportsClub/TrainingCategories";

        protected internal override TrainingCategory ToObject(TrainingCategoryView view)
        {
            return TrainingCategoryViewFactory.Create(view);
        }

        protected internal override TrainingCategoryView ToView(TrainingCategory obj)
        {
            return TrainingCategoryViewFactory.Create(obj);
        }

    }
}
