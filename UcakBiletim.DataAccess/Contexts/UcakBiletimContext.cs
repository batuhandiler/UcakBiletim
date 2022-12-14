using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UcakBiletim.DataAccess.Configurations;
using UcakBiletim.Entities.Concrete;

namespace UcakBiletim.DataAccess.Contexts
{
    public class UcakBiletimContext : DbContext
    {
        public static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        public UcakBiletimContext(DbContextOptions<UcakBiletimContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
        }
    }
}
