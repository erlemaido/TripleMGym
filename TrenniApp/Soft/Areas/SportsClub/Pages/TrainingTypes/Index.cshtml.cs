using System.Threading.Tasks;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.TrainingTypes
{
    public class IndexModel : TrainingTypesPage
    {
        public IndexModel(ITrainingTypesRepository r) : base(r)
        {
        }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            await GetList(sortOrder, currentFilter, searchString, pageIndex, fixedFilter, fixedValue);

        }
    }
}