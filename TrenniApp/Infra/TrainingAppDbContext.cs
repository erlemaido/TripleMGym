using Microsoft.EntityFrameworkCore;
using TrainingApp.Data.Reservation;
using TrainingApp.Data.SportsClub;
using TrainingApp.Data.TimeSlot;
using TrainingApp.Data.Trainer;
using TrainingApp.Data.Training;

namespace TrainingApp.Infra
{
    public class TrainingAppDbContext : DbContext
    {
        public DbSet<ReservationData> Reservations { get; set; }
        public DbSet<TrainingData> Trainings { get; set; }
        public DbSet<SportsClubData> SportsClubs { get; set; }
        public DbSet<TimeSlotData> TimeSlots { get; set; }
        public DbSet<TrainerData> Trainers { get; set; }

        public TrainingAppDbContext(DbContextOptions<TrainingAppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }
        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<ReservationData>().ToTable(nameof(Reservations)).HasKey(x => new { x.TrainingId, x.TrainerId, x.SportsClubId, x.Timestamp });
            builder.Entity<TrainingData>().ToTable(nameof(Trainings));
            builder.Entity<SportsClubData>().ToTable(nameof(SportsClubs));
            builder.Entity<TrainerData>().ToTable(nameof(Trainers));
            builder.Entity<TimeSlotData>().ToTable(nameof(TimeSlots));
        }

    }
}
