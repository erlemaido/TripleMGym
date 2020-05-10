using System.Collections.Generic;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Pages.SportsClub
{
    public abstract class CoachesPage : CommonPage<ICoachesRepository, Coach, CoachView, CoachData>
    {
        protected internal readonly ITimetableEntriesRepository timetableTrainings;
        public IList<TimetableEntryView> TimetableTrainings { get; }

        protected internal CoachesPage(ICoachesRepository r, ITimetableEntriesRepository t) : base(r)
        {
            PageTitle = "Coaches";
            TimetableTrainings = new List<TimetableEntryView>();
            timetableTrainings = t;
        }

        public override string ItemId => Item.Id;

        protected internal override string GetPageUrl() => "/SportsClub/Coaches";

        protected internal override Coach ToObject(CoachView view)
        {
            return CoachViewFactory.Create(view);
        }

        protected internal override CoachView ToView(Coach obj)
        {
            return CoachViewFactory.Create(obj);
        }

        public void LoadDetails(CoachView item)
        {
            TimetableTrainings.Clear();

            if (item is null) return;
            timetableTrainings.FixedFilter = GetMember.Name<TimetableEntryData>(x => x.CoachId);
            timetableTrainings.FixedValue = item.Id;
            var list = timetableTrainings.Get().GetAwaiter().GetResult();

            foreach (var e in list)
            {
                TimetableTrainings.Add(TimetableEntryViewFactory.Create(e));
            }
        }
    }
}

