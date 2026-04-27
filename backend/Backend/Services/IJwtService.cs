using Database.Models;

namespace Backend.Services
{
    public interface IJwtService
    {
        public string GenerateToken(User user);
    }
}
