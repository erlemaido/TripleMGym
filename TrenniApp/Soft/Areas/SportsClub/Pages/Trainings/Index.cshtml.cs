using System.Threading.Tasks;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.Trainings
{
    public class IndexModel : TrainingsPage
    {

        public IndexModel(ITrainingsRepository r, ITimetableEntriesRepository t, ITrainingCategoriesRepository tc) : base(r, t, tc)
        {
        }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            await GetList(sortOrder,
                currentFilter, searchString, pageIndex, fixedFilter, fixedValue);
        }
    }
}
