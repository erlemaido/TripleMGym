using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.Coaches
{
    public class DeleteModel : CoachesPage
    {

        public DeleteModel(ICoachesRepository coachesRepository, ITimetableEntriesRepository timetableEntriesRepository, 
            ITrainingsRepository trainingsRepository, ILocationsRepository locationsRepository, 
            ITrainingTypesRepository trainingTypesRepository) : base(coachesRepository, timetableEntriesRepository, trainingsRepository, locationsRepository, trainingTypesRepository)
        {
        }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            await GetObject(id, fixedFilter, fixedValue);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id, string fixedFilter, string fixedValue)
        {
            await DeleteObject(id, fixedFilter, fixedValue);

            return Redirect(IndexUrl);
        }
    }
}
