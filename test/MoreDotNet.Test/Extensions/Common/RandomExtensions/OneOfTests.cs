﻿namespace MoreDotNet.Test.Extensions.Common.RandomExtensions
{
    using System;
    using System.Linq;

    using MoreDotNet.Extensions.Common;

    using Xunit;

    public class OneOfTests
    {
        private readonly int[] numbersArray = { 1, 2, 3, 4, 5, 6 };

        [Fact]
        public void OneOf_RandomNull_ShouldHThrow_ArgumentNullException()
        {
            Random random = null;

            Assert.Throws<ArgumentNullException>(() => random.OneOf<int>(this.numbersArray));
        }

        [Fact]
        public void OneOf_NullCollection_ShouldHThrow_ArgumentNullException()
        {
            Random random = new Random();

            Assert.Throws<ArgumentNullException>(() => random.OneOf<int>(null));
        }

        [Fact]
        public void OneOf_ShouldReturn_OneOfIntArray()
        {
            var random = new Random();
            var number = random.OneOf<int>(this.numbersArray);

            Assert.Contains(number, this.numbersArray);
        }
    }
}
