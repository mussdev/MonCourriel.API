using Microsoft.EntityFrameworkCore;
using MonCourriel.API.Models;

namespace MonCourriel.API.Data
{
    public class MonCourrielDbContext : DbContext
    {
        public MonCourrielDbContext(DbContextOptions<MonCourrielDbContext> options) : base(options) { }

        public DbSet<Courrier> Courriers { get; set; }
        public DbSet<Directions> CompagnyDirections { get; set; }
        public DbSet<ServicesDep> ServicesDeps { get; set; }
        public DbSet<CourrierImage> CourrierImages{get; set;}
        public DbSet<Recommandation> recommandations{get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Directions>()
                .HasMany(e => e.ServicesDeps)
                .WithOne(e => e.Directions)
                .HasForeignKey(e => e.DirectionId)
                .IsRequired();

            modelBuilder.Entity<Courrier>()
                .HasMany(e => e.CourrierImages)
                .WithOne(e => e.Courriers)
                .HasForeignKey(e => e.CourrierId)
                .IsRequired();
        }
    }
}
