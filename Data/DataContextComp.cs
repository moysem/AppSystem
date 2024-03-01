

using AppSystem.Models;
using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace AppSystem.Data
{
    public class DataContextComp : DbContext
    {
        public DbSet<Computer>? Computers { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                // options.UseSqlServer("Server=localhost;Database=DotNetCourseDatabase;Trusted_connection=false;TrustServerCertificate=True;User Id=sa;Password=SQLConnect1;",
                options.UseSqlServer("Server=localhost;Database=ITComputer;Trusted_Connection=true;TrustServerCertificate=true;",
                    options => options.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("CompScheme");

            modelBuilder.Entity<Computer>()
                // .HasNoKey()
                .HasKey(c => c.ComputerId);
                // .ToTable("Computer", "TutorialAppSchema");
                // .ToTable("TableName", "SchemaName");
        }
        

    }
}