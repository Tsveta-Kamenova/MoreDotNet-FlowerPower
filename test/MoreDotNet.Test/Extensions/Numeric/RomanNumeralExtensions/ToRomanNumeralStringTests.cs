namespace MoreDotNet.Test.Extensions.Numeric.RomanNumeralExtensions
{
    using System;
    using System.Collections.Generic;

    using MoreDotNet.Extensions.Numeric;
    using MoreDotNet.Test.Extensions.Numeric.RomanNumeralExtensions.Base;

    using Xunit;

    public class ToRomanNumeralStringTests : RomanNumeralTestBase
    {
        [Theory]
        [MemberData(nameof(RommanToArrabicNumberMappings))]
        public void ToRomanNumeralString_Given2_ShouldReturnII(string romanNumber, int arrabicNumber)
        {
            var actual = arrabicNumber.ToRomanNumeralString();
            Assert.Equal(romanNumber, actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(4000)]
        public void ToRomanNumeralString_GivenNumberOutOfRange_ShouldThrowException(int incorrectNumber)
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => incorrectNumber.ToRomanNumeralString());
        }
    }
}
