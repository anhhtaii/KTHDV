using Microsoft.AspNetCore.Mvc;
using ReportingService.Data;
using ReportingService.Models;

namespace ReportingService.Controllers
{
	[ApiController]
	[Route("reports")]
	public class ReportsController : ControllerBase
	{
		private readonly ReportingDbContext _context;

		public ReportsController(ReportingDbContext context)
		{
			_context = context;
		}

		[HttpGet("products")]
		public IActionResult GetAllProductReports()
		{
			var reports = _context.ProductReports.ToList();
			return Ok(reports);
		}

		[HttpGet("products/{id}")]
		public IActionResult GetProductReport(int id)
		{
			var report = _context.ProductReports.Find(id);
			if (report == null) return NotFound();
			return Ok(report);
		}

		[HttpGet("orders")]
		public IActionResult GetAllOrderReports()
		{
			var reports = _context.OrderReports.ToList();
			return Ok(reports);
		}

		[HttpGet("orders/{id}")]
		public IActionResult GetOrderReport(int id)
		{
			var report = _context.OrderReports.Find(id);
			if (report == null) return NotFound();
			return Ok(report);
		}

		[HttpPost("products")]
		public IActionResult CreateProductReport([FromBody] ProductReport report)
		{
			if (report == null) return BadRequest();
			_context.ProductReports.Add(report);
			_context.SaveChanges();
			return CreatedAtAction(nameof(GetProductReport), new { id = report.Id }, report);
		}

		[HttpPost("orders")]
		public IActionResult CreateOrderReport([FromBody] OrderReport report)
		{
			if (report == null) return BadRequest();
			_context.OrderReports.Add(report);
			_context.SaveChanges();
			return CreatedAtAction(nameof(GetOrderReport), new { id = report.Id }, report);
		}

		[HttpDelete("products/{id}")]
		public IActionResult DeleteProductReport(int id)
		{
			var report = _context.ProductReports.Find(id);
			if (report == null) return NotFound();
			_context.ProductReports.Remove(report);
			_context.SaveChanges();
			return NoContent();
		}

		[HttpDelete("orders/{id}")]
		public IActionResult DeleteOrderReport(int id)
		{
			var report = _context.OrderReports.Find(id);
			if (report == null) return NotFound();
			_context.OrderReports.Remove(report);
			_context.SaveChanges();
			return NoContent();
		}
	}

}
