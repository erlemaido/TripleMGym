using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Soft.Data;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.Clients
{
    public class DetailsModel : PageModel
    {
        private readonly TrainingApp.Soft.Data.ApplicationDbContext _context;

        public DetailsModel(TrainingApp.Soft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ClientView ClientView { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClientView = await _context.ClientView.FirstOrDefaultAsync(m => m.Id == id);

            if (ClientView == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
