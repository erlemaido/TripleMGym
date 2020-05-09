using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Pages.SportsClub
{
    public abstract class TimeTableEntriesPage : CommonPage<ITimetableEntriesRepository, TimetableEntry,
        TimetableEntryView, TimetableEntryData>
    {
        protected internal readonly IParticipantsOfTrainingRepository participants;

        protected internal TimeTableEntriesPage(ITimetableEntriesRepository e, IParticipantsOfTrainingRepository p,
            ILocationsRepository l, ICoachesRepository c, ITrainingsRepository t, ITrainingTypesRepository s) :  base(e)
        {
            PageTitle = "Timetable Entries";
            Participants = new List<ParticipantOfTrainingView>();

        }

        public IList<ParticipantOfTrainingView> Participants { get; }

    }
}
