using Database.Models;

namespace Backend.Services
{
    public interface IUserService
    {
        (string Token, int UserId) CreateUser(string name, string email, string password);

        (string Token, int UserId) LogIn(string email, string password);

        public User FindUserByEmail(string email);

        public int UserCount();

        public bool VerifyEmailOk(int userId, string email);

        public bool UpdateUser(int UserId, string name, string email, string password);

        public (string Name, string Email) GetUserDetails(int userId);
    }
}
