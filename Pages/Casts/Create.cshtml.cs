using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RolesForAssessment.Data;
using dsd03Razor2020Assessment.Models;

namespace RolesForAssessment.Pages.Casts
{
    public class CreateModel : PageModel
    {
        private readonly RolesForAssessment.Data.ApplicationDbContext _context;

        public CreateModel(RolesForAssessment.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title");
            return Page();
        }

        [BindProperty]
        public Cast Cast { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Cast == null || Cast == null)
            {
                return Page();
            }

            _context.Cast.Add(Cast);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
