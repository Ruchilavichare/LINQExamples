using Microsoft.EntityFrameworkCore;
using LinqDemoApp.Models;

namespace LinqDemoApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "John Doe", Age = 22, Course = "Math", Grade = 85 },
                new Student { Id = 2, Name = "Jane Smith", Age = 19, Course = "Science", Grade = 90 },
                new Student { Id = 3, Name = "Emily Johnson", Age = 23, Course = "Math", Grade = 78 }
            );
        }
    }
}
