namespace SecureCryptoUtility.Interfaces
{
    public interface IAesEncryptionService
    {
        byte[] GenerateKey();
        byte[] GenerateIV();

        string Encrypt(string plainText, byte[] key, byte[] iv);
        string Decrypt(string cipherText, byte[] key, byte[] iv);
    }
}