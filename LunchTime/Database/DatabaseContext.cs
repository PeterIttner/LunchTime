using LunchTime.Models.Appointment.Entities;
using LunchTime.Models.Locality.Entity;
using LunchTime.Models.Restaurant.Entity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace LunchTime.Database
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "MyDb.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<AppointmentEntity>()
                .HasOne(appointment => appointment.Locality);
        }

        public DbSet<RestaurantEntity> Restaurants { get; set; }
        public DbSet<LocalityEntity> Localities { get; set; }
        public DbSet<AppointmentEntity> Appointment { get; set; }
    }
}
