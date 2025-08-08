using Microsoft.EntityFrameworkCore;
using Appi_MisMinistros.Models;
namespace Appi_MisMinistros.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Tb_Usuarios { get; set; }
        public DbSet<Rol>Tb_Roles { get; set; }
        public DbSet<UsuarioRol> Tb_UsuarioRol { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rol>(entity => {

                entity.HasKey(col => col.IdRol);
                entity.Property(col => col.IdRol).ValueGeneratedNever();
            
            });

            // Configurar UsuarioRol con clave compuesta y relaciones
            modelBuilder.Entity<UsuarioRol>(entity =>
            {
                entity.HasKey(ur => new { ur.UsuarioId, ur.RolId });
                entity.HasOne(ur => ur.Usuario)
                      .WithMany(u => u.UsuarioRoles)
                      .HasForeignKey(ur => ur.UsuarioId);

                entity.HasOne(ur => ur.Rol)
                      .WithMany(r => r.UsuarioRoles)
                      .HasForeignKey(ur => ur.RolId);
               

            });
          
        }

    }
}
