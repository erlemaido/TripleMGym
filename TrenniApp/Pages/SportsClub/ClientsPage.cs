using System.Collections.Generic;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Pages.SportsClub
{
    public abstract class ClientsPage : CommonPage<IClientsRepository, Client, ClientView, ClientData>
    {
        protected internal readonly IParticipantsOfTrainingRepository trainings;
        public IList<ParticipantOfTrainingView> Trainings { get; }

        protected internal ClientsPage(IClientsRepository r, IParticipantsOfTrainingRepository t) : base(r)
        {
            PageTitle = "Clients";
            Trainings = new List<ParticipantOfTrainingView>();
            trainings = t;
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
    }
}
