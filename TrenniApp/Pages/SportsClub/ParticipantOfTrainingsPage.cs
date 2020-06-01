using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Pages.SportsClub
{
    public abstract class ParticipantOfTrainingsPage : CommonPage<IParticipantOfTrainingsRepository, ParticipantOfTraining, ParticipantOfTrainingView, ParticipantOfTrainingData>
    {
        public IEnumerable<SelectListItem> TimetableEntries { get; }
        public IEnumerable<SelectListItem> Clients { get; }

        protected internal ParticipantOfTrainingsPage(IParticipantOfTrainingsRepository participantsRepository, 
            ITimetableEntriesRepository timetableEntriesRepository, IClientsRepository clientsRepository) : base(participantsRepository)
        {
            PageTitle = "Broneeringud";
            TimetableEntries = CreateSelectList<TimetableEntry, TimetableEntryData>(timetableEntriesRepository);
            Clients = CreateSelectList<Client, ClientData>(clientsRepository);

        }

        public override string ItemId => Item is null ? string.Empty : $"{Item.ClientId}.{Item.TimetableEntryId}";
       
        protected internal override string GetPageUrl() => "/SportsClub/ParticipantOfTrainings";

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
                if (m.Value ==clientId)
                    return m.Text;
            }

            return "Määramata";
        }

        public string GetTimetableEntryName(string timetableId)
        {
            foreach (var m in TimetableEntries)
            {
                if (m.Value == timetableId)
                    return m.Text;
            }

            return "Määramata";
        }

        protected internal override string GetPageSubTitle()
        {
            if (!GetClientName(FixedValue).Equals("Määramata"))
            {
                return FixedValue is null ? base.GetPageSubTitle() : $"{GetClientName(FixedValue)}";
            } 
            if (!GetTimetableEntryName(FixedValue).Equals("Määramata"))
            {
                return FixedValue is null ? base.GetPageSubTitle() : $"{GetTimetableEntryName(FixedValue)}";
            }

            return base.GetPageSubTitle();
        }
    }
}
