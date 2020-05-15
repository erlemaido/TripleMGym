﻿using System;
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

namespace TrainingApp.Soft.Areas.SportsClub.Pages.TimetableEntries
{
    public class DetailsModel : TimeTableEntriesPage
    {

        public DetailsModel(ITimetableEntriesRepository r, IParticipantOfTrainingsRepository p, 
            ITrainingsRepository t, ICoachesRepository c, ILocationsRepository l, ITrainingTypesRepository tt) : base(r, p, t, c, l, tt)
        {
        }

        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            await GetObject(id, fixedFilter, fixedValue);
            return Page();
        }
        }
}

