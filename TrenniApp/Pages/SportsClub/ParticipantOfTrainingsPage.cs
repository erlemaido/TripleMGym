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
            PageTitle = "Broneeringud";
            TimetableEntries = CreateSelectList<TimetableEntry, TimetableEntryData>(t);
            Clients = CreateSelectList<Client, ClientData>(cl);

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
                if (m.Value ==clientId)
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
