using Microsoft.EntityFrameworkCore;

namespace OrderManagementService.Models
{
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Thuộc tính collection cho quan hệ 1-n
        public ICollection<OrderItem> OrderItems { get; set; }
    }


}
