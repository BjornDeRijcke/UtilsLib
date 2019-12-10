using System.Collections.Generic;
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
        public void UppercaseFirst(string input, string expected)
        {
            var res = input.UppercaseFirst();
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("1lem", "1lem")]
        [InlineData("Alem", "alem")]
        [InlineData("_LK", "_LK")]
        [InlineData("a firSt song", "a firSt song")]
        [InlineData("\t", "\t")]
        [InlineData("DeKeNEnalMAls", "deKeNEnalMAls")]
        [InlineData("deKeNEnalMAls", "deKeNEnalMAls")]
        public void LowercaseFirst(string input, string expected)
        {
            var res = input.LowercaseFirst();
            Assert.Equal(expected, res);
        }

        [Fact]
        public void MultipleReplace()
        {
            string input = "Jonathan Smith is  a developer";
            string expected = "Smith-Jonathan-is a-goat";

            var replacements = new Dictionary<string, string>
            {
                { "Jonathan", "Smith" },
                { "Smith", "Jonathan" },
                { "developer", "goat" },
                { "goat", "donkey" },
                { @"\s{2,20}", " " }, // multiple spaces
                { " ", "-" }
            };

            string output = input.MultipleReplace(replacements);

            Assert.Equal(expected, output);
        }
    }
}
