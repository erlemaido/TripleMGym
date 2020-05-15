using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.Trainings
{
    public class CreateModel : TrainingsPage
    {

        public CreateModel(ITrainingsRepository r, ITimetableEntriesRepository t, ITrainingCategoriesRepository tc) : base(r, t, tc)
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
            Item.Id = Guid.NewGuid().ToString();
            if (!await AddObject(fixedFilter, fixedValue)) return Page();
            return Redirect(IndexUrl);
        }
    }
}
