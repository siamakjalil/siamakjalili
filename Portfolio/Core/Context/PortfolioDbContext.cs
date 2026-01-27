using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Context
{
    public class PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : DbContext(options)
    { 
        public DbSet<Experience> Experiences { get; set; } 
        public DbSet<Skill> Skills { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(PortfolioDbContext).Assembly);
        } 
    }
}
