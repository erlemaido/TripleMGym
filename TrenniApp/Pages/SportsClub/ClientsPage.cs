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
    public abstract class ClientsPage : CommonPage<IClientsRepository, Client, ClientView, ClientData>
    {
        protected internal readonly IParticipantOfTrainingsRepository trainings;
        public IList<ParticipantOfTrainingView> Trainings { get; }

        protected internal ClientsPage(IClientsRepository r, IParticipantOfTrainingsRepository p, ITimetableEntriesRepository t, ITrainingsRepository tr) : base(r)
        {
            PageTitle = "Clients";
            Trainings = new List<ParticipantOfTrainingView>();
            trainings = p;
            TimetableEntries = CreateTimetableEntriesSelectList<TimetableEntry>(t);
            Clients = CreateClientsSelectList<Client>(r);
            Trainings2 = CreateTrainingsSelectList<Training>(tr);
        }

        protected ClientsPage(IClientsRepository r, IParticipantOfTrainingsRepository p) : base(r)
        {
            PageTitle = "Clients";
            Trainings = new List<ParticipantOfTrainingView>();
            trainings = p;
        }

        public IEnumerable<SelectListItem> TimetableEntries { get; }
        public IEnumerable<SelectListItem> Clients { get; }
        public IEnumerable<SelectListItem> Trainings2 { get; }

        public override string ItemId => Item.Id;

        protected internal override string GetPageUrl() => "/SportsClub/Clients";

        protected internal override Client ToObject(ClientView view)
        {
            return ClientViewFactory.Create(view);
        }

        protected internal override ClientView ToView(Client obj)
        {
            return ClientViewFactory.Create(obj);
        }

        public void LoadDetails(ClientView item)
        {
            Trainings.Clear();

            if (item is null) return;
            trainings.FixedFilter = GetMember.Name<ParticipantOfTrainingData>(x => x.ClientId);
            trainings.FixedValue = item.Id;
            var list = trainings.Get().GetAwaiter().GetResult();

            foreach (var e in list)
            {
                Trainings.Add(ParticipantOfTrainingViewFactory.Create(e));
            }
        }
        private IEnumerable<SelectListItem> CreateTimetableEntriesSelectList<TimetableEntry>(IRepository<TimetableEntry> r)
            where TimetableEntry : Entity<TimetableEntryData>, new()
        {
            var items = r.Get().GetAwaiter().GetResult();

            return items.Select(m => new SelectListItem(GetNameFromId(m.Data.TrainingId, Trainings2) + " " + m.Data.StartTime + " - " + m.Data.EndTime, m.Data.Id)).ToList();
        }

        private IEnumerable<SelectListItem> CreateTrainingsSelectList<Training>(IRepository<Training> r)
            where Training : Entity<TrainingData>, new()
        {
            var items = r.Get().GetAwaiter().GetResult();

            return items.Select(m => new SelectListItem(m.Data.Title, m.Data.Id)).ToList();
        }

        private IEnumerable<SelectListItem> CreateClientsSelectList<Client>(IRepository<Client> r)
            where Client : Entity<ClientData>, new()
        {
            var items = r.Get().GetAwaiter().GetResult();

            return items.Select(m => new SelectListItem(m.Data.FirstName + " " + m.Data.LastName, m.Data.Id)).ToList();
        }
    }
}
