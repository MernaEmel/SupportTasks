using Microsoft.EntityFrameworkCore;
using SupportTask2.Models;
namespace SupportTask2.Data
{


    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<BlogType>types { get; set; }
        public DbSet<Blog>blogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogType>().HasData(
                new BlogType { Id = 1, Name = "action" },
                new BlogType { Id = 2, Name = "comedy" }
                );

        }
    }
}
