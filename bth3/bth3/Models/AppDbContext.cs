using bth3.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductManagementService.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet cho bảng Products
        public DbSet<Product> Products { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppDbContext>().HasKey(o => o.ContextId);
         
        }
    }
}
