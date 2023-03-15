using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TeamViewer2.EntityContext.Entites;

namespace TeamViewer2.EntityContext.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        
        }
    }
}
