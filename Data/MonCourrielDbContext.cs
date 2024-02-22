using Microsoft.EntityFrameworkCore;
using MonCourriel.API.Models;

namespace MonCourriel.API.Data
{
    public class MonCourrielDbContext : DbContext
    {
        public MonCourrielDbContext(DbContextOptions<MonCourrielDbContext> options) : base(options) { }

        public DbSet<Courrier> Courriers { get; set; }
    }
}
