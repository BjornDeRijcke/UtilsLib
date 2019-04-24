using UtilsLib.Math;
using Xunit;

namespace UtilsTests.Math
{
	public class MathLibTests
	{
		[Theory]
		[InlineData(1, 2, 1)]
		[InlineData(1, 1, 0)]
		[InlineData(0, 1, 0)]
		[InlineData(2, 10, 2)]
		[InlineData(12, 10, 2)]
		[InlineData(22, 10, 2)]
		[InlineData(-2, 10, 8)]
		[InlineData(-12, 10, 8)]
		[InlineData(-22, 10, 8)]
		[InlineData(-8, 12, 4)]
		[InlineData(8, 12, 8)]
		[InlineData(37, 12, 1)]
		public void Mod(int input, int m, int expected)
		{
			var result = MathLib.Mod(input, m);
			Assert.Equal(expected, result);
		}
	}
}
