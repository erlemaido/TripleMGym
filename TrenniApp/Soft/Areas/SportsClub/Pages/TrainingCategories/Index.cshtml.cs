using System.Threading.Tasks;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.TrainingCategories
{
    public class IndexModel : TrainingCategoriesPage
    {
        public IndexModel(ITrainingCategoriesRepository trainingCategoriesRepository) : base(trainingCategoriesRepository)
        {
        }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, 
            int? pageIndex, string fixedFilter, string fixedValue)
        {
            await GetList(sortOrder, currentFilter, searchString, pageIndex, fixedFilter, fixedValue);
        }
    }
}
