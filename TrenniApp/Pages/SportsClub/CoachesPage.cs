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
        public IList<TimetableEntryView> TimetableEntries { get; }
        public IEnumerable<SelectListItem> Trainings { get; }

        public IEnumerable<SelectListItem> Locations { get; }

        public IEnumerable<SelectListItem> TrainingTypes { get; }
        protected internal readonly ITimetableEntriesRepository timetableEntries;

        protected internal CoachesPage(ICoachesRepository c, ITimetableEntriesRepository te, ITrainingsRepository t, ILocationsRepository l, ITrainingTypesRepository tt) : base(c)
        {
            PageTitle = "Treenerid";
            TimetableEntries = new List<TimetableEntryView>();
            Trainings = CreateSelectList<Training, TrainingData>(t);
            Locations = CreateSelectList<Location, LocationData>(l);
            TrainingTypes = CreateSelectList<TrainingType, TrainingTypeData>(tt);
            timetableEntries = te;
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
        
        public string GetTrainingName(string trainingId)
        {
            foreach (var m in Trainings)
            {
                if (m.Value == trainingId)
                    return m.Text;
            }

            return "Määramata";
        }

        public string GetTrainingTypeName(string trainingTypeId)
        {
            foreach (var m in TrainingTypes)
            {
                if (m.Value == trainingTypeId)
                    return m.Text;
            }

            return "Määramata";
        }

        public string GetLocationName(string locationId)
        {
            foreach (var m in Locations)
            {
                if (m.Value == locationId)
                    return m.Text;
            }

            return "Määramata";
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

