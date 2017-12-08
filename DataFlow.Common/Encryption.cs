using Rijndael256;

namespace DataFlow.Common
{
    public class Encryption : RijndaelEtM
    {
        /// <summary>
        /// Encrypts plaintext using the Encrypt-then-MAC (EtM) mode via the Rijndael cipher in 
        /// CBC mode with a password derived HMAC SHA-512 salt. A random 128-bit Initialization 
        /// Vector is generated for the cipher.
        /// </summary>
        /// <param name="plainText">The plainText to encrypt.</param>
        /// <param name="encryptionKey">The encryptionKey to encrypt the plainText with.</param>
        /// <returns>The Base64 encoded EtM ciphertext.</returns>
        public static string Encrypt(string plainText, string encryptionKey)
        {
            return Encrypt(plainText, encryptionKey, KeySize.Aes256);
        }

        /// <summary>
        /// Decrypts EtM ciphertext using the Rijndael cipher in CBC mode with a password derived 
        /// HMAC SHA-512 salt.
        /// </summary>
        /// <param name="ciphertText">The Base64 encoded EtM ciphertext to decrypt.</param>
        /// <param name="encryptionKey">The encryptionKey to decrypt the EtM ciphertext with.</param>
        /// <returns>The plaintext.</returns>
        public static string Decrypt(string ciphertText, string encryptionKey)
        {
            return Decrypt(ciphertText, encryptionKey, KeySize.Aes256);
        }
    }
}
