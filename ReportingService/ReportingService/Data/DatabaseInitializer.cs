using ReportingService.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ReportingService.Data
{
	public static class DatabaseInitializer
	{
		public static void Seed(IServiceProvider serviceProvider)
		{
			using var scope = serviceProvider.CreateScope();
			var context = scope.ServiceProvider.GetRequiredService<ReportingDbContext>();

			// Kiểm tra nếu đã có dữ liệu, không thêm lại
			if (context.OrderReports.Any() || context.ProductReports.Any())
			{
				return;
			}

			// Dữ liệu giả cho bảng OrderReports
			var orderReports = new[]
			{
			new OrderReport { OrderId = 1, TotalRevenue = 5000.00m, TotalCost = 3000.00m, TotalProfit = 2000.00m },
			new OrderReport { OrderId = 2, TotalRevenue = 7000.00m, TotalCost = 4500.00m, TotalProfit = 2500.00m }
		};

			// Dữ liệu giả cho bảng ProductReports
			var productReports = new[]
			{
			new ProductReport { OrderReportId = 1, ProductId = 101, TotalSold = 10, Revenue = 2500.00m, Cost = 1500.00m, Profit = 1000.00m },
			new ProductReport { OrderReportId = 1, ProductId = 102, TotalSold = 20, Revenue = 2500.00m, Cost = 1500.00m, Profit = 1000.00m },
			new ProductReport { OrderReportId = 2, ProductId = 103, TotalSold = 15, Revenue = 3500.00m, Cost = 2500.00m, Profit = 1000.00m }
		};

			// Thêm dữ liệu vào cơ sở dữ liệu
			context.OrderReports.AddRange(orderReports);
			context.ProductReports.AddRange(productReports);

			// Lưu thay đổi
			context.SaveChanges();
		}
	}
}
