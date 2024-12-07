using Microsoft.EntityFrameworkCore;
using ReportingService.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

builder.Services.AddDbContext<ReportingDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
// Gọi phương thức Seed để thêm dữ liệu
DatabaseInitializer.Seed(app.Services);
app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
	var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

	if (!string.IsNullOrEmpty(token))
	{
		// Gọi tới Auth Service để kiểm tra token
		using var client = new HttpClient();
		var authServiceUrl = "http://localhost:5000/auth/validate"; // Thay bằng URL của Auth Service

		var response = await client.GetAsync($"{authServiceUrl}?token={token}");
		if (response.IsSuccessStatusCode)
		{
			await next(); // Tiếp tục xử lý request nếu token hợp lệ
			return;
		}
	}

	context.Response.StatusCode = StatusCodes.Status401Unauthorized; // Trả về 401 nếu không hợp lệ
	await context.Response.WriteAsync("Unauthorized");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
