using UtilsLib.Extensions;
using Xunit;

namespace UtilsTests.Extensions
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("ᠣᠩᠭᠣᠯ \a ᠢᠴᠢᠭ", "ᠣᠩᠭᠣᠯ  ᠢᠴᠢᠭ")]
        public void RemoveControlChars(string input, string expected)
        {
            var res = input.RemoveControlChars();
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("ᠣᠩᠭᠣᠯ \u180E ᠢᠴᠢᠭ", "ᠣᠩᠭᠣᠯ  ᠢᠴᠢᠭ")]
        public void RemoveFormatChars(string input, string expected)
        {
            var res = input.RemoveFormatChars();
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("ᠣᠩᠭᠣᠯ \a ᠢᠴᠢᠭ\u180E", "ᠣᠩᠭᠣᠯ  ᠢᠴᠢᠭ")]
        public void RemoveControlAndFormatChars(string input, string expected)
        {
            var res = input.RemoveControlAndFormatChars();
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("1lem", "1lem")]
        [InlineData("Alem", "Alem")]
        [InlineData("_LK", "_lk")]
        [InlineData("a first song", "A first song")]
        [InlineData("\t", "\t")]
        [InlineData("DeKeNEnalMAls", "Dekenenalmals")]
        [InlineData("deKeNEnalMAls", "Dekenenalmals")]
        public void FirstCharacterToUpperCase(string input, string expected)
        {
            var res = input.FirstCharacterToUpperCase();
            Assert.Equal(expected, res);
        }
    }
}
