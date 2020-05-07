using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Encyption
{
    class Program
    {
        static void Main(string[] args)
        {
            var password = "Password";
            var salt = "s@lt";  // would choose a random salt each time

            var algorithm = new AesManaged();   // Choose the encrytion algorithm
            var rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

            Console.WriteLine("=========== Using Unicode =========");
            foreach(var b in Encoding.Unicode.GetBytes(salt))
            {
                Console.Write(b + " ");
            }
            Console.WriteLine("\n\n=========== Using ASCII =========");
            foreach (var b in Encoding.ASCII.GetBytes(salt))
            {
                Console.Write(b + " ");
            }

            var rgbKey = rgb.GetBytes(algorithm.KeySize / 8);
            var rgbIV = rgb.GetBytes(algorithm.BlockSize / 8);

            var bufferStream = new MemoryStream();  // using System.IO;

            // The Encryptor object:
            var transformer = algorithm.CreateEncryptor(rgbKey, rgbIV);
            var cryptoStream = new CryptoStream(bufferStream, transformer, CryptoStreamMode.Write);

            var cipherText = "Hello World";
            var bytesToTransform = Encoding.ASCII.GetBytes(cipherText);
            cryptoStream.Write(bytesToTransform, 0, bytesToTransform.Length);

            cryptoStream.FlushFinalBlock();
            Console.WriteLine("\n\n========== Bytes in bufferStream after cryptoStream.FlushFinalBlock =========");
            foreach (var b in bufferStream.GetBuffer())
            {
                Console.Write(b + " ");
            }

            cryptoStream.Close();
            bufferStream.Close();

            Console.WriteLine('\n');
            Console.ReadKey();
        }
    }
}
