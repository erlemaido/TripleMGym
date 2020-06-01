using System.Threading.Tasks;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.TimetableEntries
{
    public class IndexModel : TimeTableEntriesPage
    {

        public IndexModel(ITimetableEntriesRepository timetableEntriesRepository, IParticipantOfTrainingsRepository participantsRepository, 
            ITrainingsRepository trainingsRepository, ICoachesRepository coachesRepository, ILocationsRepository locationsRepository, 
            ITrainingTypesRepository trainingTypesRepository, IClientsRepository clientsRepository) : base(timetableEntriesRepository, participantsRepository, trainingsRepository, coachesRepository, locationsRepository, trainingTypesRepository, clientsRepository)
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
