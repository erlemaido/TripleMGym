using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.Coaches
{
    public class DetailsModel : CoachesPage
    {

        public DetailsModel(ICoachesRepository coachesRepository, ITimetableEntriesRepository timetableEntriesRepository, 
            ITrainingsRepository trainingsRepository, ILocationsRepository locationsRepository, 
            ITrainingTypesRepository trainingTypesRepository) : base(coachesRepository, timetableEntriesRepository, trainingsRepository, locationsRepository, trainingTypesRepository)
        {
        }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            await GetObject(id, fixedFilter, fixedValue);

            return Page();
        }
    }
}
