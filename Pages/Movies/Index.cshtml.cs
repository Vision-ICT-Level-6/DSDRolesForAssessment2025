using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RolesForAssessment.Data;
using dsd03Razor2020Assessment.Models;

namespace RolesForAssessment.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RolesForAssessment.Data.ApplicationDbContext _context;

        public IndexModel(RolesForAssessment.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Movie != null)
            {
                Movie = await _context.Movie.ToListAsync();
            }
        }
    }
}
