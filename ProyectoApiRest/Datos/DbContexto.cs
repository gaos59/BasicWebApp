using Microsoft.EntityFrameworkCore;
using ProyectoWebMVC.Models;

namespace ProyectoApiRest.Datos
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Lavado> Lavados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Identificacion);

            modelBuilder.Entity<Empleado>()
                .HasKey(e => e.Cedula);

            modelBuilder.Entity<Vehiculo>()
                .HasKey(v => v.Placa);

            modelBuilder.Entity<Lavado>()
                .HasKey(l => l.IdLavado);

            modelBuilder.Entity<Lavado>()
                .HasOne<Vehiculo>()
                .WithMany()
                .HasForeignKey(l => l.PlacaVehiculo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lavado>()
                .HasOne<Cliente>()
                .WithMany()
                .HasForeignKey(l => l.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lavado>()
                .HasOne<Empleado>()
                .WithMany()
                .HasForeignKey(l => l.IdEmpleado)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
