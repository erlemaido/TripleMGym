using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.Trainings
{
    public class DetailsModel : TrainingsPage
    {

        public DetailsModel(ITrainingsRepository r, ITimetableEntriesRepository t, ITrainingCategoriesRepository tc, ICoachesRepository c,
            ITrainingTypesRepository tt, ILocationsRepository l) : base(r, t, tc, c, tt, l)
        {
        }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            await GetObject(id, fixedFilter, fixedValue);
            return Page();
        }
    }
}
