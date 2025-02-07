﻿using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Pages.SportsClub
{
    public abstract class TrainingCategoriesPage : CommonPage<ITrainingCategoriesRepository, TrainingCategory, TrainingCategoryView, TrainingCategoryData>
    {
        protected internal TrainingCategoriesPage(ITrainingCategoriesRepository trainingCategoriesRepository) : base(trainingCategoriesRepository)
        {
            PageTitle = "Trenni kategooriad";
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
