using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.Common;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Pages.SportsClub
{
    public abstract class CoachesPage : CommonPage<ICoachesRepository, Coach, CoachView, CoachData>
    {
        protected internal readonly ITimetableEntriesRepository timetableEntries;

        protected internal CoachesPage(ICoachesRepository c, ITimetableEntriesRepository t) : base(c)
        {
            PageTitle = "Treenerid";
            TimetableEntries = new List<TimetableEntryView>();
            timetableEntries = t;
            //Trainings = CreateTrainingsSelectList<Training>(tr);
            //Coaches = CreateCoachesSelectList<Coach>(c);
            //Locations = CreateLocationsSelectList<Location>(l);
            //TrainingTypes = CreateTrainingTypesSelectList<TrainingType>(tt);
        }

        public IList<TimetableEntryView> TimetableEntries { get; }

        //public IEnumerable<SelectListItem> Trainings { get; }

        //public IEnumerable<SelectListItem> Coaches { get; }

        //public IEnumerable<SelectListItem> Locations { get; }

        //public IEnumerable<SelectListItem> TrainingTypes { get; }

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
            TimetableEntries.Clear();

            if (item is null) return;
            timetableEntries.FixedFilter = GetMember.Name<TimetableEntryData>(x => x.CoachId);
            timetableEntries.FixedValue = item.Id;
            var list = timetableEntries.Get().GetAwaiter().GetResult();

            foreach (var e in list)
            {
                TimetableEntries.Add(TimetableEntryViewFactory.Create(e));
            }
        }
    }
}

