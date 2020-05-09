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
        public DbSet<TrainingApp.Facade.SportsClub.ClientView> ClientView { get; set; }
        //public DbSet<TrainingApp.Facade.SportsClub.ParticipantOfTrainingView> ParticipantOfTrainingView { get; set; }
        //public DbSet<TrainingApp.Facade.SportsClub.TrainingView> TrainingView { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SportsClubDbContext.InitializeTables(builder);
        }

    }
}
