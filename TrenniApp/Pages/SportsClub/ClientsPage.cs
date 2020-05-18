using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingApp.Aids;
using TrainingApp.Aids.Formats.Dates;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Pages.SportsClub
{
    public abstract class ClientsPage : CommonPage<IClientsRepository, Client, ClientView, ClientData>
    {
        public IList<ParticipantOfTrainingView> Participants { get; }
        public IEnumerable<SelectListItem> TimetableEntries { get; }
        protected internal readonly IParticipantOfTrainingsRepository participants;

        protected internal ClientsPage(IClientsRepository r, IParticipantOfTrainingsRepository p, ITimetableEntriesRepository t) : base(r)
        {
            PageTitle = "Kliendid";
            Participants = new List<ParticipantOfTrainingView>();
            TimetableEntries = CreateSelectList<TimetableEntry, TimetableEntryData>(t);
            participants = p;
        }

        public override string ItemId => Item?.Id ?? string.Empty;

        protected internal override string GetPageUrl() => "/SportsClub/Clients";

        protected internal override Client ToObject(ClientView view)
        {
            return ClientViewFactory.Create(view);
        }

        protected internal override ClientView ToView(Client obj)
        {
            return ClientViewFactory.Create(obj);
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
