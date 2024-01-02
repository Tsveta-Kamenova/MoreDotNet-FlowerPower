namespace MoreDotNet.Test.Extensions.Numeric.RomanNumeralExtensions
{
    using System;
    using System.Collections.Generic;

    using MoreDotNet.Extensions.Numeric;
    using MoreDotNet.Test.Extensions.Numeric.RomanNumeralExtensions.Base;

    using Xunit;

    public class ParseRomanNumeralTests : RomanNumeralTestBase
    {
        [Theory]
        [MemberData(nameof(RommanToArrabicNumberMappings))]
        public void ParseRomanNumeral_GivenCorrectRomanNumber_ShouldReturnCorrectArabicNumber(string romanNumber, int arrabicNumber)
        {
            var actual = romanNumber.ParseRomanNumeral();
            Assert.Equal(arrabicNumber, actual);
        }

        [Theory]
        [MemberData(nameof(IncorrectRomanNumbers))]
        public void ParseRomanNumeral_GivenIncorrectNumber_ShouldThrowException(string incorrectNumber)
        {
            Assert.Throws<ArgumentException>(() => incorrectNumber.ParseRomanNumeral());
        }

        [Fact]
        public void ParseRomanNumeral_GivenNullNumber_ShouldThrowException()
        {
            string nullRomanNumeral = null;
            Assert.Throws<ArgumentNullException>(() => nullRomanNumeral.ParseRomanNumeral());
        }
    }
}
