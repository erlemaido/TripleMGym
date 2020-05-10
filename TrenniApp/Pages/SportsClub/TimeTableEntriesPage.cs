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
        protected internal readonly IParticipantsOfTrainingRepository participants;
        protected internal TimeTableEntriesPage(ITimetableEntriesRepository r, IParticipantsOfTrainingRepository p, ITrainingsRepository t, ICoachesRepository c) : base(r)
        {
            PageTitle = "Timetable";
            Participants = new List<ParticipantOfTrainingView>();
            participants = p;
            Trainings = CreateSelectList<Training, TrainingData>(t);
            Coaches = CreateSelectList<Coach, CoachData>(c);

        }
        public IList<ParticipantOfTrainingView> Participants { get; }
        public IEnumerable<SelectListItem> Trainings { get; }

        public IEnumerable<SelectListItem> Coaches { get; }

        public override string ItemId => Item is null ? string.Empty : Item.GetId();
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
            return FixedValue is null
                ? base.GetPageSubTitle()
                : $"For {GetTrainingName(FixedValue)}";
        }

        public string GetTrainingName(string trainingId)
        {
            foreach (var m in Trainings)
                if (m.Value == trainingId)
                    return m.Text;
            return "Unspecified";
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

    }
}

