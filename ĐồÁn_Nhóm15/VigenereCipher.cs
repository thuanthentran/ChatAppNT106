using System;
using System.Text;

namespace ĐồÁn_Nhóm15
{
    public static class VigenereCipher
    {
        public static string Encrypt(string text, string key)
        {
            string result = string.Empty;
            key = key.ToUpper();
            int keyIndex = 0;

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    char keyChar = char.IsUpper(c) ? key[keyIndex % key.Length] : char.ToLower(key[keyIndex % key.Length]);
                    char encryptedChar = (char)((c + keyChar - 2 * offset) % 26 + offset);
                    result += encryptedChar;
                    keyIndex++;
                }
                else
                {
                    result += c;  // Giữ nguyên ký tự không phải chữ cái
                }
            }

            return result;
        }

        public static string Decrypt(string text, string key)
        {
            string result = string.Empty;
            key = key.ToUpper();
            int keyIndex = 0;

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    char keyChar = char.IsUpper(c) ? key[keyIndex % key.Length] : char.ToLower(key[keyIndex % key.Length]);
                    char decryptedChar = (char)((c - keyChar + 26) % 26 + offset);
                    result += decryptedChar;
                    keyIndex++;
                }
                else
                {
                    result += c;  // Giữ nguyên ký tự không phải chữ cái
                }
            }

            return result;
        }
    }
}
