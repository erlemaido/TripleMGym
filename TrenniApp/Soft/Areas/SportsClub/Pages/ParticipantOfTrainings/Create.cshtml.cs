﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Pages.SportsClub;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.ParticipantOfTrainings
{
    public class CreateModel : ParticipantOfTrainingsPage
    {

        public CreateModel(IParticipantOfTrainingsRepository p, ITimetableEntriesRepository e, IClientsRepository cl, ITrainingsRepository tr) : base(p, e, cl, tr)
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
