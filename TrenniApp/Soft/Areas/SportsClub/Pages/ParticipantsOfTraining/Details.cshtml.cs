using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Pages.SportsClub;
using TrainingApp.Soft.Data;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.ParticipantsOfTraining
{
    public class DetailsModel : ParticipantsOfTrainingPage
    {

        public DetailsModel(IParticipantsOfTrainingRepository p, ITimetableEntriesRepository e, IClientsRepository cl, ICoachesRepository co) : base(p, e, cl, co)
        {
        }


        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            await GetObject(id, fixedFilter, fixedValue);
            return Page();
        }
        }
}

