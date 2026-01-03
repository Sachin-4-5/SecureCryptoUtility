## SecureCryptoUtility


### 📘 Overview  
SecureCryptoUtility is a modern, console-based cryptography utility application developed using .NET 8 (LTS).
The application demonstrates industry-standard encryption, decryption, and hashing techniques used in real-world enterprise systems.
It is designed to help developers understand modern cryptographic standards such as AES, RSA, PBKDF2, Hybrid Encryption, and Secure File Encryption, without requiring prior knowledge of ASP.NET Core MVC or Web API.

---
<br />



### Technical Explanation
✅ Encryption is the process of converting plain text into cipher text using a cryptographic algorithm and a key. <br />
✅ Decryption converts cipher text back into readable plain text using the appropriate key. <br />
✅ Hashing is a one-way process and is mainly used for password storage (hashes cannot be decrypted). <br />

---
<br />



### 🔑 Algorithm Used
```
1️⃣ Password Hashing (PBKDF2)
    🔹 Passwords should never be encrypted. Instead, they are hashed using: Salt, Iterations, Secure hashing algorithms.
    🔹 It uses algorithm PBKDF2 with SHA-256.
    🔹 PBKDF2 is a Password-Based Key Derivation Function in which a key is generated from the Password. The generated key can be used as an encryption key or as a hash value that needs to be stored in the db.
    🔹 Use cases: User authentication, Secure credential storage, soon.
   
2️⃣ AES Encryption (Symmetric Encryption)
    🔹 AES (Advanced Encryption Standard) is a symmetric encryption algorithm i.e., same secret key is used for encryption and decryption.
    🔹 Key features: AES-256 encryption, Random IV generation, Key derived securely using PBKDF2, Base64 encoded output.
    🔹 Use case: Encrypt sensitive configuration values, Secure tokens, etc.

3️⃣ RSA Encryption (Asymetric Encryption)
    🔹 Uses two keys - public key (Encrypt) and private keys (Decrypt).
    🔹 Key features: Public key can be shared, Private key must be kept secret, Slower than AES, but more secure for key exchange
    🔹 Use case: Secure key exchange, Digital security mechanisms, Hybrid encryption systems

4️⃣ Hybrid Encryption (AES + RSA)
    🔹 Combines the strengths of AES and RSA: Data is encrypted using AES (fast) and AES key is encrypted using RSA (secure)
    🔹 Problem with AES alone is that AES is fast, But key sharing is insecure. Also, RSA is secure But very slow and Cannot encrypt large data (files, JSON, XML).
    🔹 Secure file transfer systems, HTTPS/TLS, Large-scale enterprise communication.

5️⃣ Secure File Encryption
    🔹 Entire files are encrypted using AES-256
    🔹 Uses streaming (FileStream + CryptoStream)
    🔹 Suitable for large files
    🔹 Use case: Encrypt reports, Protect exported CSV / Excel files, Secure sensitive documents

```

---
<br />



### 🚀 Features  
✅ Secure password hashing using PBKDF2 <br />
✅ AES-256 encryption with secure IV handling <br />
✅ RSA encryption for secure key exchange <br />
✅ Hybrid encryption (AES + RSA) implementation <br />
✅ Secure file encryption using streaming APIs <br />
✅ Environment-based key management (no hardcoding) <br />
✅ Clean, layered architecture <br />
✅ Console-based UI for easy testing and learning <br />

---
<br />



### 📌 Project Configuration
1️⃣ Project Name: SecureCryptoUtility <br />
2️⃣ Solution Name: SecureCryptoUtility.sln <br />
3️⃣ Framework: .NET 8 (LTS) <br />
4️⃣ Application Type: Console Application <br />
5️⃣ Language: C# <br />
6️⃣ Cryptography APIs: System.Security.Cryptography <br />
7️⃣ Tools: Visual Studio 2022, .NET SDK <br />

---
<br />



### 🎓 Project structure
```
SecureCryptoUtility
│
├── bin/
├── obj/
├── Interfaces/
│   ├── IAesEncryptionService.cs
│   ├── IRsaEncryptionService.cs
│   ├── IHybridEncryptionService.cs
│   ├── IPasswordHashService.cs
│   └── IFileEncryptionService.cs
│
├── Models/
│   ├── HybridEncryptedResult.cs
│   └── PasswordHashResult.cs
│
├── Services/
│   ├── AesEncryptionService.cs
│   ├── RsaEncryptionService.cs
│   ├── HybridEncryptionService.cs
│   ├── PasswordHashService.cs
│   └── FileEncryptionService.cs
│
├── Program.cs
└── appsettings.json


```

---
<br />



### 📍 Project Architecture Highlights
🔹 Clean Architecture principles <br />
🔹 SOLID design principles <br />
🔹 Interface-based programming <br />
🔹 Dependency Injection (DI) <br />
🔹 Secure coding best practices <br />
🔹 Easy migration to ASP.NET Core Web API later <br />

---
<br />



### 🎯 Learning Outcomes (Interview Ready)
✅ Difference between Encryption and Hashing <br />
✅ When to use AES vs RSA <br />
✅ Why passwords must be hashed, not encrypted <br />
✅ How hybrid encryption works in real systems <br />
✅ Secure key handling in modern .NET <br />
✅ Enterprise-level cryptography design patterns <br />

---
<br />



### 💡 Future Enhancements
🔹 Multi-threading / parallel file processing <br />
🔹 Support for CSV, Excel, JSON inputs <br />
🔹 Support for multiple databases (MySQL, PostgreSQL) <br />
🔹 Unit testing using NUnit Framework <br />
🔹 Retry & recovery mechanism <br />
🔹 Scheduler / Windows Task integration <br />

---
<br />



### 🤝 Contribution
Pull requests are welcome! To contribute:

1️⃣ Fork the repo <br />
2️⃣ Create a feature branch (git checkout -b feature-xyz) <br />
3️⃣ Commit changes (git commit -m "Added feature xyz") <br />
4️⃣ Push to your branch (git push origin feature-xyz) <br />
5️⃣ Create a pull request 

---
<br />



### 📄 License
This project is intended for learning and demonstration purposes. <br />
You are free to modify and extend it for personal or educational use.

---
<br />
<br />



















