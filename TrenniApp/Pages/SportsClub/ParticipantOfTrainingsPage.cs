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
            ITimetableEntriesRepository t, IClientsRepository cl, ITrainingsRepository tr) : base(r)
        {
            PageTitle = "Participant of Trainings";
            Trainings = CreateTrainingsSelectList<Training>(tr);
            TimetableEntries = CreateTimetableEntriesSelectList<TimetableEntry>(t);
            Clients = CreateClientsSelectList<Client>(cl);

        }
        public IEnumerable<SelectListItem> TimetableEntries { get; }
        public IEnumerable<SelectListItem> Clients { get; }
        public IEnumerable<SelectListItem> Trainings { get; }

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

        protected internal override string GetPageSubTitle()
        {
            //hack, mis tuleks ilusaks teha
            var clients = GetNameFromId(FixedValue, Clients);
            var timetableEntry = GetNameFromId(FixedValue, TimetableEntries);
            if (clients.Equals("Unspecified"))
            {
                return FixedValue is null ? base.GetPageSubTitle() : $"For {timetableEntry}";
            }
            return FixedValue is null ? base.GetPageSubTitle() : $"For {clients}";
        }

        private IEnumerable<SelectListItem> CreateTimetableEntriesSelectList<TimetableEntry>(IRepository<TimetableEntry> r)
            where TimetableEntry : Entity<TimetableEntryData>, new()
        {
            var items = r.Get().GetAwaiter().GetResult();

            return items.Select(m => new SelectListItem(GetNameFromId(m.Data.TrainingId, Trainings) + " " + m.Data.StartTime + " - " + m.Data.EndTime, m.Data.Id)).ToList();
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
