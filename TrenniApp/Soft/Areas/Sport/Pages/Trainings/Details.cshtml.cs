using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainingApp.Facade.Sport;

namespace TrainingApp.Soft.Areas.Sport.Pages.Trainings
{
    public class DetailsModel : PageModel
    {
        private readonly TrainingApp.Soft.Data.ApplicationDbContext _context;

        public DetailsModel(TrainingApp.Soft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
