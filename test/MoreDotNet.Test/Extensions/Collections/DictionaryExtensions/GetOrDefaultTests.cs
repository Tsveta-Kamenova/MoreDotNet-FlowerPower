namespace MoreDotNet.Test.Extensions.Collections.DictionaryExtensions
{
    using System;
    using System.Collections.Generic;

    using MoreDotNet.Extensions.Collections;

    using Xunit;

    public class GetOrDefaultTests
    {
        private readonly IDictionary<string, int?> testDictionary;

        public GetOrDefaultTests()
        {
            this.testDictionary = new Dictionary<string, int?>();
        }

        [Fact]
        public void GetOrDefault_ExistingKeyGiven_ShouldReturnValue()
        {
            const string TestKeyName = "testKey";

            this.testDictionary.Add(TestKeyName, 99);
            var expected = 99;
            var actual = this.testDictionary.GetOrDefault(TestKeyName);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetOrDefault_NonExistingKeyGiven_ShouldReturnDefaultValueIfNothingElseIsSpecified()
        {
            var expected = default(int?);
            var actual = this.testDictionary.GetOrDefault("FakeKey");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetOrDefault_NonExistingKeyGiven_ShouldReturnSpecifiedValue()
        {
            var expected = 66;
            var actual = this.testDictionary.GetOrDefault("FakeKey", 66);

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void GetOrDefault_NullDictionaryGiven_ShouldThrowArgumentNullException()
        {
            IDictionary<string, int> nullDictionary = null;
            Assert.Throws<ArgumentNullException>(() => nullDictionary.GetOrDefault("Key"));
        }

        [Fact]
        public void GetOrDefault_KeyWithNullValue_ShouldReturnNull()
        {
            this.testDictionary.Add("NullKey", null);
            Assert.Null(this.testDictionary.GetOrDefault("NullKey"));
        }

    }
}
