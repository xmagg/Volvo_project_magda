using Microsoft.EntityFrameworkCore;
using NewsPlatform2.Models.Entities;

namespace NewsPlatform2.Models
{
    public class NewsDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<News> Newss { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MAGLENUSIA\\SQLEXPRESS;Database=NewsDb;TrustServerCertificate=true;Integrated Security=true;");
        }
    }
}
