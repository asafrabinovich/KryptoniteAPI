using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KryptoniteAPI.Interfaces
{
    public interface IKryptoniteService
    {
        string Encrypt(string[] plaintext);
        string[] Decrypt(string ciphertext);
        void SetCipherInstace(string encryptionImplimentationName);

    }
}
