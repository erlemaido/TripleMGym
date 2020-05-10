using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Soft.Data;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.Coaches
{
    public class DeleteModel : PageModel
    {
        private readonly TrainingApp.Soft.Data.ApplicationDbContext _context;

        public DeleteModel(TrainingApp.Soft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CoachView CoachView { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CoachView = await _context.CoachView.FirstOrDefaultAsync(m => m.Id == id);

            if (CoachView == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CoachView = await _context.CoachView.FindAsync(id);

            if (CoachView != null)
            {
                _context.CoachView.Remove(CoachView);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
