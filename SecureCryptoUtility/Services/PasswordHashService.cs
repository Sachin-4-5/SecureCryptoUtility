using SecureCryptoUtility.Interfaces;
using SecureCryptoUtility.Models;
using System.Security.Cryptography;

namespace SecureCryptoUtility.Services
{
    public class PasswordHashService : IPasswordHashService
    {
        private const int Iterations = 100_000;
        private const int KeySize = 32;

        public PasswordHashResult HashPassword(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(16);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, KeySize);
            return new PasswordHashResult
            {
                Hash = Convert.ToBase64String(hash),
                Salt = Convert.ToBase64String(salt)
            };
        }

        public bool VerifyPassword(string password, PasswordHashResult hashResult)
        {
            var salt = Convert.FromBase64String(hashResult.Salt);
            var computedHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, KeySize);
            return CryptographicOperations.FixedTimeEquals(computedHash, Convert.FromBase64String(hashResult.Hash));
        }
    }
}