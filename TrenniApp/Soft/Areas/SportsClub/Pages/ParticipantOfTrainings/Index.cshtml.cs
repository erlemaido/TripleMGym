using System.Threading.Tasks;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.ParticipantOfTrainings
{
    public class IndexModel : ParticipantOfTrainingsPage
    {
        public IndexModel(IParticipantOfTrainingsRepository participantsRepository, ITimetableEntriesRepository timetableEntriesRepository, 
            IClientsRepository clientsRepository) : base(participantsRepository, timetableEntriesRepository, clientsRepository)
        {
        }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, 
            int? pageIndex, string fixedFilter, string fixedValue)
        {
            await GetList(sortOrder,
                currentFilter, searchString, pageIndex, fixedFilter, fixedValue);
        }
    }
}
