using UtilsLib.Extensions;
using Xunit;

namespace UtilsTests.Extensions
{
	public class ArrayExtensionsTests
	{
		[Theory]
		[InlineData(new[] { 1, 2, 5, 6, 9, 10 }, 2, new[] { 9, 10, 1, 2, 5, 6 })]
		[InlineData(new[] { 1, 2, 5, 6, 9, 10 }, 4, new[] { 5, 6, 9, 10, 1, 2 })]
		[InlineData(new[] { 1, 2, 5, 6, 9, 10 }, 10, new[] { 5, 6, 9, 10, 1, 2 })]
		[InlineData(new[] { 1, 2, 5, 6, 9, 10 }, 3, new[] { 6, 9, 10, 1, 2, 5 })]
		[InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 2, new[] { 7, 8, 1, 2, 3, 4, 5, 6 })]
		public void RotateRight(int[] input, int rotateCount, int[] expected)
		{
			input.RotateRight(rotateCount);
			Assert.Equal(expected, input);
		}

		[Theory]
		[InlineData(new[] { 1, 2, 5, 6, 9, 10 }, 2, new[] { 5, 6, 9, 10, 1, 2 })]
		[InlineData(new[] { 1, 2, 5, 6, 9, 10 }, 4, new[] { 9, 10, 1, 2, 5, 6 })]
		[InlineData(new[] { 1, 2, 5, 6, 9, 10 }, 10, new[] { 9, 10, 1, 2, 5, 6 })]
		[InlineData(new[] { 1, 2, 5, 6, 9, 10 }, 3, new[] { 6, 9, 10, 1, 2, 5 })]
		[InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 2, new[] { 3, 4, 5, 6, 7, 8, 1, 2 })]
		public void RotateLeft(int[] input, int rotateCount, int[] expected)
		{
			input.RotateLeft(rotateCount);
			Assert.Equal(expected, input);
		}
	}
}
