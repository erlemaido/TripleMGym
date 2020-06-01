using System.Threading.Tasks;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.Coaches
{
    public class IndexModel : CoachesPage
    {

        public IndexModel(ICoachesRepository coachesRepository, ITimetableEntriesRepository timetableEntriesRepository, 
            ITrainingsRepository trainingsRepository, ILocationsRepository locationsRepository, 
            ITrainingTypesRepository trainingTypesRepository) : base(coachesRepository, timetableEntriesRepository, trainingsRepository, locationsRepository, trainingTypesRepository)
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
