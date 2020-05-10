using Microsoft.EntityFrameworkCore;
using TrainingApp.Data.SportsClub;

namespace TrainingApp.Infra.SportsClub
{
    public class SportsClubDbContext : DbContext
    {
        public SportsClubDbContext(DbContextOptions<SportsClubDbContext> options) : base(options) { }

        public DbSet<LocationData> Locations { get; set; }
        public DbSet<CoachData> Coaches { get; set; }
        public DbSet<ClientData> Clients { get; set; }
        public DbSet<ParticipantOfTrainingData> ParticipantsOfTraining { get; set; }
        public DbSet<TimetableEntryData> TimetableEntries { get; set; }
        public DbSet<TrainingCategoryData> TrainingCategories { get; set; }
        public DbSet<TrainingData> Trainings { get; set; }
        public DbSet<TrainingTypeData> TrainingTypes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<LocationData>().ToTable(nameof(Locations));
            builder.Entity<CoachData>().ToTable(nameof(Coaches));
            builder.Entity<ClientData>().ToTable(nameof(Clients));
            builder.Entity<ParticipantOfTrainingData>().ToTable(nameof(ParticipantsOfTraining)).HasKey(x => new { x.Id, x.ClientId, x.TimetableEntryId, x.CoachId });
            builder.Entity<TimetableEntryData>().ToTable(nameof(TimetableEntries)).HasKey(x => new { x.Id, x.CoachId, x.TrainingId, x.LocationId, x.TrainingTypeId });
            builder.Entity<TrainingCategoryData>().ToTable(nameof(TrainingCategories));
            builder.Entity<TrainingData>().ToTable(nameof(Trainings)).HasKey(x => new { x.Id, x.TrainingCategoryId });
            builder.Entity<TrainingTypeData>().ToTable(nameof(TrainingTypes));
        }
    }
}
