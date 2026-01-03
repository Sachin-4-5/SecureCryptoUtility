namespace SecureCryptoUtility.Interfaces
{
    public interface IRsaEncryptionService
    {
        string Encrypt(string data);
        string Decrypt(string cipherText);
    }
}