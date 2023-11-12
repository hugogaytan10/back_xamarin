using Microsoft.EntityFrameworkCore;
using movilapispruebas.Models;
using System.Data;

namespace movilapispruebas.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext( DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Historiales> historial { get; set; }
        public DbSet<Permisos> permisos { get; set; }
        public DbSet<RolesPermisos> rolespermisos { get; set; }
        // Tus otros DbSet y miembros del contexto...

        // Deja solo este constructor en tu clase AppDbContext:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolesPermisos>()
                .HasKey(rp => new { rp.id_rol, rp.id_permiso }); // Configurar clave primaria compuesta

            // Configuraciones adicionales del modelo...
        }

        public DbSet<Puestos> puestos { get; set; }
        public DbSet<Reservas> reservas { get; set; }
        public DbSet<Roles> roles { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }
        public DbSet<Vehiculos> vehiculos { get; set; }
        public DbSet<ZonasParqueo> zonasparqueo { get; set; }
        public DbSet<Login> login { get; set; }



    }
}
