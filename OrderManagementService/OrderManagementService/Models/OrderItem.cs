using Microsoft.EntityFrameworkCore;

namespace OrderManagementService.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; } // Khóa ngoại
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        // Điều hướng quan hệ với Order
        public Order Order { get; set; }
    }


}
