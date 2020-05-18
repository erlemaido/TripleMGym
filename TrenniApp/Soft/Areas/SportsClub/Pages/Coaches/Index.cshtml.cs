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

namespace TrainingApp.Soft.Areas.SportsClub.Pages.Coaches
{
    public class IndexModel : CoachesPage
    {

        public IndexModel(ICoachesRepository r, ITimetableEntriesRepository te, ITrainingsRepository t, ILocationsRepository l, ITrainingTypesRepository tt) : base(r, te, t, l, tt)
        {
        }

        public async Task OnGetAsync(string sortOrder, string id, string currentFilter, string searchString,
            int? pageIndex, string fixedFilter, string fixedValue)
        {
            SelectedId = id;
            await GetList(sortOrder, currentFilter, searchString, pageIndex, fixedFilter, fixedValue);
        }
    }
}
