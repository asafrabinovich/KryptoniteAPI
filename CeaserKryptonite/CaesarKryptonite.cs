using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeaserKryptonite
{
    public class CaesarKryptonite : Kryptonite
    {
        private readonly int shift = 3;
        public string Encrypt(string[] textToEncrypt)
        {
            string inputString = string.Join(" ", textToEncrypt);
            string outputString = "";
            foreach (char c in inputString)
            {
                if (!char.IsLetter(c))
                {
                    outputString += c;
                }
                else
                {
                    char shiftedChar = (char)(c + shift);
                    if (char.IsUpper(c) && shiftedChar > 'Z' || char.IsLower(c) && shiftedChar > 'z')
                    {
                        shiftedChar = (char)(c - (26 - shift));
                    }
                    outputString += shiftedChar;
                }
            }
            return outputString;
        }
        public string[] Decrypt(string textToDecrypt)
        {
            string outputString = "";
            foreach (char c in textToDecrypt)
            {
                if (!char.IsLetter(c))
                {
                    outputString += c;
                }
                else
                {
                    char shiftedChar = (char)(c - shift);
                    if (char.IsUpper(c) && shiftedChar < 'A' || char.IsLower(c) && shiftedChar < 'a')
                    {
                        shiftedChar = (char)(c + (26 - shift));
                    }
                    outputString += shiftedChar;
                }
            }
            return outputString.Split(' ');
        }
    }
}
