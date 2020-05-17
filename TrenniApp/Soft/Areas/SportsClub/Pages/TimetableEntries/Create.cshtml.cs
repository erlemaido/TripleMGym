using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Pages.SportsClub;
using TrainingApp.Soft.Data;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.TimetableEntries
{
    public class CreateModel : TimeTableEntriesPage
    {

        public CreateModel(ITimetableEntriesRepository r, IParticipantOfTrainingsRepository p, 
            ITrainingsRepository t, ICoachesRepository c, ILocationsRepository l, ITrainingTypesRepository tt,
            IClientsRepository cl) : base(r, p, t, c, l, tt, cl)
        {
        }

        public IActionResult OnGet(string fixedFilter, string fixedValue)
        {
            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
            return Page();

        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string fixedFilter, string fixedValue)
        {
            Item.Id = Guid.NewGuid().ToString();
            if (!await AddObject(fixedFilter, fixedValue)) return Page();
            return Redirect(IndexUrl);
        }
    }
}
