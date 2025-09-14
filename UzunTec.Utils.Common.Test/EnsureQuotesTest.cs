using System.Collections.Generic;
using Xunit;

namespace UzunTec.Utils.Common.Test
{
    public class EnsureQuotesTest
    {
        public static IEnumerable<object[]> GetEnsureQuotesMassTests()
        {
            return new List<object[]>
            {
                new object[] {"", '"', "\"\"", "\"\""},
                new object[] {"", '"', null, null},
                new object[] {"", '"', "", ""},
                new object[] {"hello", '"', "anything", "\"hello\""},
                new object[] {"\"hello", '"', "anything", "\"hello\""},
                new object[] {"hello\"", '"', "anything", "\"hello\""},
                new object[] {"\"hello\"", '"', "anything", "\"hello\""},
            };
        }

        [Theory]
        [MemberData(nameof(GetEnsureQuotesMassTests))]
        public void EnsureQuotesMassTest(string original, char quoteChar, string defaultIfEmpty, string expected)
        {
            Assert.Equal(expected, original.EnsureQuotes(quoteChar, defaultIfEmpty));
        }

    }
}
