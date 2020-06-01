using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.Clients
{
    public class DetailsModel : ClientsPage
    {
        public DetailsModel(IClientsRepository clientsRepository, IParticipantOfTrainingsRepository participantsRepository, 
            ITimetableEntriesRepository timetableEntriesRepository) : base(clientsRepository, participantsRepository, timetableEntriesRepository)
        {
        }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            await GetObject(id, fixedFilter, fixedValue);

            return Page();
        }
    }
}