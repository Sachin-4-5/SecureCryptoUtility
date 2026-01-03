namespace SecureCryptoUtility.Models
{
    public class HybridEncryptedResult
    {
        public string EncryptedData { get; set; }
        public string EncryptedAesKey { get; set; }
        public string IV { get; set; }
    }
}