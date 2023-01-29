using System;
using System.Security.Cryptography;
using System.Text;

public class RSAKryptonite : Kryptonite
{
    private readonly RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
    private readonly string privateKey = "fUjXn2r4u7x!A%D*G-KaPdSgVkYp3s6v";
    public RSAKryptonite()
    {
        RSAParameters rsap = new RSAParameters();
        rsap.D = 
        rsa.KeySize = 2048;
        rsa.PersistKeyInCsp = false;
        rsa.CspKeyContainerInfo. = Encoding.Unicode.GetBytes(privateKey);

    }

    public string Encrypt(string[] textToEncrypt)
    {
        string inputString = string.Join(" ", textToEncrypt);
        byte[] inputBytes = Encoding.Unicode.GetBytes(inputString);
        byte[] encryptedBytes = rsa.Encrypt(inputBytes, true);
        return Convert.ToBase64String(encryptedBytes);
    }

    public string[] Decrypt(string textToDecrypt)
    {
        byte[] encryptedBytes = Convert.FromBase64String(textToDecrypt);
        byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, true);
        return Encoding.Unicode.GetString(decryptedBytes).Split(' ');
    }

    public string ExportPublicKey()
    {
        return Convert.ToBase64String(rsa.ExportCspBlob(false));
    }

    public void ImportPublicKey(string publicKey)
    {
        rsa.ImportCspBlob(Convert.FromBase64String(publicKey));
    }
}
