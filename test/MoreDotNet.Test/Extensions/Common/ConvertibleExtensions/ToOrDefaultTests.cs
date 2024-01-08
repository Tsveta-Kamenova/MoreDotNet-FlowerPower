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

        // New tests

        [Fact]
        public void ToOrDefault_StringToDateTime_ShouldReturnDefaultDateTime()
        {
            var stringValue = "InvalidDateTime";
            var result = stringValue.ToOrDefault<DateTime>();

            Assert.IsType<DateTime>(result);
            Assert.Equal(default(DateTime), result);
        }

        [Fact]
        public void ToOrDefault_NullableIntToNullString_ShouldReturnNullString()
        {
            int? nullableIntValue = null;
            var result = nullableIntValue.ToOrDefault<string>();

            Assert.Null(result);
        }

        [Fact]
        public void ToOrDefault_NullableIntToNonNullString_ShouldReturnNonNullString()
        {
            int? nullableIntValue = 42;
            var result = nullableIntValue.ToOrDefault<string>();

            Assert.NotNull(result);
            Assert.Equal("42", result);
        }

        [Fact]
        public void ToOrDefault_NullableIntWithOutParamToNonNullString_ShouldReturnNonNullString()
        {
            int? nullableIntValue = 42;
            string result;
            var conversionResult = nullableIntValue.ToOrDefault(out result);

            Assert.True(conversionResult);
            Assert.NotNull(result);
            Assert.Equal("42", result);
        }

        [Fact]
        public void ToOrDefault_NullableIntWithOutParamToNullString_ShouldReturnNullString()
        {
            int? nullableIntValue = null;
            string result;
            var conversionResult = nullableIntValue.ToOrDefault(out result);

            Assert.True(conversionResult);
            Assert.Null(result);
        }
    }
}
