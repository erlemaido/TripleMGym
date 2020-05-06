using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Pages.SportsClub
{
    //public class TrainingsPage : CommonPage<ITrainingsRepository, Training, TrainingView, TrainingData>
    //{
    //    protected internal TrainingsPage(ITrainingsRepository r, ITrainingCategoriesRepository m) : base(r)
    //    {
    //        PageTitle = "Trainings";
    //        TrainingCategories = CreateSelectList<TrainingCategory, TrainingCategoryData>(m);

    //    }
    //    public IEnumerable<SelectListItem> TrainingCategories { get; }
    //    //public override string ItemId => Item is null ? string.Empty : $"{Item.TrainingCategoryId}";
    //    protected internal override string GetPageUrl() => "/Quantity/MeasureTerms";
    //    protected internal override Training ToObject(TrainingView view)
    //    {
    //        return TrainingViewFactory.Create(view);
    //    }

    //    protected internal override TrainingView ToView(Training obj)
    //    {
    //        return TrainingViewFactory.Create(obj);
    //    }

        //public string GetMeasureName(string measureId)
        //{
        //    foreach (var m in TrainingCategories)
        //        if (m.Value == measureId)
        //            return m.Text;
        //    return "Unspecified";

        //}
        //protected internal override string GetPageSubTitle()
        //{
        //    return FixedValue is null ? base.GetPageSubTitle() : $"For{GetMeasureName(FixedValue)}";
        //}

}
