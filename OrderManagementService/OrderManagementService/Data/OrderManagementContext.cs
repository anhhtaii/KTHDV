namespace OrderManagementService.Data
{
    using Microsoft.EntityFrameworkCore;
    using OrderManagementService.Models;

    public class OrderManagementContext : DbContext
    {
        public OrderManagementContext(DbContextOptions<OrderManagementContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình bảng Orders
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 2); // Đảm bảo độ chính xác cho decimal

            modelBuilder.Entity<Order>()
                .Property(o => o.Status)
                .HasMaxLength(50); // Giới hạn độ dài của trạng thái đơn hàng

            // Cấu hình bảng OrderItems
            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.TotalPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.ProductName)
                .HasMaxLength(255); // Giới hạn độ dài tên sản phẩm

            // Định nghĩa quan hệ giữa Orders và OrderItems
            modelBuilder.Entity<OrderItem>()
    .HasOne(oi => oi.Order) // Điều hướng từ OrderItem đến Order
    .WithMany(o => o.OrderItems) // Một Order có nhiều OrderItem
    .HasForeignKey(oi => oi.OrderId) // Khóa ngoại
    .OnDelete(DeleteBehavior.Cascade); // Xóa Order sẽ xóa OrderItem

        }
    }
}
