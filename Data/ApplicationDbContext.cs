using dsd03Razor2020Assessment.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RolesForAssessment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //load this to get passed the "The entity type 'IdentityUserLogin<string>' requires a primary key to be defined." error
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


        }


        public DbSet<Movie> Movie { get; set; }
        public DbSet<Cast> Cast { get; set; }

    }
}