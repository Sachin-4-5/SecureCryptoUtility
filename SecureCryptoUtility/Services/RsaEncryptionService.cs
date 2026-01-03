using SecureCryptoUtility.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace SecureCryptoUtility.Services
{
    public class RsaEncryptionService : IRsaEncryptionService
    {
        private readonly RSA _rsa = RSA.Create(2048);

        public string Encrypt(string data)
        {
            var bytes = Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(_rsa.Encrypt(bytes, RSAEncryptionPadding.OaepSHA256));
        }

        public string Decrypt(string cipherText)
        {
            var bytes = Convert.FromBase64String(cipherText);
            return Encoding.UTF8.GetString(_rsa.Decrypt(bytes, RSAEncryptionPadding.OaepSHA256));
        }
    }
}