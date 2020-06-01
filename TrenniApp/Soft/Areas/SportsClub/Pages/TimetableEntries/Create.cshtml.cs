using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.TimetableEntries
{
    public class CreateModel : TimeTableEntriesPage
    {

        public CreateModel(ITimetableEntriesRepository timetableEntriesRepository, IParticipantOfTrainingsRepository participantsRepository, 
            ITrainingsRepository trainingsRepository, ICoachesRepository coachesRepository, ILocationsRepository locationsRepository, 
            ITrainingTypesRepository trainingTypesRepository, IClientsRepository clientsRepository) : base(timetableEntriesRepository, participantsRepository, trainingsRepository, coachesRepository, locationsRepository, trainingTypesRepository, clientsRepository)
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
