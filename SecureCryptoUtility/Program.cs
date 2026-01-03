using SecureCryptoUtility.Interfaces;
using SecureCryptoUtility.Services;
using SecureCryptoUtility.Models;
using System.Security.Cryptography;

Console.WriteLine("🔐 Secure Crypto Utility (.NET 8)");
Console.WriteLine("--------------------------------");

IAesEncryptionService aesService = new AesEncryptionService();
IRsaEncryptionService rsaService = new RsaEncryptionService();
IHybridEncryptionService hybridService = new HybridEncryptionService(aesService, rsaService);
IPasswordHashService passwordHashService = new PasswordHashService();
IFileEncryptionService fileEncryptionService = new FileEncryptionService();

bool exit = false;
while (!exit)
{
    Console.WriteLine("\nChoose an option:");
    Console.WriteLine("1. Password Hashing (PBKDF2)");
    Console.WriteLine("2. AES Encryption");
    Console.WriteLine("3. RSA Encryption");
    Console.WriteLine("4. Hybrid Encryption (AES + RSA)");
    Console.WriteLine("5. Secure File Encryption");
    Console.WriteLine("0. Exit");

    Console.Write("Enter choice: ");
    var choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                PasswordHashingDemo(passwordHashService);
                break;

            case "2":
                AesEncryptionDemo(aesService);
                break;

            case "3":
                RsaEncryptionDemo(rsaService);
                break;

            case "4":
                HybridEncryptionDemo(hybridService);
                break;

            case "5":
                FileEncryptionDemo(aesService, fileEncryptionService);
                break;

            case "0":
                exit = true;
                Console.WriteLine("Exiting application...");
                break;

            default:
                Console.WriteLine("Invalid option. Try again.");
                break;
        }
    }
    catch (CryptographicException)
    {
        Console.WriteLine("❌ Cryptographic operation failed.");
    }
    catch (UnauthorizedAccessException)
    {
        Console.WriteLine("❌ Access denied.");
    }
    catch (IOException ex)
    {
        Console.WriteLine($"❌ File error: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Unexpected error: {ex.Message}");
    }
}



//-------------------
//Helper Methods
//-------------------

static void PasswordHashingDemo(IPasswordHashService service)
{
    try
    {
        Console.Write("\nEnter password: ");
        var password = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("❌ Password cannot be empty.");
            return;
        }

        var hashResult = service.HashPassword(password);

        Console.WriteLine("Password Hashed Successfully");
        Console.WriteLine($"Hash: {hashResult.Hash}");
        Console.WriteLine($"Salt: {hashResult.Salt}");

        Console.Write("\nRe-enter password to verify: ");
        var verifyPassword = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(verifyPassword))
        {
            Console.WriteLine("❌ Password cannot be empty.");
            return;
        }

        var isValid = service.VerifyPassword(verifyPassword, hashResult);
        Console.WriteLine(isValid ? "✅ Password Verified" : "❌ Invalid Password");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error: {ex.Message}");
    }
}


static void AesEncryptionDemo(IAesEncryptionService service)
{
    try
    {
        Console.Write("\nEnter plain text: ");
        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("❌ Input cannot be empty.");
            return;
        }

        var key = service.GenerateKey();
        var iv = service.GenerateIV();

        var encrypted = service.Encrypt(input, key, iv);
        var decrypted = service.Decrypt(encrypted, key, iv);

        Console.WriteLine($"Encrypted Text: {encrypted}");
        Console.WriteLine($"Decrypted Text: {decrypted}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error: {ex.Message}");
    }
}


static void RsaEncryptionDemo(IRsaEncryptionService service)
{
    try
    {
        Console.Write("\nEnter text to encrypt: ");
        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("❌ Input cannot be empty.");
            return;
        }

        var encrypted = service.Encrypt(input);
        var decrypted = service.Decrypt(encrypted);

        Console.WriteLine($"Encrypted Text: {encrypted}");
        Console.WriteLine($"Decrypted Text: {decrypted}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error: {ex.Message}");
    }
}


static void HybridEncryptionDemo(IHybridEncryptionService service)
{
    try
    {
        Console.Write("\nEnter text to encrypt: ");
        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("❌ Input cannot be empty.");
            return;
        }

        var encryptedResult = service.Encrypt(input);

        Console.WriteLine("\nEncrypted Data:");
        Console.WriteLine($"Cipher Text: {encryptedResult.EncryptedData}");
        Console.WriteLine($"Encrypted AES Key: {encryptedResult.EncryptedAesKey}");
        Console.WriteLine($"IV: {encryptedResult.IV}");

        var decrypted = service.Decrypt(encryptedResult);
        Console.WriteLine($"\nDecrypted Text: {decrypted}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error: {ex.Message}");
    }
}


static void FileEncryptionDemo(
    IAesEncryptionService aesService,
    IFileEncryptionService fileService)
{
    try
    {
        Console.Write("\nEnter input file path: ");
        var inputPath = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(inputPath) || !File.Exists(inputPath))
        {
            Console.WriteLine("❌ Invalid input file path.");
            return;
        }

        Console.Write("Enter encrypted file path: ");
        var encryptedPath = Console.ReadLine();

        Console.Write("Enter decrypted file path: ");
        var decryptedPath = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(encryptedPath) || string.IsNullOrWhiteSpace(decryptedPath))
        {
            Console.WriteLine("❌ Output paths cannot be empty.");
            return;
        }

        var key = aesService.GenerateKey();
        var iv = aesService.GenerateIV();

        fileService.EncryptFile(inputPath, encryptedPath, key, iv);
        Console.WriteLine("File encrypted successfully.");

        fileService.DecryptFile(encryptedPath, decryptedPath, key, iv);
        Console.WriteLine("File decrypted successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error: {ex.Message}");
    }
}