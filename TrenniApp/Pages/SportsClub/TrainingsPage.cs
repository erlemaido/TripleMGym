using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Pages.SportsClub
{
    public abstract class TrainingsPage : CommonPage<ITrainingsRepository, Training, TrainingView, TrainingData>
    {
        protected internal readonly ITimetableEntriesRepository timetableTrainings;
        public IList<TimetableEntryView> TimetableTrainings { get; }
        public IEnumerable<SelectListItem> TrainingCategories { get; }

        protected internal TrainingsPage(ITrainingsRepository r, ITimetableEntriesRepository t, ITrainingCategoriesRepository tc) : base(r)
        {
            PageTitle = "Trainings";
            TimetableTrainings = new List<TimetableEntryView>();
            timetableTrainings = t;
            TrainingCategories = CreateSelectList<TrainingCategory, TrainingCategoryData>(tc);
        }

        public override string ItemId => Item.Id;

        protected internal override string GetPageUrl() => "/SportsClub/Trainings";

        protected internal override Training ToObject(TrainingView view)
        {
            return TrainingViewFactory.Create(view);
        }

        protected internal override TrainingView ToView(Training obj)
        {
            return TrainingViewFactory.Create(obj);
        }

        public void LoadDetails(TrainingView item)
        {
            TimetableTrainings.Clear();

            if (item is null) return;
            timetableTrainings.FixedFilter = GetMember.Name<TimetableEntryData>(x => x.TrainingId);
            timetableTrainings.FixedValue = item.Id;
            var list = timetableTrainings.Get().GetAwaiter().GetResult();

            foreach (var e in list)
            {
                TimetableTrainings.Add(TimetableEntryViewFactory.Create(e));
            }
        }
    }
}
