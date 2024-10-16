using Microsoft.EntityFrameworkCore;
using MyWebApp.Models;

namespace MyWebApp.Data
{
    public class YourDbContext : DbContext
    {
        public YourDbContext(DbContextOptions<YourDbContext> options)
            : base(options)
        {
        }

        public DbSet<YourEntity> YourEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<YourEntity>().ToTable("YourTable");
            modelBuilder.Entity<YourEntity>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
        }

        // Removed the OnConfiguring method that adds the SqlServerSaveChangesInterceptor
    }
}