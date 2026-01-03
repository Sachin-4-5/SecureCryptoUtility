using SecureCryptoUtility.Models;
namespace SecureCryptoUtility.Interfaces
{
    public interface IHybridEncryptionService
    {
        HybridEncryptedResult Encrypt(string plainText);
        string Decrypt(HybridEncryptedResult data);
    }
}