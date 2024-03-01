

using AppSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AppSystem.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Usern>? Usern { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=localhost;Database=ITComputer;Trusted_Connection=true;TrustServerCertificate=true;",
                    options => options.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("CompScheme");

            modelBuilder.Entity<Usern>()
                // .HasNoKey()
                .HasKey(c => c.UserId);
                // .ToTable("Computer", "TutorialAppSchema");
                // .ToTable("TableName", "SchemaName");
        }
        

    }
}