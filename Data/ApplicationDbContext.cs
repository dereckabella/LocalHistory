using LocalHistory.Models; 
using Microsoft.EntityFrameworkCore;

namespace LocalHistory.Data 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Story> Stories { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
