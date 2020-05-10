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
    public class IndexModel : PageModel
    {
        private readonly TrainingApp.Soft.Data.ApplicationDbContext _context;

        public IndexModel(TrainingApp.Soft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CoachView> CoachView { get;set; }

        public async Task OnGetAsync()
        {
            CoachView = await _context.CoachView.ToListAsync();
        }
    }
}
