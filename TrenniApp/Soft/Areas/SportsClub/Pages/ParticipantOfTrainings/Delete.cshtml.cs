using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.ParticipantOfTrainings
{
    public class DeleteModel : ParticipantOfTrainingsPage
    {

        public DeleteModel(IParticipantOfTrainingsRepository participantsRepository, ITimetableEntriesRepository timetableEntriesRepository, 
            IClientsRepository clientsRepository) : base(participantsRepository, timetableEntriesRepository, clientsRepository)
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
