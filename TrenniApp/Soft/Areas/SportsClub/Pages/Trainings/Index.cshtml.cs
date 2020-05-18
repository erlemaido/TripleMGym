using System.Threading.Tasks;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.Trainings
{
    public class IndexModel : TrainingsPage
    {

        public IndexModel(ITrainingsRepository r, ITimetableEntriesRepository t, ITrainingCategoriesRepository tc, ICoachesRepository c,
            ITrainingTypesRepository tt, ILocationsRepository l) : base(r, t, tc, c, tt, l)
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
