using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.Trainings
{
    public class CreateModel : TrainingsPage
    {
        public CreateModel(ITrainingsRepository trainingsRepository, ITimetableEntriesRepository timetableEntriesRepository, 
            ITrainingCategoriesRepository trainingCategoriesRepository, ICoachesRepository coachesRepository, ITrainingTypesRepository trainingTypesRepository, 
            ILocationsRepository locationsRepository) : base(trainingsRepository, timetableEntriesRepository, trainingCategoriesRepository, coachesRepository, trainingTypesRepository, locationsRepository)
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
