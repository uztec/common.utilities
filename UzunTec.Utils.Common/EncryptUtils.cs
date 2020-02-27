using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace UzunTec.Utils.Common
{
    public static class EncryptUtils
    {
        private static readonly string cryptoKey = "UzunTecCommomUtils-Encrypt-Library-50DBF5C0-3E2F-4AA8-8DA5-2F88CA633126";
        private static readonly byte[] intialVector = new byte[16];

        public static string Encrypt(this string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                byte[] textBytes = Encoding.UTF8.GetBytes(text);

                Rijndael rijndael = new RijndaelManaged
                {
                    KeySize = 256,
                };

                MemoryStream mStream = new MemoryStream();
                CryptoStream encryptor = new CryptoStream(
                    mStream,
                    rijndael.CreateEncryptor(Encoding.UTF8.GetBytes(cryptoKey), intialVector),
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

        public static string Decrypt(this string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                byte[] textBytes = Convert.FromBase64String(text);

                Rijndael rijndael = new RijndaelManaged
                {
                    KeySize = 256,
                };
                MemoryStream mStream = new MemoryStream();
                CryptoStream decryptor = new CryptoStream(
                    mStream,
                    rijndael.CreateDecryptor(Encoding.UTF8.GetBytes(cryptoKey), intialVector),
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
    }
}
