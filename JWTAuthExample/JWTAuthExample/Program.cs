using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Thêm cấu hình JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "yourdomain.com", // Thay bằng Issuer thực tế
            ValidAudience = "yourdomain.com", // Thay bằng Audience thực tế
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key")) // Thay bằng khóa bí mật
        };
    });

// Thêm Swagger vào dịch vụ
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Thêm các dịch vụ khác
builder.Services.AddControllers();

var app = builder.Build(); // Chỉ giữ dòng này

// Sử dụng Swagger khi chạy ứng dụng
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Sử dụng xác thực
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
