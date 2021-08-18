using System;
using Xunit;
using PasswordVerifierKata;

namespace PasswordVerifierKata_Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("wizardofoz", false)]
        [InlineData("theman00", true)]
        [InlineData("007", true)]
        [InlineData("timeforasnack", false)]
        [InlineData("the1", true)]
        [InlineData("theguys1", true)]
        [InlineData("THEGUYS1", true)]
        public void TestContainsNumber(string input, bool expected)
        {
            Assert.Equal(expected, PasswordVerifier.ContainsNumber(input));
        }

        [Theory]
        [InlineData("helloWorld", true)]
        [InlineData("mynameistristin", false)]
        [InlineData("H", true)]
        [InlineData("w", false)]
        [InlineData("the1", false)]
        [InlineData("theguys1", false)]
        [InlineData("THEGUYS1", true)]
        public void TestContainsUpper(string input, bool expected)
        {
            bool actual = PasswordVerifier.ContainsUpper(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("HELLOWORLD", false)]
        [InlineData("higuys", true)]
        [InlineData("c#ismyfavorite:)", true)]
        [InlineData("the1", true)]
        [InlineData("theguys1", true)]
        [InlineData("THEGUYS1", false)]
        public void TestContainsLower(string input, bool expected)
        {
            Assert.Equal(expected, PasswordVerifier.ContainsLower(input));
        }

        [Theory]
        [InlineData("Thebigbrowndog", true)]
        [InlineData("Thecat", false)]
        [InlineData("Thesmallmouse", true)]
        [InlineData("the1", false)]
        [InlineData("theguys1", true)]
        [InlineData("THEGUYS1", true)]
        public void TestVerifyLength(string input, bool expected)
        {
            Assert.Equal(expected, PasswordVerifier.VerifyLength(input));
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("I", true)]
        [InlineData("", true)]
        [InlineData("the1", true)]
        [InlineData("theguys1", true)]
        [InlineData("THEGUYS1", true)]
        public void TestVerifyNull(string input, bool expected)
        {
            Assert.Equal(expected, PasswordVerifier.VerifyNull(input));
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("Hellofriends1", true)]
        [InlineData("HELLOFELLOWPEOPLE1", false)]
        [InlineData("hellofellowpeople1", true)]
        [InlineData("Hellofellows1", true)]
        [InlineData("Theguy1", true)]
        [InlineData("Theguys1", true)]
        [InlineData("the", false)]
        [InlineData("theguys", false)]
        [InlineData("THEGUYS", false)]
        public void TestVerify(string input, bool expected)
        {
            Assert.Equal(expected, PasswordVerifier.Verify(input));
        }
    }
}
