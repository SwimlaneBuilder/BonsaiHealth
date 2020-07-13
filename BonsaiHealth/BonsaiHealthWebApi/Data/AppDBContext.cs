using Microsoft.EntityFrameworkCore;

namespace BonsaiHealthWebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}