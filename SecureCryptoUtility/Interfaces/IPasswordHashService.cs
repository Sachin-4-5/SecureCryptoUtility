using SecureCryptoUtility.Models;

namespace SecureCryptoUtility.Interfaces
{
    public interface IPasswordHashService
    {
        PasswordHashResult HashPassword(string password);
        bool VerifyPassword(string password, PasswordHashResult hashResult);
    }
}