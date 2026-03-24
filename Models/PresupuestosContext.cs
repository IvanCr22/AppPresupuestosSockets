
using Microsoft.EntityFrameworkCore;

namespace AppPresupuestosSockets.Models
{
    public class PresupuestosContext : DbContext
    {
        public PresupuestosContext(DbContextOptions<PresupuestosContext> options) : base(options) { }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Presupuestos> Presupuestos { get; set; }
        public DbSet<Transacciones> Transacciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transacciones>()
                .HasOne(t => t.Usuario)
                .WithMany()
                .HasForeignKey(t => t.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Transacciones>()
                .HasOne(t => t.Presupuesto)
                .WithMany(p => p.Transacciones)
                .HasForeignKey(t => t.PresupuestoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}