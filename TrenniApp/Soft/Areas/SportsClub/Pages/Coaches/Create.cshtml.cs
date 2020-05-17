using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Pages.SportsClub;
using TrainingApp.Soft.Data;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.Coaches
{
    public class CreateModel : CoachesPage
    {

        public CreateModel(ICoachesRepository r, ITimetableEntriesRepository t) : base(r, t)
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
