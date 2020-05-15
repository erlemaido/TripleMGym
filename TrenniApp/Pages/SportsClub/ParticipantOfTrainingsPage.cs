using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.Common;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Pages.SportsClub
{
    public class ParticipantOfTrainingsPage : CommonPage<IParticipantOfTrainingsRepository, ParticipantOfTraining, ParticipantOfTrainingView, ParticipantOfTrainingData>
    {
        protected internal ParticipantOfTrainingsPage(IParticipantOfTrainingsRepository r,
            ITimetableEntriesRepository t, IClientsRepository cl) : base(r)
        {
            PageTitle = "Participant of Trainings";
            TimetableEntries = CreateTrainingsSelectList<TimetableEntry>(t);
            Clients = CreateClientsSelectList<Client>(cl);
        }
        public IEnumerable<SelectListItem> TimetableEntries { get; }
        public IEnumerable<SelectListItem> Clients { get; }

        public override string ItemId => Item.Id;
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
                if (m.Value == clientId)
                    return m.Text;
            }

            return "Unspecified";
        }

        protected internal override string GetPageSubTitle()
        {
            return FixedValue is null ? base.GetPageSubTitle() : $"For {GetClientName(FixedValue)}";
        }

        private IEnumerable<SelectListItem> CreateTrainingsSelectList<TimetableEntry>(IRepository<TimetableEntry> r)
            where TimetableEntry : Entity<TimetableEntryData>, new()
        {
            var items = r.Get().GetAwaiter().GetResult();

            return items.Select(m => new SelectListItem(m.Data.Id, m.Data.Id)).ToList();
        }

        private IEnumerable<SelectListItem> CreateClientsSelectList<Client>(IRepository<Client> r)
            where Client : Entity<ClientData>, new()
        {
            var items = r.Get().GetAwaiter().GetResult();

            return items.Select(m => new SelectListItem(m.Data.FirstName + " " + m.Data.LastName, m.Data.Id)).ToList();
        }

    }
}
