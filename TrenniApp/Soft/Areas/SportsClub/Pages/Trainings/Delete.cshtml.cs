using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.Trainings
{
    public class DeleteModel : TrainingsPage
    {
        public DeleteModel(ITrainingsRepository trainingsRepository, ITimetableEntriesRepository timetableEntriesRepository, 
            ITrainingCategoriesRepository trainingCategoriesRepository, ICoachesRepository coachesRepository, ITrainingTypesRepository trainingTypesRepository, 
            ILocationsRepository locationsRepository) : base(trainingsRepository, timetableEntriesRepository, trainingCategoriesRepository, coachesRepository, trainingTypesRepository, locationsRepository)
        {
        }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            await GetObject(id, fixedFilter, fixedValue);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id, string fixedFilter, string fixedValue)
        {
            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
            await DeleteObject(id, fixedFilter, fixedValue);
            return Redirect(IndexUrl);
        }
    }
}
