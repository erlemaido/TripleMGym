using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Pages.SportsClub
{
    public class ParticipantsOfTrainingPage : CommonPage<IParticipantsOfTrainingRepository, ParticipantOfTraining, ParticipantOfTrainingView, ParticipantOfTrainingData>
    {
        protected internal ParticipantsOfTrainingPage(IParticipantsOfTrainingRepository r,
            ITimetableEntriesRepository t, IClientsRepository cl, ICoachesRepository co) : base(r)
        {
            PageTitle = "Participant of Trainings";
            TimetableEntries = CreateSelectList<TimetableEntry, TimetableEntryData>(t);
            Clients = CreateSelectList<Client, ClientData>(cl);
            Coaches = CreateSelectList<Coach, CoachData>(co);
        }
        public IEnumerable<SelectListItem> TimetableEntries { get; }
        public IEnumerable<SelectListItem> Clients { get; }
        public IEnumerable<SelectListItem> Coaches { get; }

        public override string ItemId => Item is null ? string.Empty : Item.GetId();
        protected internal override string GetPageUrl() => "/SportsClub/ParticipantsOfTraining";

        protected internal override ParticipantOfTraining ToObject(ParticipantOfTrainingView view)
        {
            return ParticipantOfTrainingViewFactory.Create(view);
        }

        protected internal override ParticipantOfTrainingView ToView(ParticipantOfTraining obj)
        {
            return ParticipantOfTrainingViewFactory.Create(obj);
        }

        public string GetClientName(string clientId)
        {
            foreach (var m in Clients)
            {
                if (m.Value == clientId)
                    return m.Text;
            }

            return "Unspecified";
        }

        protected internal override string GetPageSubTitle()
        {
            return FixedValue is null ? base.GetPageSubTitle() : $"For {GetClientName(FixedValue)}";
        }

    }
}
