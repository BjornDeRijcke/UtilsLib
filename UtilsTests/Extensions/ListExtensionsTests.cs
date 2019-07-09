using System.Collections.Generic;
using UtilsLib.Extensions;
using Xunit;

namespace UtilsTests.Extensions
{
    public class ListExtensionsTests
    {
        [Fact]
        public void Shuffle_WhenShuffling_OrderHasChanged()
        {
            var lst = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var exp = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            lst.Shuffle();

            Assert.NotEqual(exp, lst);
        }

        [Fact]
        public void Split_WhenSplittingWithExactDividableCountAndSize_GeneratesSequencesOfExactlyRequestedSize()
        {
            var lst = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var size = 2;

            foreach (var section in lst.Split(size))
                Assert.Equal(size, section.Count);
        }

        [Fact]
        public void Split_WhenSplittingWithNonExactDividableCountAndSize_LastGeneratedSequenceIsSmallerThenSize()
        {
            var lst = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            var size = 6;

            var splitLists = new List<List<int>>(lst.Split(size));

            Assert.Equal(2, splitLists.Count);
            Assert.Equal(size, splitLists[0].Count);
            Assert.Equal(3, splitLists[1].Count);
        }

        [Fact]
        public void ExtractFirst_WhenExtracting_ElementHasReallyBeenRemoved()
        {
            var lst = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

            lst.ExtractFirst(out int extractedItem);

            Assert.Equal(0, extractedItem);
            Assert.DoesNotContain(extractedItem, lst);
        }
    }
}
