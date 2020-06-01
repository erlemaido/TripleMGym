using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.Coaches
{
    public class CreateModel : CoachesPage
    {

        public CreateModel(ICoachesRepository coachesRepository, ITimetableEntriesRepository timetableEntriesRepository, 
            ITrainingsRepository trainingsRepository, ILocationsRepository locationsRepository, 
            ITrainingTypesRepository trainingTypesRepository) : base(coachesRepository, timetableEntriesRepository, trainingsRepository, locationsRepository, trainingTypesRepository)
        {
        }

        public IActionResult OnGet(string fixedFilter, string fixedValue)
        {
            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string fixedFilter, string fixedValue)
        {
            if (!await AddObject(fixedFilter, fixedValue)) return Page();

            return Redirect(IndexUrl);
        }
    }
}
