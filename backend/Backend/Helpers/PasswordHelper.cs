using System.Text;
using System.Security.Cryptography;

namespace Backend.Services
{
    public static class PasswordHelper
    {
        public static bool ComparePasswords(string plainPassword, string salt, string hashedPassword)
        {
            var password = HashPassword(plainPassword, salt);
            return password == hashedPassword;
        }

        public static string GenerateRandomSalt(int size = 16)
        {
            var bytes = new byte[size];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        public static string HashPassword(string password, string salt)
        {
            using var sha256 = SHA256.Create();
            var combined = Encoding.UTF8.GetBytes(salt + password);
            var hash = sha256.ComputeHash(combined);
            return Convert.ToBase64String(hash);
        }


    }
}
