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
        public IList<ParticipantOfTrainingView> Participants { get; }
        public IEnumerable<SelectListItem> Trainings { get; }

        public IEnumerable<SelectListItem> Coaches { get; }

        public IEnumerable<SelectListItem> Locations { get; }

        public IEnumerable<SelectListItem> TrainingTypes { get; }

        public IEnumerable<SelectListItem> TrainingLevels { get; }
        public IEnumerable<SelectListItem> Clients { get; }
        protected internal readonly IParticipantOfTrainingsRepository participants;

        protected internal TimeTableEntriesPage(ITimetableEntriesRepository r, IParticipantOfTrainingsRepository p, 
            ITrainingsRepository t, ICoachesRepository c, ILocationsRepository l, ITrainingTypesRepository tt, IClientsRepository cl) : base(r)
        {
            PageTitle = "Tunniplaan";
            Participants = new List<ParticipantOfTrainingView>();
            participants = p;
            Trainings = CreateSelectList<Training, TrainingData>(t);
            Coaches = CreateSelectList<Coach, CoachData>(c);
            Locations = CreateSelectList<Location, LocationData>(l);
            TrainingTypes = CreateSelectList<TrainingType, TrainingTypeData>(tt);
            TrainingLevels = CreateTrainingLevelsSelectList<TrainingLevel>();
            Clients = CreateSelectList<Client, ClientData>(cl);
        }


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

            return "Määramata";
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
        
        public string GetClientName(string clientId)
        {
            foreach (var m in Clients)
            {
                if (m.Value == clientId)
                    return m.Text;
            }

            return "Määramata";
        }


        protected internal override string GetPageSubTitle()
        {
            if (!GetCoachName(FixedValue).Equals("Määramata"))
            {
                return FixedValue is null ? base.GetPageSubTitle() : $"{GetCoachName(FixedValue)}";
            } 
            if (!GetTrainingName(FixedValue).Equals("Määramata"))
            {
                return FixedValue is null ? base.GetPageSubTitle() : $"{GetTrainingName(FixedValue)}";
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

        private static IEnumerable<SelectListItem> CreateTrainingLevelsSelectList<TrainingLevel>()
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

