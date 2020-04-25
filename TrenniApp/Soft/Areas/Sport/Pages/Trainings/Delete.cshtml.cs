using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainingApp.Facade.Sport;

namespace TrainingApp.Soft.Areas.Sport.Pages.Trainings
{
    public class DeleteModel : PageModel
    {
        private readonly TrainingApp.Soft.Data.ApplicationDbContext _context;

        public DeleteModel(TrainingApp.Soft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TrainingView TrainingView { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TrainingView = await _context.Trainings.FirstOrDefaultAsync(m => m.Id == id);

            if (TrainingView == null)
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

            TrainingView = await _context.Trainings.FindAsync(id);

            if (TrainingView != null)
            {
                _context.Trainings.Remove(TrainingView);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
