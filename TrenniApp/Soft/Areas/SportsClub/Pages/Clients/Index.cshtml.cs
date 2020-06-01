using System.Threading.Tasks;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.Clients
{
    public class IndexModel : ClientsPage
    {
        public IndexModel(IClientsRepository clientsRepository, IParticipantOfTrainingsRepository participantsRepository, 
            ITimetableEntriesRepository timetableEntriesRepository) : base(clientsRepository, participantsRepository, timetableEntriesRepository)
        {
        }

        public async Task OnGetAsync(string sortOrder, string id, string currentFilter, string searchString,
            int? pageIndex, string fixedFilter, string fixedValue)
        {
            SelectedId = id;
            await GetList(sortOrder, currentFilter, searchString, pageIndex, fixedFilter, fixedValue);
        }
    }
}