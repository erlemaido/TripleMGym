using System.Collections.Generic;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Pages.SportsClub
{
    public abstract class ClientsPage : CommonPage<IClientsRepository, Client, ClientView, ClientData>
    {
        protected internal readonly IParticipantOfTrainingsRepository participants;
        public IList<ParticipantOfTrainingView> Participants { get; }

        protected internal ClientsPage(IClientsRepository r, IParticipantOfTrainingsRepository p) : base(r)
        {
            PageTitle = "Kliendid";
            Trainings = new List<ParticipantOfTrainingView>();
            trainings = p;
        }


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
