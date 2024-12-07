using Microsoft.EntityFrameworkCore;
using ReportingService.Models;

namespace ReportingService.Data
{
	public class ReportingDbContext : DbContext
	{
		public DbSet<OrderReport> OrderReports { get; set; }
		public DbSet<ProductReport> ProductReports { get; set; }

		public ReportingDbContext(DbContextOptions<ReportingDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OrderReport>().HasKey(o => o.Id);
			modelBuilder.Entity<ProductReport>().HasKey(p => p.Id);
		}
	}
}
