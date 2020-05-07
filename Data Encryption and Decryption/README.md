## Steps to encrypt and decypt data Symmetrically
- Using **System.Security.Cryptography** and **System.IO**
- 1. Create an **Rfc2898DeriveBytes** object
- 2. Create an **AesManaged** object
- 3. Generate a **secret key** and an **IV (byte[])**
- 4. Create a stream to buffer the transformed (encrypted/unencrypted) data
- 5. Create a Symmetric encryptor/ decryptor object
- 6. Create a **CryptoStream** object
- 7. Write the transformed data to the buffer stream
- 8. Close the streams
