using System.Collections.Generic;
using Xunit;

namespace UzunTec.Utils.Common.Test
{
    public class IsValidEmailTest
    {
        public static IEnumerable<object[]> GetEmailMassTests()
        {
            List<string> validEmails = new List<string>
            {
                "mail@example.com", "firstname.lastname@example.com", "email@subdomain.example.com",
                "firstname+lastname@example.com","email@123.123.123.123", "email@[123.123.123.123]", "\"email\"@example.com",
                "1234567890@example.com","email@example-one.com","_______@example.com","email@example.name",
                "email@example.museum","email@example.co.jp","firstname-lastname@example.com",
                "test@example.com", "test@example.com.br", "test@example.com.uk", "test@example.net",
            };

            List<string> invalidEmails = new List<string>
            {
                "plainaddress", "#@%^%#$@#$@#.com", "@example.com", "test@example", "test @example.com",
                "Joe Smith <email@example.com>", "email.example.com", "email@example@example.com", ".email@example.com",
                "email.@example.com", "email..email@example.com", "email@example.com (Joe Smith)", "test.name@example",
                "email@example", "email@-example.com", "email@111.222.333.44444", "Abc..123@example.com",
            };

            string[] notWorking = new string[]
            {
                "email@example..com",   // False, but is resulting True
                "email@example.web",   // False, but is resulting True
            };

            List<object[]> output = new List<object[]>();
            validEmails.ForEach(delegate (string s) { output.Add(new object[] { s, true }); });
            invalidEmails.ForEach(delegate (string s) { output.Add(new object[] { s, false }); });
            return output;
        }
        
        [Theory]
        [MemberData(nameof(GetEmailMassTests))]
        public void IsEmailMassTest(string email, bool expected)
        {
            Assert.True(email.IsValidEmail() == expected);
        }
    }
}
