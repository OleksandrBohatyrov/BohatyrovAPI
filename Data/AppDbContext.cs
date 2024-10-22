using Microsoft.EntityFrameworkCore;
using BohatyrovAPI.Models;

namespace BohatyrovAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Kasutaja> Kasutajad { get; set; }
        public DbSet<Toode> Tooted { get; set; }
        public DbSet<KasutajaToode> KasutajaTooted { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(
                    "Server=localhost;Database=bohatyrovdb;User=root;Password=;",
                    ServerVersion.AutoDetect("Server=localhost;Database=bohatyrovdb;User=root;Password=;")
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<KasutajaToode>()
                .HasKey(kt => new { kt.KasutajaId, kt.ToodeId });

            modelBuilder.Entity<KasutajaToode>()
                .HasOne(kt => kt.Kasutaja)
                .WithMany(k => k.KasutajaTooted)
                .HasForeignKey(kt => kt.KasutajaId);

            modelBuilder.Entity<KasutajaToode>()
                .HasOne(kt => kt.Toode)
                .WithMany(t => t.KasutajaTooted)
                .HasForeignKey(kt => kt.ToodeId);
        }
    }
}
