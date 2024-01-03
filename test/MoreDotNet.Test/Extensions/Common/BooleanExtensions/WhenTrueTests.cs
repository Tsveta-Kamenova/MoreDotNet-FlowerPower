namespace MoreDotNet.Test.Extensions.Common.BooleanExtensions
{
    using MoreDotNet.Extensions.Common;
    using System;
    using Xunit;

    public class WhenTrueTests
    {
        [Fact]
        public void WhenTrue_ParseTrueValue_ShouldReturnContent()
        {
            var input = true;
            var expected = "Hello Worlds!";
            var actual = input.WhenTrue(expected);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenTrue_ParseFalseValue_ShouldReturnDefaultValueOfContent()
        {
            var input = true;
            var expected = default(string);
            var actual = input.WhenTrue(expected);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenTrue_ParseTrueValue_ShouldExecuteAction()
        {
            var input = true;
            var expected = "Hello Worlds!";
            var actual = input.WhenTrue(() => "Hello Worlds!");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenTrue_ParseFalseValue_ShouldNotExecuteAction()
        {
            var input = false;
            var expected = default(string);
            var actual = input.WhenTrue(() => "Hello Worlds!");
            Assert.Equal(expected, actual);
        }

        //NEW TESTS
        [Fact]
        public void WhenTrue_ParseFalseValue_ShouldReturnDefaultOfContentType()
        {
            var input = false;
            var expected = default(string);
            var actual = input.WhenTrue(expected);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenTrue_NullContent_ShouldReturnDefaultOfContentType()
        {
            bool input = true;
            string expected = null;
            var actual = input.WhenTrue(expected);
            Assert.Equal(default(string), actual);
        }

        [Fact]
        public void WhenTrue_NullAction_ShouldThrowArgumentNullException()
        {
            bool input = true;
            Assert.Throws<ArgumentNullException>(() => input.WhenTrue((Func<string>)null));
        }
    }
}
