using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace UzunTec.Utils.Common
{
    public static class EncryptUtils
    {
        private const string BASE_KEY = "UzunTecCommomUtils-Encrypt-Library-50DBF5C0-3E2F-4AA8-8DA5-2F88CA633126";
        private static readonly byte[] intialVector = new byte[16];

        public static string Encrypt(this string text, string key = BASE_KEY)
        {
            if (!string.IsNullOrEmpty(text))
            {
                byte[] textBytes = Encoding.UTF8.GetBytes(text);
                byte[] encriptionKey = GetEncriptionKey(key);

                Rijndael rijndael = new RijndaelManaged
                {
                    KeySize = 256,
                };

                MemoryStream mStream = new MemoryStream();
                CryptoStream encryptor = new CryptoStream(
                    mStream,
                    rijndael.CreateEncryptor(encriptionKey, intialVector),
                    CryptoStreamMode.Write);

                encryptor.Write(textBytes, 0, textBytes.Length);
                encryptor.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            else
            {
                return null;
            }
        }


        public static string Decrypt(this string text, string key = BASE_KEY)
        {
            if (!string.IsNullOrEmpty(text))
            {
                byte[] textBytes = Convert.FromBase64String(text);
                byte[] encriptionKey = GetEncriptionKey(key);

                Rijndael rijndael = new RijndaelManaged
                {
                    KeySize = 256,
                };
                MemoryStream mStream = new MemoryStream();
                CryptoStream decryptor = new CryptoStream(
                    mStream,
                    rijndael.CreateDecryptor(encriptionKey, intialVector),
                    CryptoStreamMode.Write);

                decryptor.Write(textBytes, 0, textBytes.Length);
                decryptor.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            else
            {
                return null;
            }
        }

        private static byte[] GetEncriptionKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                key = BASE_KEY;
            }
            else
            {
                char glue = '-';
                if (key.Length < 34)
                {
                    for (char c = (char)10; c < 256; c++)
                    {
                        if (!key.Contains(c))
                        {
                            glue = c;
                            break;
                        }
                    }
                }
                while (key.Length < 34)
                {
                    key += glue + key;
                }
            }
            byte[] baseBytes = Encoding.UTF8.GetBytes(key);
            return baseBytes.Take(32).ToArray();
        }
    }
}
