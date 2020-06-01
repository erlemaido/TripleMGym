using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.TimetableEntries
{
    public class EditModel : TimeTableEntriesPage
    {
        public EditModel(ITimetableEntriesRepository timetableEntriesRepository, IParticipantOfTrainingsRepository participantsRepository, 
            ITrainingsRepository trainingsRepository, ICoachesRepository coachesRepository, ILocationsRepository locationsRepository, 
            ITrainingTypesRepository trainingTypesRepository, IClientsRepository clientsRepository) : base(timetableEntriesRepository, participantsRepository, trainingsRepository, coachesRepository, locationsRepository, trainingTypesRepository, clientsRepository)
        {
        }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
            await GetObject(id, fixedFilter, fixedValue);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string fixedFilter, string fixedValue)
        {
            await UpdateObject(fixedFilter, fixedValue);
            return Redirect(IndexUrl);
        }
    }
}
