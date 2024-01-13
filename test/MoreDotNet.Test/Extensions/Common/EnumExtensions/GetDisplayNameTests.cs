namespace MoreDotNet.Test.Extensions.Common.EnumExtensions
{
    using MoreDotNet.Extensions.Common;
    using System.ComponentModel.DataAnnotations;
    using Xunit;

    public class GetDisplayNameTests
    {
        private enum TestEnum
        {
            Default = 0,
            One = 1,
            Two = 2,
        }

        [Fact]
        public void GetDisplayName__GivenTestEnum_ShouldReturnEnumNameString()
        {
            string expected = "Default";
            TestEnum testEnum = TestEnum.Default;

            string enumName = testEnum.GetDisplayName();

            Assert.Equal(enumName, expected);
        }

        [Fact]
        public void GetDescription_GivenInvalidTestEnumValue_ShouldReturnStringValue()
        {
            string expected = "4";
            int value = 4;

            string result = ((TestEnum)value).GetDescription();

            Assert.Equal(expected, result);
        }

        //NEW TESTS 

        [Fact]
        public void GetDisplayName_GivenTestEnumOne_ShouldReturnEnumNameString()
        {
            string expected = "One";
            TestEnum testEnum = TestEnum.One;

            string enumName = testEnum.GetDisplayName();

            Assert.Equal(expected, enumName);
        }

        [Fact]
        public void GetDisplayName_GivenTestEnumTwo_ShouldReturnEnumNameString()
        {
            string expected = "Two";
            TestEnum testEnum = TestEnum.Two;

            string enumName = testEnum.GetDisplayName();

            Assert.Equal(expected, enumName);
        }

        private enum TestEnumWithCustomDisplayName
        {
            [Display(Name = "Custom One")]
            One = 1,

            [Display(Name = "Custom Two")]
            Two = 2,
        }

        [Fact]
        public void GetDisplayName_GivenTestEnumWithCustomDisplayName_ShouldReturnCustomDisplayName()
        {
            string expected = "Custom One";
            TestEnumWithCustomDisplayName testEnum = TestEnumWithCustomDisplayName.One;

            string enumName = testEnum.GetDisplayName();

            Assert.Equal(expected, enumName);
        }

        private enum TestEnumWithDuplicateDisplayNames
        {
            [Display(Name = "Duplicate")]
            One = 1,

            [Display(Name = "Duplicate")]
            Two = 2,
        }

        [Fact]
        public void GetDisplayName_GivenTestEnumWithDuplicateDisplayName_ShouldReturnEnumDisplayNameString()
        {
            string expected = "One";
            TestEnumWithDuplicateDisplayNames testEnum = TestEnumWithDuplicateDisplayNames.One;

            string enumDisplayName = testEnum.GetDisplayName();

            Assert.Equal(expected, enumDisplayName);
        }

    }
}
