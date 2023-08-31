using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UzunTec.Utils.Common.Test
{
    public class EncyptUtilsTest
    {
        public static IEnumerable<object[]> GetMassTest()
        {
            yield return new object[] { "Test" };
            yield return new object[] { "s" }; // Very Short string test
            yield return new object[] { "Test - A Very Large string test - Test - A Very Large string testTest - A Very Large string testTest - A Very Large string testTest - A Very Large string testvTest - A Very Large string test" };
            yield return new object[] { "Test with special chars $3#1\\!\"´[]" };
            yield return new object[] { "/?°®ŧ←ø↓þđłßĸ®µðøĸđø“°ø®?°þøßĸł“łĸłæ´«·°?°®³£¢³£}¬¢³\\§³²³" };
        }

        public static IEnumerable<object[]> GetKeys()
        {
            yield return new object[] { null };
            yield return new object[] { "s" }; // Very Short string test
            yield return new object[] { "11111111111" };
            yield return new object[] { "1111" };
            yield return new object[] { "/?°®ŧ←ø↓þđłßĸ®µðøĸđø“°ø®?°þøßĸł“łĸłæ´«·°?°®³£¢³£}¬¢³\\§³²³" };
            yield return new object[] { "{9773077A-CDC8-4A34-9B7B-76DC080DCF0F}" };
            yield return new object[] { "{03868653-542B-4E24-BA43-7B14E60C5569}-{FF087910-617C-45FC-835C-4003457BAF20}-{9A2D93D5-5E7C-46AE-A97F-0C54636D0BF2}" };
        }

        private void EncryptStringTest(string original, string key)
        {
            string output = original.Encrypt(key).Decrypt(key);
            Assert.Equal(original, output);
        }

        [Theory]
        [MemberData(nameof(GetMassTest))]
        public void EncryptStringTestBaseKey(string original)
        {
            EncryptStringTest(original, null);
        }

        [Theory]
        [MemberData(nameof(GetMassTest))]
        public void EncryptStringTestEmpty(string original)
        {
            EncryptStringTest(original, "");
        }

        [Theory]
        [MemberData(nameof(GetMassTest))]
        public void EncryptStringTestSmall(string original)
        {
            EncryptStringTest(original, "123");
        }


        [Theory]
        [MemberData(nameof(GetKeys))]
        public void EncryptStringTestWithKeyList(string key)
        {
            foreach (var values in GetMassTest())
            {
                EncryptStringTest(values[0].ToString(), key);
            }
        }

        [Theory]
        [MemberData(nameof(GetMassTest))]
        public void MustBeDifferentTest(string original)
        {
            List<string> encryptedList = new List<string>();
            foreach (var keyArray in GetKeys())
            {
                string key = keyArray[0]?.ToString();
                string encrypted = original.Encrypt(key);
                Assert.False(encryptedList.Contains(encrypted));
                encryptedList.Add(encrypted);
                Assert.Equal(original, encrypted.Decrypt(key));
            }
        }
    }
}
