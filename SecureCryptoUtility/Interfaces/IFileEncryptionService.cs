namespace SecureCryptoUtility.Interfaces
{
    public interface IFileEncryptionService
    {
        void EncryptFile(string inputPath, string outputPath, byte[] key, byte[] iv);
        void DecryptFile(string inputPath, string outputPath, byte[] key, byte[] iv);
    }
}