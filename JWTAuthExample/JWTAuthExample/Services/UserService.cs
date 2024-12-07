using JWTAuthExample.Models;

namespace JWTAuthExample.Services
{
    public class UserService
    {
        private readonly List<User> _users = new()
        {
            new User { IdUser = 1, UserName = "Phuc", Password = "12345" }
        };

        public User? Authenticate(string username, string password)
        {
            return _users.FirstOrDefault(u => u.UserName == username && u.Password == password);
        }
    }
}
