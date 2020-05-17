using System;
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
    public class TimeTableEntriesPage : CommonPage<ITimetableEntriesRepository, TimetableEntry, TimetableEntryView, TimetableEntryData>
    {
        protected internal readonly IParticipantOfTrainingsRepository participants;
        protected internal TimeTableEntriesPage(ITimetableEntriesRepository r, IParticipantOfTrainingsRepository p, 
            ITrainingsRepository t, ICoachesRepository c, ILocationsRepository l, ITrainingTypesRepository tt) : base(r)
        {
            PageTitle = "Tunniplaan";
            Participants = new List<ParticipantOfTrainingView>();
            participants = p;
            Trainings = CreateSelectList<Training, TrainingData>(t);
            Coaches = CreateSelectList<Coach, CoachData>(c);
            Locations = CreateSelectList<Location, LocationData>(l);
            TrainingTypes = CreateSelectList<TrainingType, TrainingTypeData>(tt);
            TrainingLevels = CreateTrainingLevelsSelectList<TrainingLevel>();

        }
        public IList<ParticipantOfTrainingView> Participants { get; }
        public IEnumerable<SelectListItem> Trainings { get; }

        public IEnumerable<SelectListItem> Coaches { get; }

        public IEnumerable<SelectListItem> Locations { get; }

        public IEnumerable<SelectListItem> TrainingTypes { get; }

        public IEnumerable<SelectListItem> TrainingLevels { get; }

        public override string ItemId => Item.Id;
        protected internal override string GetPageUrl() => "/SportsClub/TimetableEntries";
        
        protected internal override TimetableEntry ToObject(TimetableEntryView view)
        {
            return TimetableEntryViewFactory.Create(view);
        }

        protected internal override TimetableEntryView ToView(TimetableEntry obj)
        {
            return TimetableEntryViewFactory.Create(obj);
        }

        public string GetCoachName(string coachId)
        {
            foreach (var m in Coaches)
            {
                if (m.Value == coachId)
                    return m.Text;
            }

            return "Unspecified";
        }

        public string GetTrainingName(string trainingId)
        {
            foreach (var m in Trainings)
            {
                if (m.Value == trainingId)
                    return m.Text;
            }

            return "Unspecified";
        }

        protected internal override string GetPageSubTitle()
        {
            if (!GetCoachName(FixedValue).Equals("Unspecified"))
            {
                return FixedValue is null ? base.GetPageSubTitle() : $"For {GetCoachName(FixedValue)}";
            } 
            else if (!GetTrainingName(FixedValue).Equals("Unspecified"))
            {
                return FixedValue is null ? base.GetPageSubTitle() : $"For {GetTrainingName(FixedValue)}";
            }

            return base.GetPageSubTitle();

        }


        public void LoadDetails(TimetableEntryView item)
        {
            Participants.Clear();

            if (item is null) return;
            participants.FixedFilter = GetMember.Name<ParticipantOfTrainingData>(x => x.TimetableEntryId);
            participants.FixedValue = item.Id;
            var list = participants.Get().GetAwaiter().GetResult();

            foreach (var e in list)
            {
                Participants.Add(ParticipantOfTrainingViewFactory.Create(e));
            }
        }

        private IEnumerable<SelectListItem> CreateTrainingLevelsSelectList<TrainingLevel>()
        {
            var items = new SelectList(Enum.GetValues(typeof(TrainingLevel)).Cast<TrainingLevel>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = Convert.ToInt32(v).ToString()
            }).ToList(), "Value", "Text");

            return items;
        }

    }
}

