using System.ComponentModel.DataAnnotations;

namespace QuanLyKhachSan.Models
{

    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // In thực tế, nên hash password
        public string Role { get; set; }
    }

}
