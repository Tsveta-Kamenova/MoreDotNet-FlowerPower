namespace MoreDotNet.Test.Extensions.Collections.CollectionExtensions
{
    using System;
    using System.Collections.Generic;

    using MoreDotNet.Extensions.Collections;

    using Xunit;

    public class AddRangeTests
    {
        [Fact]
        public void AddRange_ItemsAsParams_ShouldBeAddedToCollection()
        {
            ICollection<int> expected = new HashSet<int> { 1, 2, 3, 4, 5 };
            ICollection<int> input = new HashSet<int> { 1 };
            input.AddRange(2, 3, 4, 5);
            Assert.Equal(expected, input);
        }

        [Fact]
        public void AddRange_ItemsAsIEnumerable_ShouldBeAddedToCollection()
        {
            ICollection<int> expected = new HashSet<int> { 1, 2, 3, 4, 5 };
            ICollection<int> input = new HashSet<int> { 1 };
            IEnumerable<int> itemsToAdd = new HashSet<int> { 2, 3, 4, 5 };
            input.AddRange(itemsToAdd);
            Assert.Equal(expected, input);
        }

        [Fact]
        public void AddRange_NullItemsGiven_ShouldThrowException()
        {
            ICollection<int> input = new HashSet<int> { 1, 2, 3, 4, 5 };
            Assert.Throws<ArgumentNullException>(() => input.AddRange(null));
        }

        [Fact]
        public void AddRange_AddToEmptyCollection_ShouldResultInSameItems()
        {
            ICollection<int> expected = new HashSet<int> { 1, 2, 3, 4, 5 };
            ICollection<int> input = new HashSet<int>();
            input.AddRange(1, 2, 3, 4, 5);
            Assert.Equal(expected, input);
        }

        [Fact]
        public void AddRange_AddMultipleTimes_ShouldNotDuplicateItems()
        {
            ICollection<int> expected = new HashSet<int> { 1, 2, 3, 4, 5 };
            ICollection<int> input = new HashSet<int> { 1 };
            input.AddRange(2, 3);
            input.AddRange(4, 5);
            Assert.Equal(expected, input);
        }

        [Fact]
        public void AddRange_AddToNonEmptyCollection_ShouldAppendItems()
        {
            ICollection<int> expected = new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ICollection<int> input = new HashSet<int> { 1, 2, 3, 4, 5 };
            input.AddRange(6, 7, 8, 9);
            Assert.Equal(expected, input);
        }

        [Fact]
        public void AddRange_AddMultipleTypes_ShouldHandleCorrectly()
        {
            ICollection<object> expected = new HashSet<object> { 1, "two", 3.0, '4' };
            ICollection<object> input = new HashSet<object> { 1 };
            IEnumerable<object> itemsToAdd = new List<object> { "two", 3.0, '4' };
            input.AddRange(itemsToAdd);
            Assert.Equal(expected, input);
        }
    }
}
