using System.Collections.Generic;
using Xunit;

namespace UzunTec.Utils.Common.Test
{
    public class RemoveAccentTest
    {
        public static IEnumerable<object[]> GetRemoveAccentMassTests()
        {
            return new List<object[]>
            {
                new string[] {"", ""},
                new string[] {"abcd", "abcd"},
                new string[] {"ã", "a"},
                new string[] {"áàâ", "aaa"},
                new string[] {"èéê", "eee"},
                new string[] {"\0", "\0"},
                new string[] {"ãáàâéèêíìîõóòôùúû", "aaaaeeeiiioooouuu"},
                new string[] {"ñ", "n"},
                new string[] {"\\&^$$@#$!!'`\"", "\\&^$$@#$!!'`\""},
            };
        }

        [Theory]
        [MemberData(nameof(GetRemoveAccentMassTests))]
        public void RemoveAccentsMassTest(string original, string expected)
        {
            Assert.Equal(expected, original.RemoveAccents());
        }

    }
}
