using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Soft.Data;

namespace TrainingApp.Soft.Areas.SportsClub.Pages.Locations
{
    public class CreateModel : PageModel
    {
        private readonly TrainingApp.Soft.Data.ApplicationDbContext _context;

        public CreateModel(TrainingApp.Soft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LocationView LocationView { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LocationView.Add(LocationView);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
