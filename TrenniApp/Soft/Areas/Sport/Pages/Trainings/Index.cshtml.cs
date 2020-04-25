using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainingApp.Facade.Sport;

namespace TrainingApp.Soft.Areas.Sport.Pages.Trainings
{
    public class IndexModel : PageModel
    {
        private readonly TrainingApp.Soft.Data.ApplicationDbContext _context;

        public IndexModel(TrainingApp.Soft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TrainingView> TrainingView { get;set; }

        public async Task OnGetAsync()
        {
            TrainingView = await _context.Trainings.ToListAsync();
        }
    }
}
