using SecureCryptoUtility.Interfaces;
using System.Security.Cryptography;

namespace SecureCryptoUtility.Services
{
    public class FileEncryptionService : IFileEncryptionService
    {
        public void EncryptFile(string inputPath, string outputPath, byte[] key, byte[] iv)
        {
            using var aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            using var fsIn = new FileStream(inputPath, FileMode.Open);
            using var fsOut = new FileStream(outputPath, FileMode.Create);
            using var crypto = new CryptoStream(fsOut, aes.CreateEncryptor(), CryptoStreamMode.Write);

            fsIn.CopyTo(crypto);
        }

        public void DecryptFile(string inputPath, string outputPath, byte[] key, byte[] iv)
        {
            using var aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;

            using var fsIn = new FileStream(inputPath, FileMode.Open);
            using var crypto = new CryptoStream(fsIn, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using var fsOut = new FileStream(outputPath, FileMode.Create);

            crypto.CopyTo(fsOut);
        }
    }
}