namespace MoreDotNet.Test.Extensions.Common.ConvertibleExtensions
{
    using System;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class ToOrDefaultTests
    {
        [Fact]
        public void ToOrDefault_ConversionSucceeded_ShouldChangeTheObjectType()
        {
            var value = 10;
            var result = value.ToOrDefault<string>();

            Assert.IsType<string>(result);
            Assert.Equal("10", result);
        }

        [Fact]
        public void ToOrDefault_ConversionFails_ShouldReturnDefaultOfT()
        {
            var value = 10;
            var result = value.ToOrDefault<DateTime>();

            Assert.IsType<DateTime>(result);
            Assert.Equal(default(DateTime), result);
        }

        [Fact]
        public void ToOrDefault_WithOutParam_ConversionSucceeded_ShouldChangeTheObjectType()
        {
            var value = 10;
            string newValue;
            var result = value.ToOrDefault<string>(out newValue);

            Assert.True(result);
            Assert.IsType<string>(newValue);
            Assert.Equal("10", newValue);
        }

        [Fact]
        public void ToOrDefault_WithOutParam_ConversionFails_ShouldReturnDefaultOfT()
        {
            var value = 10;
            DateTime newValue;
            var result = value.ToOrDefault(out newValue);

            Assert.False(result);
            Assert.IsType<DateTime>(newValue);
            Assert.Equal(default(DateTime), newValue);
        }
    }
}
