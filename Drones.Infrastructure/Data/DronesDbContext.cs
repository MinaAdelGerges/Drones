using Drones.Domain.Entities;
using Drones.Domain.Enums;
using Drones.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Drones.Infrastructure.Data
{
    public class DronesDbContext : DbContext
    {
        public DronesDbContext(DbContextOptions dbContextoptions) : base(dbContextoptions)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "DroneDb");


        }
        public DbSet<State> States { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Drone> Drones { get; set; }
        public DbSet<Medication> Medications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<State>(new StateConfiguration());
            modelBuilder.ApplyConfiguration<Model>(new ModelConfiguration());

            modelBuilder.ApplyConfiguration<Drone>(new DroneConfiguration());
            modelBuilder.ApplyConfiguration<Medication>(new MedicationConfiguration());




            base.OnModelCreating(modelBuilder);
        }
    }
}
