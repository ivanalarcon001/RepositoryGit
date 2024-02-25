using AlquileVehiculosWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlquileVehiculosWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Vehiculos> Vehiculos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Reservas> Reservas { get; set; }
        public DbSet<Tarifas> Tarifas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vehiculos>().ToTable("Vehiculos");
            modelBuilder.Entity<Clientes>().ToTable("Clientes");
            modelBuilder.Entity<Reservas>().ToTable("Reservas");
            modelBuilder.Entity<Tarifas>().ToTable("Tarifas");

        }

    }
}
