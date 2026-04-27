using Backend.Services;
using Database;
using Database.Models;

public class UserService : IUserService
{
    private readonly IJwtService _jwtService;
    private readonly DatabaseContext _context;

    public UserService(IJwtService jwtService, DatabaseContext context)
    {
        _jwtService = jwtService;
        _context = context;
    }

    public (string Token, int UserId) CreateUser(string name, string email, string password)
    {
        var salt = PasswordHelper.GenerateRandomSalt();
        var user = new User
        {
            Name = name,
            PasswordHash = PasswordHelper.HashPassword(password, salt),
            PasswordSalt = salt,
            Email = email
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return (_jwtService.GenerateToken(user), user.Id);
    }

    public (string Token, int UserId) LogIn(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);

        if (user == null || !PasswordHelper.ComparePasswords(password,user.PasswordSalt, user.PasswordHash))
        {
            return (string.Empty, -1);
        }

        return (_jwtService.GenerateToken(user), user.Id);
    }

    public User FindUserByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email);
    }

    public int UserCount()
    {
        return _context.Users.Count();
    }

    public bool VerifyEmailOk(int userId, string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return true;
        }

        var emailOwner = _context.Users.FirstOrDefault(u => u.Email == email);

        if (emailOwner == null)
        {
            return true;
        }

        return emailOwner.Id == userId;
    }

    public bool UpdateUser(int UserId, string name, string email, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == UserId);

        if (user == null)
        {
            return false;
        }

        if (!string.IsNullOrWhiteSpace(name))
        {
            user.Name = name;
        }

        if (!string.IsNullOrWhiteSpace(email))
        {
            user.Email = email;
        }

        if (!string.IsNullOrWhiteSpace(password))
        {
            user.PasswordHash = PasswordHelper.HashPassword(password, user.PasswordSalt);
        }

        _context.SaveChanges();
        return true;
    }

    public (string Name, string Email) GetUserDetails(int userId)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);

        return (user?.Name, user?.Email);
    }
}
