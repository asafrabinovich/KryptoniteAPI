public interface Kryptonite
{
    string Encrypt(string[] plaintext);
    string[] Decrypt(string ciphertext);
}