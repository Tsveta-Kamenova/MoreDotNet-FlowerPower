namespace MoreDotNet.Test.Extensions.Numeric.RomanNumeralExtensions.Base
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class RomanNumeralTestBase
    {
        public static IEnumerable<object[]> RommanToArrabicNumberMappings => new List<object[]>
        {
            new object[] { "I", 1 },
            new object[] { "II", 2 },
            new object[] { "III", 3 },
            new object[] { "IV", 4 },
            new object[] { "V", 5 },
            new object[] { "VI", 6 },
            new object[] { "VII", 7 },
            new object[] { "VIII", 8 },
            new object[] { "IX", 9 },
            new object[] { "X", 10 },
            new object[] { "XII", 12 },
            new object[] { "XVI", 16 },
            new object[] { "XXIX", 29 },
            new object[] { "XLIV", 44 },
            new object[] { "XLV", 45 },
            new object[] { "L", 50 },
            new object[] { "LXVIII", 68 },
            new object[] { "LXXXIII", 83 },
            new object[] { "XCVII", 97 },
            new object[] { "XCIX", 99 },
            new object[] { "C", 100 },
            new object[] { "D", 500 },
            new object[] { "DI", 501 },
            new object[] { "DCXLIX", 649 },
            new object[] { "DCCXCVIII", 798 },
            new object[] { "DCCCXCI", 891 },
            new object[] { "M", 1000 },
            new object[] { "MIV", 1004 },
            new object[] { "MVI", 1006 },
            new object[] { "MXXIII", 1023 },
            new object[] { "MMXIV", 2014 },
            new object[] { "MMMCMXCIX", 3999 },
        };

        public static IEnumerable<object[]> CorrectRomanNumbers => RommanToArrabicNumberMappings
                .Select((item) => new object[] { item[0] });

        public static IEnumerable<object[]> IncorrectRomanNumbers => new List<object[]>
        {
            new object[] { string.Empty },
            new object[] { "          " },
            new object[] { "IIII" },
            new object[] { "WWW" },
            new object[] { "axXp" },
            new object[] { "PPPPPP" },
        };
    }
}
