﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.TrainingCategories
{
    public class DetailsModel : TrainingCategoriesPage
    {
        public DetailsModel(ITrainingCategoriesRepository trainingCategoriesRepository) : base(trainingCategoriesRepository)
        {
        }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            await GetObject(id, fixedFilter, fixedValue);

            return Page();
        }
    }
}