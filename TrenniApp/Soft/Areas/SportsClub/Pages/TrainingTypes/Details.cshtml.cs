using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Soft.Data;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.TrainingTypes
{
    public class DetailsModel : PageModel
    {
        private readonly TrainingApp.Soft.Data.ApplicationDbContext _context;

        public DetailsModel(TrainingApp.Soft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public TrainingTypeView TrainingTypeView { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TrainingTypeView = await _context.TrainingTypeView.FirstOrDefaultAsync(m => m.Id == id);

            if (TrainingTypeView == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
