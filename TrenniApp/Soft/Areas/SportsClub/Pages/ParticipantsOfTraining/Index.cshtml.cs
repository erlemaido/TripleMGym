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
    public class IndexModel : ParticipantsOfTrainingPage
    {

        public IndexModel(IParticipantsOfTrainingRepository p, ITimetableEntriesRepository e, IClientsRepository cl, ICoachesRepository co) : base(p, e, cl, co)
        {
        }
        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            await GetList(sortOrder,
                currentFilter, searchString, pageIndex, fixedFilter, fixedValue);
        }
    }
}
