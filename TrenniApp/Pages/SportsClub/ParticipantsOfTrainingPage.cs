using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Pages.SportsClub
{
    public class ParticipantsOfTrainingPage : CommonPage<IParticipantsOfTrainingRepository,ParticipantOfTraining,ParticipantOfTrainingView, ParticipantOfTrainingData>
    {
        protected internal ParticipantsOfTrainingPage(IParticipantsOfTrainingRepository r,
            ITimetableEntriesRepository u) : base(r)
        {
            PageTitle = "Participants of trainings";
            //TimeTableEntries = CreateSelectList<TimetableEntry, TimetableEntryData>(u);
        }
        public IEnumerable<SelectListItem> TimeTableEntries { get; }
        public override string ItemId => Item is null ? string.Empty : $"{Item.ClientId}.{Item.CoachId}.{Item.RegistrationTime}.{Item.TimetableEntryId}";
        protected internal override string GetPageUrl() => "/SportsClub/ParticipantsOfTraining";

        protected internal override ParticipantOfTraining ToObject(ParticipantOfTrainingView view)
        {
            return ParticipantOfTrainingViewFactory.Create(view);
        }

        protected internal override ParticipantOfTrainingView ToView(ParticipantOfTraining obj)
        {
            return ParticipantOfTrainingViewFactory.Create(obj);
        }

    }
}
