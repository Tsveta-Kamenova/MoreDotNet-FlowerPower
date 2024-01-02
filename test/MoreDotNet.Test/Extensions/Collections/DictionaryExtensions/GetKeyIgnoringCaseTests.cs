namespace MoreDotNet.Test.Extensions.Collections.DictionaryExtensions
{
    using System;
    using System.Collections.Generic;

    using MoreDotNet.Extensions.Collections;

    using Xunit;

    public class GetKeyIgnoringCaseTests
    {
        private readonly IDictionary<string, int> testDictionary;

        public GetKeyIgnoringCaseTests()
        {
            this.testDictionary = new Dictionary<string, int>();
        }

        [Theory]
        [InlineData("")]
        [InlineData("             ")]
        [InlineData(null)]
        public void GetKeyIgnoringCase_InvalidKeyGiven_ShouldReturnEmptyString(string key)
        {
            Assert.Equal(string.Empty, this.testDictionary.GetKeyIgnoringCase(key));
        }

        [Fact]
        public void GetKeyIgnoringCase_ValidKeyGiven_ShouldReturnFirstKey()
        {
            this.testDictionary.Add("TestKey", 12);
            this.testDictionary.Add("testKey", 13);

            var expected = "TestKey";
            var actual = this.testDictionary.GetKeyIgnoringCase("testkey");

            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetKeyIgnoringCase_NonExistingKeyGiven_ShouldReturnEmptyString()
        {
            var expected = string.Empty;
            var actual = this.testDictionary.GetKeyIgnoringCase("testkey");

            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("TestKey", "testkey")]
        [InlineData("anotherKey", "ANOTHERKEY")]
        [InlineData("mIXeDcAseKey", "MiXeDcAsEkEy")]
        public void GetKeyIgnoringCase_ExistingKeyGiven_ShouldReturnMatchingKey(string originalKey, string caseInsensitiveKey)
        {
            this.testDictionary.Add(originalKey, 42);

            string actual = this.testDictionary.GetKeyIgnoringCase(caseInsensitiveKey);

            Assert.Equal(originalKey, actual);
        }

        [Fact]
        public void GetKeyIgnoringCase_MultipleKeysWithSameIgnoreCaseGiven_ShouldReturnFirstMatchingKey()
        {
            this.testDictionary.Add("TestKey", 1);
            this.testDictionary.Add("testkey", 2);

            string actual = this.testDictionary.GetKeyIgnoringCase("testkey");

            Assert.Equal("TestKey", actual);
        }

        [Fact]
        public void GetKeyIgnoringCase_NullDictionaryGiven_ShouldThrowArgumentNullException()
        {
            IDictionary<string, int> nullDictionary = null;

            Assert.Throws<ArgumentNullException>(() => nullDictionary.GetKeyIgnoringCase("someKey"));
        }

        [Fact]
        public void GetKeyIgnoringCase_NullCaseInsensitiveKeyGiven_ShouldReturnEmptyString()
        {
            Assert.Equal(string.Empty, this.testDictionary.GetKeyIgnoringCase(null));
        }

        [Fact]
        public void GetKeyIgnoringCase_EmptyCaseInsensitiveKeyGiven_ShouldReturnEmptyString()
        {
            Assert.Equal(string.Empty, this.testDictionary.GetKeyIgnoringCase(""));
        }
    }
}
