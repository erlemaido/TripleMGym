using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingApp.Aids;
using TrainingApp.Data.Common;
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
            PageTitle = "Timetable";
            Participants = new List<ParticipantOfTrainingView>();
            participants = p;
            Trainings = CreateTrainingsSelectList<Training>(t);
            Coaches = CreateCoachesSelectList<Coach>(c);
            Locations = CreateLocationsSelectList<Location>(l);
            TrainingTypes = CreateTrainingTypesSelectList<TrainingType>(tt);
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

        protected internal override string GetPageSubTitle()
        {
            //hack, mis tuleks ilusaks teha
            var coaches = GetNameFromId(FixedValue, Coaches);
            var trainings = GetNameFromId(FixedValue, Trainings);
            if (coaches.Equals("Unspecified"))
            {
                return FixedValue is null ? base.GetPageSubTitle() : $"For {trainings}";
            }
            return FixedValue is null ? base.GetPageSubTitle() : $"For {coaches}";
        }


        public void LoadDetails(ClientView item)
        {
            Participants.Clear();

            if (item is null) return;
            participants.FixedFilter = GetMember.Name<ParticipantOfTrainingData>(x => x.ClientId);
            participants.FixedValue = item.Id;
            var list = participants.Get().GetAwaiter().GetResult();

            foreach (var e in list)
            {
                Participants.Add(ParticipantOfTrainingViewFactory.Create(e));
            }
        }

        private IEnumerable<SelectListItem> CreateTrainingsSelectList<Training>(IRepository<Training> r)
            where Training : Entity<TrainingData>, new()
        {
            var items = r.Get().GetAwaiter().GetResult();

            return items.Select(m => new SelectListItem(m.Data.Title, m.Data.Id)).ToList();
        }

        private IEnumerable<SelectListItem> CreateCoachesSelectList<Coach>(IRepository<Coach> r)
            where Coach : Entity<CoachData>, new()
        {
            var items = r.Get().GetAwaiter().GetResult();

            return items.Select(m => new SelectListItem(m.Data.FirstName + " " + m.Data.LastName, m.Data.Id)).ToList();
        }

        private IEnumerable<SelectListItem> CreateLocationsSelectList<Location>(IRepository<Location> r)
            where Location : Entity<LocationData>, new()
        {
            var items = r.Get().GetAwaiter().GetResult();

            return items.Select(m => new SelectListItem(m.Data.Code, m.Data.Id)).ToList();
        }

        private IEnumerable<SelectListItem> CreateTrainingTypesSelectList<TrainingType>(IRepository<TrainingType> r)
            where TrainingType : Entity<TrainingTypeData>, new()
        {
            var items = r.Get().GetAwaiter().GetResult();

            return items.Select(m => new SelectListItem(m.Data.Type, m.Data.Id)).ToList();
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

