using Microsoft.AspNetCore.Mvc;
using QuanLyKhachSan.Helper;
using QuanLyKhachSan.Models;

namespace QuanLyKhachSan.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtHelper _jwtHelper;
        private readonly List<User> _users; // Dữ liệu giả lập

        public AuthController(IConfiguration configuration)
        {
            _jwtHelper = new JwtHelper(configuration);
            _users = new List<User>
        {
            new User { Id = 1, Username = "admin", Password = "admin123", Role = "Admin" },
            new User { Id = 2, Username = "user", Password = "user123", Role = "User" }
        };
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _users.Find(u => u.Username == request.Username && u.Password == request.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            var token = _jwtHelper.GenerateToken(user.Username, user.Role);
            return Ok(new { token });
        }
    }
}
