using KryptoniteAPI.Exceptions;
using KryptoniteAPI.Interfaces;
using System;

namespace KryptoniteAPI.Services
{
    public class KryptoniteService : IKryptoniteService
    {
        Kryptonite kryptonite;
        public void SetCipherInstace(string encryptionImplimentationName)
        {
            if (string.IsNullOrEmpty(encryptionImplimentationName))
            {
                throw new InvalidConfigurationException("encryptionImplimentationName is null or empty - check if the implemantion is configured in the appsettings");

            }
            Kryptonite res;
            switch (encryptionImplimentationName)
            {
                case "AES":
                    res = new AESKryptonite.AESKryptonite();
                    break;
                case "Ceaser":
                    res = new CeaserKryptonite.CaesarKryptonite();
                    break;
                default:
                    throw new InvalidConfigurationException("encryptionImplimentationName is invalid - check if the implemantion is configured correctly in the appsettings");
            }
            kryptonite = res;
        }

        public string[] Decrypt(string ciphertext)
        {
            return kryptonite.Decrypt(ciphertext);
        }

        public string Encrypt(string[] plaintext)
        {
            return kryptonite.Encrypt(plaintext);
        }
    }
}
