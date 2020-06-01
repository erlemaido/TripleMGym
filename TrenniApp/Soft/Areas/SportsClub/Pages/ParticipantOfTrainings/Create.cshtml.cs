using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.ParticipantOfTrainings
{
    public class CreateModel : ParticipantOfTrainingsPage
    {

        public CreateModel(IParticipantOfTrainingsRepository participantsRepository, ITimetableEntriesRepository timetableEntriesRepository, 
            IClientsRepository clientsRepository) : base(participantsRepository, timetableEntriesRepository, clientsRepository)
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
