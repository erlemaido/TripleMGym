using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.ParticipantOfTrainings
{
    public class DetailsModel : ParticipantOfTrainingsPage
    {

        public DetailsModel(IParticipantOfTrainingsRepository participantsRepository, ITimetableEntriesRepository timetableEntriesRepository, 
            IClientsRepository clientsRepository) : base(participantsRepository, timetableEntriesRepository, clientsRepository)
        {
        }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            await GetObject(id, fixedFilter, fixedValue);
            return Page();
        }
    }
}
