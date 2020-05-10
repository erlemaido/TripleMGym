using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Infra.SportsClub;

namespace TrainingApp.Soft.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SportsClubDbContext.InitializeTables(builder);
        }

        public DbSet<TrainingApp.Facade.SportsClub.ClientView> ClientView { get; set; }

        public DbSet<TrainingApp.Facade.SportsClub.CoachView> CoachView { get; set; }

        public DbSet<TrainingApp.Facade.SportsClub.LocationView> LocationView { get; set; }

        public DbSet<TrainingApp.Facade.SportsClub.TimetableEntryView> TimetableEntryView { get; set; }

        public DbSet<TrainingApp.Facade.SportsClub.TrainingCategoryView> TrainingCategoryView { get; set; }

        public DbSet<TrainingApp.Facade.SportsClub.TrainingTypeView> TrainingTypeView { get; set; }

    }
}
