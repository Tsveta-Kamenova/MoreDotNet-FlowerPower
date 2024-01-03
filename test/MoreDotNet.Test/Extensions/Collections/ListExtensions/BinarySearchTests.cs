namespace MoreDotNet.Test.Extensions.Collections.ListExtensions
{
    using System;
    using System.Collections.Generic;

    using MoreDotNet.Extensions.Collections;

    using Xunit;

    public class BinarySearchTests
    {
        [Fact]
        public void BinarySearch_NullList_ShouldThrowArgumentNullException()
        {
            IList<string> testList = null;
            Assert.Throws<ArgumentNullException>(
                () => testList.BinarySearch(x => x, null));
        }

        [Fact]
        public void BinarySearch_NullKeySelectorShould_ThrowArgumentNullException()
        {
            IList<string> testList = new List<string>();
            Assert.Throws<ArgumentNullException>(
                () => testList.BinarySearch(null, string.Empty));
        }

        [Fact]
        public void BinarySearch_EmptyList_ShouldThrowArgumentOutOfRangeException()
        {
            IList<string> testList = new List<string>();
            Assert.Throws<ArgumentOutOfRangeException>(
                () => testList.BinarySearch(x => x, string.Empty));
        }

        [Fact]
        public void BinarySearch_ListItemNotFound_ShouldThrowArgumentOutOfRangeException()
        {
            IList<string> testList = new List<string> { "TestItem" };
            Assert.Throws<InvalidOperationException>(
                () => testList.BinarySearch(x => x, "doesNotExist"));
        }

        [Fact]
        public void BinarySearch_OneItemListSearchForItem_ShouldReturnItem()
        {
            IList<string> testList = new List<string> { "TestItem" };
            var item = testList.BinarySearch(x => x, "TestItem");

            Assert.Equal("TestItem", item);
        }

        [Fact]
        public void BinarySearch_ItemFirstInEvenNumberListSearchForItem_ShouldReturnItem()
        {
            IList<string> testList = new List<string> { "Item", "OtherItem" };
            var item = testList.BinarySearch(x => x, "Item");

            Assert.Equal("Item", item);
        }

        [Fact]
        public void BinarySearch_ItemLastInEvenNumberListSearchForItem_ShouldReturnItem()
        {
            IList<string> testList = new List<string> { "Item", "OtherItem" };
            var item = testList.BinarySearch(x => x, "OtherItem");

            Assert.Equal("OtherItem", item);
        }

        [Fact]
        public void BinarySearch_ItemFirstInOddNumberListSearchForItem_ShouldReturnItem()
        {
            IList<string> testList = new List<string> { "Item", "OtherItem", "ZItem" };
            var item = testList.BinarySearch(x => x, "Item");

            Assert.Equal("Item", item);
        }

        [Fact]
        public void BinarySearch_ItemMiddleInOddNumberListSearchForItem_ShouldReturnItem()
        {
            IList<string> testList = new List<string> { "Item", "OtherItem", "ZItem" };
            var item = testList.BinarySearch(x => x, "OtherItem");

            Assert.Equal("OtherItem", item);
        }

        [Fact]
        public void BinarySearch_ItemLastInOddNumberListSearchForItem_ShouldReturnItem()
        {
            IList<string> testList = new List<string> { "Item", "OtherItem", "ZItem" };
            var item = testList.BinarySearch(x => x, "ZItem");

            Assert.Equal("ZItem", item);
        }

        [Fact]
        public void InsertionSort_NullList_ShouldThrowArgumentNullException()
        {
            List<int> testList = null;
            Assert.Throws<ArgumentNullException>(() => testList.InsertionSort((x, y) => x.CompareTo(y)));
        }

        [Fact]
        public void InsertionSort_NullComparison_ShouldThrowArgumentNullException()
        {
            List<int> testList = new List<int> { 3, 2, 1 };
            Assert.Throws<ArgumentNullException>(() => testList.InsertionSort(null));
        }

        [Fact]
        public void InsertionSort_SortedList_ShouldNotChangeOrder()
        {
            List<int> testList = new List<int> { 1, 2, 3, 4, 5 };
            testList.InsertionSort((x, y) => x.CompareTo(y));
            Assert.Equal(new List<int> { 1, 2, 3, 4, 5 }, testList);
        }

        [Fact]
        public void InsertionSort_ReverseSortedList_ShouldSortInAscendingOrder()
        {
            List<int> testList = new List<int> { 5, 4, 3, 2, 1 };
            testList.InsertionSort((x, y) => x.CompareTo(y));
            Assert.Equal(new List<int> { 1, 2, 3, 4, 5 }, testList);
        }

        [Fact]
        public void InsertionSort_CustomComparison_ShouldSortUsingComparison()
        {
            List<string> testList = new List<string> { "banana", "apple", "cherry" };
            testList.InsertionSort((x, y) => x.Length.CompareTo(y.Length));
            Assert.Equal(new List<string> { "apple", "banana", "cherry" }, testList);
        }

        [Fact]
        public void InsertWhere_NullList_ShouldThrowArgumentNullException()
        {
            List<int> testList = null;
            Assert.Throws<ArgumentNullException>(() => testList.InsertWhere(5, x => x > 0));
        }

        [Fact]
        public void InsertWhere_NullPredicate_ShouldThrowArgumentNullException()
        {
            List<int> testList = new List<int> { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => testList.InsertWhere(5, null));
        }

        [Fact]
        public void InsertWhere_InsertAtBeginning_ShouldInsertItemAtFirstFailure()
        {
            List<int> testList = new List<int> { 2, 4, 6, 8, 10 };
            testList.InsertWhere(5, x => x > 5);
            Assert.Equal(new List<int> { 5, 2, 4, 6, 8, 10 }, testList);
        }

        [Fact]
        public void InsertWhere_InsertAtEnd_ShouldAppendItemIfPredicateNeverFails()
        {
            List<int> testList = new List<int> { 2, 4, 6, 8, 10 };
            testList.InsertWhere(12, x => x > 0);
            Assert.Equal(new List<int> { 2, 4, 6, 8, 10, 12 }, testList);
        }

        [Fact]
        public void RemoveAll_NullList_ShouldThrowArgumentNullException()
        {
            List<int> testList = null;
            Assert.Throws<NullReferenceException>(() => testList.RemoveAll(x => x > 0));
        }

        [Fact]
        public void RemoveAll_NullPredicate_ShouldThrowArgumentNullException()
        {
            List<int> testList = new List<int> { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => testList.RemoveAll(null));
        }

        [Fact]
        public void RemoveAll_RemoveSomeItems_ShouldRemoveMatchingItems()
        {
            List<int> testList = new List<int> { 1, 2, 3, 4, 5 };
            testList.RemoveAll(x => x % 2 == 0);
            Assert.Equal(new List<int> { 1, 3, 5 }, testList);
        }
    }
}
