using System.Collections.Generic;
using Xunit;

namespace UzunTec.Utils.Common.Test
{
    public class NumericStringTest
    {
        private readonly char decimalSeparator = '.';

        public static IEnumerable<object[]> GetNumericStringMassTests()
        {
            return new List<object[]>
            {
                new object[] {"0", "0"},
                new object[] {"-10", "-10"},
                new object[] {"+11", "11"},
                new object[] {"-12.3", "-12.3"},
                new object[] {"  - 32.45", "-32.45"},
                new object[] {"10%", "10%"},
                new object[] {"-  12asssdd-0.22", "-120.22"},
                new object[] {"--------33", "-33"},
                new object[] {"  - 33", "-33"},
                new object[] {"aaa - 33", "-33"},
                new object[] {"assda]3asdasd-- -dd-2+rree]12[33.4", "321233.4"},
                new object[] {"the smart brown fox jumps over the lazy dog", ""},
                new object[] {",,,,", ""},
                new object[] {"....", ""},
                new object[] {"%%%%", "%"},
                new object[] {"------", "-"},
            };
        }

        [Theory]
        [MemberData(nameof(GetNumericStringMassTests))]
        public void NumericStringMassTests(string original, string expected)
        {
            Assert.True(original.ToNumericString(this.decimalSeparator) == expected);
        }

    }
}
