using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace UzunTec.Utils.Common
{
    public static class StringUtils
    {
        public static string GenerateRandomString(int size)
        {
            const int maxRand = ('z' - 'a') + ('9' - '0') + ('Z' - 'A') + 1;

            char[] word = new char[size];

            Random rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                char c = (char)(rnd.Next() % maxRand);

                c += '0';  
                if (c > '9')
                {
                    c += (char)('A' - '9');  
                    if (c > 'Z')
                    {
                        c += (char)('a' - 'Z'); 
                    }
                }

                word[i] = c;

            }

            return new string(word);

        }


        public static string UrlEncode(string str)
        {
            StringBuilder escapedString = new StringBuilder();
            int max = str.Length;

            for (int i = 0; i < max; i++)
            {
                if ((48 <= str[i] && str[i] <= 57) ||//0-9
                     (65 <= str[i] && str[i] <= 90) ||//abc...xyz
                     (97 <= str[i] && str[i] <= 122) || //ABC...XYZ
                     (str[i] == '~' || str[i] == '!' || str[i] == '*' || str[i] == '(' || str[i] == ')' || str[i] == '\'')) //~!*()'
                {
                    escapedString.Append(str[i]);
                }
                else
                {
                    escapedString.Append("%");
                    escapedString.Append(String.Format("{0:x2}", str[i]));
                }
            }

            return escapedString.ToString();
        }

        public static string UrlDecode(string str)
        {
            List<byte> listBytesToEncode = new List<byte>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '%')
                {
                    string hexCode = str.Substring(i + 1, 2);  // Pega o Codigo Hexa
                    byte b = Byte.Parse(hexCode, System.Globalization.NumberStyles.HexNumber);
                    listBytesToEncode.Add(b);
                    i += 2;
                }
                else
                    listBytesToEncode.Add((byte)str[i]);
            }

            return System.Text.Encoding.Default.GetString(listBytesToEncode.ToArray());

        }

        public static string RemoveAccents(this string texto)
        {
            string s = texto.Normalize(NormalizationForm.FormD);

            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < s.Length; k++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(s[k]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(s[k]);
                }
            }
            return sb.ToString();
        }


        public static string ToTitleCase(this string value)
        {
            return value.ToUpper().Substring(0, 1) + value.ToLower().Substring(1);
        }

        public static string PadronizaSeparadorDecimal(this string value)
        {
            string separadorDecimalPadrao = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;

            value = value.Replace(".", separadorDecimalPadrao);
            value = value.Replace(",", separadorDecimalPadrao);


            string[] arr = value.Split(separadorDecimalPadrao.ToCharArray());

            if (arr.Length > 1)
            {
                string parteDecimal = arr[arr.Length - 1];
                arr[arr.Length - 1] = "";
                value = String.Join("", arr) + separadorDecimalPadrao + parteDecimal;
            }

            return value;
        }

        public static string RemoveLetters(this string value)
        {
            char[] word = new char[value.Length];
            string valor = "";
            double aux;
            word = value.ToCharArray();

            for (int i = 0; i < word.Length; i++)
            {
                if (!valor.Contains(".") || !valor.Contains(","))
                {
                    if (word[i].Equals(',') || word[i].Equals('.'))
                        valor += word[i];
                    else if (Double.TryParse(word[i].ToString(), out aux))
                        valor += aux.ToString();
                }
                else if (Double.TryParse(word[i].ToString(), out aux))
                {
                    valor += aux.ToString();
                }
            }

            return valor;
        }

        public static bool IsValidEmail(this string login)
        {
            string regex = "^(?:" +
            "(\"\\s*(?:[^\"\\f\\n\\r\\t\\v\\b\\s]+\\s*)+\")|" +
            "([-\\w!\\#\\$%\\&\\'*+~/^`|{}]+(?:\\.[-\\w!\\#\\$%\\&\\'*+~/^`|{}]+)*))" +
            "@(((\\[)?" +
            "(?:(?:(?:(?:25[0-5])|(?:2[0-4][0-9])|(?:[0-1]?[0-9]?[0-9]))\\.){3}" +
            "(?:(?:25[0-5])|(?:2[0-4][0-9])|(?:[0-1]?[0-9]?[0-9]))))(?(5)\\])|" +
            "((?:[a-z0-9](?:[-a-z0-9]*[a-z0-9])?\\.)*[a-z0-9](?:[-a-z0-9]*[a-z0-9])?)" +
            "\\.((?:([^- ])[-a-z]*[-a-z])?))" +
            "$";


            Match matches = Regex.Match(login, regex);

            if (matches.Success)
                return true;
            else
                return false;
        }

        
        public static string SimplifyString(this string str)
        {
            foreach (char deletedChar in " -/\\\"\'")
                str = str.Replace(deletedChar.ToString(), "");

            return str.RemoveAccents().ToLower().Trim();
        }

        public static string OnlyNumbers(this string str)
        {
            Regex regexObj = new Regex(@"[^\d]");
            return regexObj.Replace(str, "");
        }
                
    }
}
