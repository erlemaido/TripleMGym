using System.Threading.Tasks;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.Trainings
{
    public class IndexModel : TrainingsPage
    {
        public IndexModel(ITrainingsRepository trainingsRepository, ITimetableEntriesRepository timetableEntriesRepository, 
            ITrainingCategoriesRepository trainingCategoriesRepository, ICoachesRepository coachesRepository, ITrainingTypesRepository trainingTypesRepository, 
            ILocationsRepository locationsRepository) : base(trainingsRepository, timetableEntriesRepository, trainingCategoriesRepository, coachesRepository, trainingTypesRepository, locationsRepository)
        {
        }

        public async Task OnGetAsync(string sortOrder, string id, 
            string currentFilter, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            SelectedId = id;
            await GetList(sortOrder,
                currentFilter, searchString, pageIndex, fixedFilter, fixedValue);
        }
    }
}
