using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AESKryptonite
{
    public class AESKryptonite : Kryptonite
    {
        private readonly string privateKey = "fUjXn2r4u7x!A%D*G-KaPdSgVkYp3s6v";
        public string Encrypt(string[] textToEncrypt)
        {
            string inputString = string.Join(" ", textToEncrypt);
            byte[] keyBytes = Encoding.UTF8.GetBytes(privateKey);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.KeySize = 256;
            aes.Key = keyBytes;
            aes.Padding = PaddingMode.PKCS7;
            aes.GenerateIV();
            byte[] iv = aes.IV;
            byte[] inputBytes = Encoding.Unicode.GetBytes(inputString);
            MemoryStream ms = new MemoryStream();
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, iv);
            CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            cs.Write(inputBytes, 0, inputBytes.Length);
            cs.FlushFinalBlock();
            cs.Close();
            ms.Close();
            byte[] cipherTextBytes = ms.ToArray();
            byte[] result = new byte[iv.Length + cipherTextBytes.Length];
            Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
            Buffer.BlockCopy(cipherTextBytes, 0, result, iv.Length, cipherTextBytes.Length);
            return Convert.ToBase64String(result);
        }
        public string[] Decrypt(string textToDecrypt)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(privateKey);
            byte[] inputBytes = Convert.FromBase64String(textToDecrypt);
            byte[] ivBytes = new byte[16];
            Array.Copy(inputBytes, 0, ivBytes, 0, 16);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.KeySize = 256;
            aes.Key = keyBytes;
            aes.IV = ivBytes;
            aes.Padding = PaddingMode.PKCS7;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputBytes, 16, inputBytes.Length - 16);
            cs.FlushFinalBlock();
            cs.Close();
            ms.Close();
            return Encoding.Unicode.GetString(ms.ToArray()).Split(' ');
        }
    }
}
