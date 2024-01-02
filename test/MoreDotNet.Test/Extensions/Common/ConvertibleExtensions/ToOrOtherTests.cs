namespace MoreDotNet.Test.Extensions.Common.ConvertibleExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class ToOrOtherTests
    {
        private const string Other = "other";

        [Fact]
        public void ToOrOther_ConversionSucceeded_ShouldChangeTheObjectType()
        {
            var value = 10;
            var result = value.ToOrOther(Other);

            Assert.IsType<string>(result);
            Assert.Equal("10", result);
        }

        [Fact]
        public void ToOrOther_ConversionFails_ShouldReturnOtherValue()
        {
            var value = 10;
            var testValue = new DateTime(2000, 2, 2);
            var result = value.ToOrOther(testValue);

            Assert.IsType<DateTime>(result);
            Assert.Equal(testValue, result);
        }

        [Fact]
        public void ToOrOther_WithOutParam_ConversionSucceeded_ShouldChangeTheObjectType()
        {
            var value = 10;
            string newValue;
            var result = value.ToOrOther(out newValue, Other);

            Assert.True(result);
            Assert.IsType<string>(newValue);
            Assert.Equal("10", newValue);
        }

        [Fact]
        public void ToOrOther_WithOutParam_ConversionFails_ShouldReturnDefaultOfT()
        {
            var value = 10;
            var testValue = new DateTime(2000, 2, 2);
            var result = value.ToOrOther(out DateTime output, testValue);

            Assert.False(result);
            Assert.IsType<DateTime>(output);
            Assert.Equal(testValue, output);
        }
    }
}
