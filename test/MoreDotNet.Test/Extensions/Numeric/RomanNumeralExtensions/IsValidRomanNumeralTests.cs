namespace MoreDotNet.Test.Extensions.Numeric.RomanNumeralExtensions
{
    using System;

    using MoreDotNet.Extensions.Numeric;
    using MoreDotNet.Test.Extensions.Numeric.RomanNumeralExtensions.Base;

    using Xunit;

    public class IsValidRomanNumeralTests : RomanNumeralTestBase
    {
        [Theory]
        [MemberData(nameof(CorrectRomanNumbers))]
        public void IsValidRomanNumeral_GivenCorrectNumber_ShouldReturnTrue(string romanNumber)
        {
            Assert.True(romanNumber.IsValidRomanNumeral());
        }

        [Theory]
        [MemberData(nameof(IncorrectRomanNumbers))]
        public void IsValidRomanNumeral_GivenIncorrectNumber_ShouldReturnFalse(string incorrectNumber)
        {
            Assert.False(incorrectNumber.IsValidRomanNumeral());
        }

        [Fact]
        public void IsValidRomanNumeral_GivenNullNumber_ShouldThrowException()
        {
            string nullRomanNumeral = null;
            Assert.Throws<ArgumentNullException>(() => nullRomanNumeral.IsValidRomanNumeral());
        }
    }
}
