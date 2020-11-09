using System.Collections.Generic;
using Xunit;

namespace UzunTec.Utils.Common.Test
{
    public class CharUtilsTest
    {
        public static IEnumerable<object[]> GetToLowerMassTests()
        {
            return new List<object[]>
            {
                new object[] {'a', 'a'},
                new object[] {'A', 'a'},
                new object[] {'z', 'z'},
                new object[] {'Z', 'z'},
                new object[] {'\\', '\\'},
                new object[] {'0', '0'},
                new object[] {'9', '9'},
            };
        }

        public static IEnumerable<object[]> GetToUpperMassTests()
        {
            return new List<object[]>
            {
                new object[] {'a', 'A'},
                new object[] {'A', 'A'},
                new object[] {'z', 'Z'},
                new object[] {'Z', 'Z'},
                new object[] {'\\', '\\'},
                new object[] {'0', '0'},
                new object[] {'9', '9'},
            };
        }

        [Theory]
        [MemberData(nameof(GetToLowerMassTests))]
        public void ToLowerMassTests(char original, char expected)
        {
            Assert.True(original.ToLower() == expected);
        }

        [Theory]
        [MemberData(nameof(GetToUpperMassTests))]
        public void ToUpperMassTests(char original, char expected)
        {
            Assert.True(original.ToUpper() == expected);
        }

    }
}
