using System.Security.Cryptography;
using System.Text;

namespace UzunTec.Utils.Common
{
    public static class MD5Hash
    {
        public static string CalculateMD5Hash(this string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hash = md5.ComputeHash(inputBytes);

                // Segundo passo, converter o array de bytes em uma string haxadecimal
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}

