using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace UzunTec.Utils.Common.Test
{
    public class ParsePercentualTest
    {
        private readonly IFormatProvider defaultFormatProvider = CultureInfo.InvariantCulture;

        public static IEnumerable<object[]> GetParsePercentualMassTests()
        {
            return new List<object[]>
            {
                new object[] {"0", 0},
                new object[] {"0.00", 0},
                new object[] {"123", 123},
                new object[] {"32.45", 32.45},
                new object[] {"10%", 0.1},
                new object[] {"22.22%", 0.2222},
                new object[] {".33", .33},
                new object[] {".44%", 0.0044},
            };
        }

        [Theory]
        [MemberData(nameof(GetParsePercentualMassTests))]
        public void ParsePercentualMassTests(string original, decimal expected)
        {
            Assert.True(original.ParsePercentual(NumberStyles.Number, this.defaultFormatProvider) == expected);
        }

        [Fact]
        public void ParsePercentualTestExceptions()
        {
            Assert.Throws<FormatException>(delegate ()
            {
                "".ParsePercentual(NumberStyles.Number, this.defaultFormatProvider);
            });

            Assert.Throws<FormatException>(delegate ()
            {
                "asdfg".ParsePercentual(NumberStyles.Number, this.defaultFormatProvider);
            });
            Assert.Throws<NullReferenceException>(delegate ()
            {
                StringUtils.ParsePercentual(null, NumberStyles.Number, this.defaultFormatProvider);
            });
        }

    }
}
