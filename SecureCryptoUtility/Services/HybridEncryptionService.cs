using SecureCryptoUtility.Interfaces;
using SecureCryptoUtility.Models;

namespace SecureCryptoUtility.Services
{
    public class HybridEncryptionService : IHybridEncryptionService
    {
        private readonly IAesEncryptionService _aes;
        private readonly IRsaEncryptionService _rsa;

        public HybridEncryptionService(IAesEncryptionService aes, IRsaEncryptionService rsa)
        {
            _aes = aes;
            _rsa = rsa;
        }

        public HybridEncryptedResult Encrypt(string plainText)
        {
            var key = _aes.GenerateKey();
            var iv = _aes.GenerateIV();
            return new HybridEncryptedResult
            {
                EncryptedData = _aes.Encrypt(plainText, key, iv),
                EncryptedAesKey = _rsa.Encrypt(Convert.ToBase64String(key)),
                IV = Convert.ToBase64String(iv)
            };
        }

        public string Decrypt(HybridEncryptedResult data)
        {
            var key = Convert.FromBase64String(_rsa.Decrypt(data.EncryptedAesKey));
            var iv = Convert.FromBase64String(data.IV);
            return _aes.Decrypt(data.EncryptedData, key, iv);
        }
    }
}