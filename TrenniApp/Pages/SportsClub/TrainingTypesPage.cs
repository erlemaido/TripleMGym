﻿using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Pages.SportsClub
{
    public abstract class TrainingTypesPage : CommonPage<ITrainingTypesRepository, TrainingType, TrainingTypeView, TrainingTypeData>
    {
        protected internal TrainingTypesPage(ITrainingTypesRepository trainingTypesRepository) : base(trainingTypesRepository)
        {
            PageTitle = "Trenni tüübid";
        }

        public override string ItemId => Item.Id;

        protected internal override string GetPageUrl() => "/SportsClub/TrainingTypes";

        protected internal override TrainingType ToObject(TrainingTypeView view)
        {
            return TrainingTypeViewFactory.Create(view);
        }

        protected internal override TrainingTypeView ToView(TrainingType obj)
        {
            return TrainingTypeViewFactory.Create(obj);
        }
    }
}
