using UtilsLib.Extensions;
using Xunit;

namespace UtilsTests.Extensions
{
    public class CharExtensionsTests
    {
        [Theory]
        [InlineData('\u00AD', true, "SOFT HYPHEN")]
        [InlineData('\u0600', true, "ARABIC NUMBER SIGN")]
        [InlineData('\u0601', true, "ARABIC SIGN SANAH")]
        [InlineData('\u0602', true, "ARABIC FOOTNOTE MARKER")]
        [InlineData('\u0603', true, "ARABIC SIGN SAFHA")]
        [InlineData('\u0604', true, "ARABIC SIGN SAMVAT")]
        [InlineData('\u0605', true, "ARABIC NUMBER MARK ABOVE")]
        [InlineData('\u061C', true, "ARABIC LETTER MARK")]
        [InlineData('\u06DD', true, "ARABIC END OF AYAH")]
        [InlineData('\u070F', true, "SYRIAC ABBREVIATION MARK")]
        [InlineData('\u08E2', true, "ARABIC DISPUTED END OF AYAH")]
        [InlineData('\u180E', true, "MONGOLIAN VOWEL SEPARATOR")]
        [InlineData('\u200B', true, "ZERO WIDTH SPACE")]
        [InlineData('\u200C', true, "ZERO WIDTH NON-JOINER")]
        [InlineData('\u200D', true, "ZERO WIDTH")]
        [InlineData('\u200E', true, "LEFT-TO-RIGHT MARK")]
        [InlineData('\u200F', true, "RIGHT-TO-LEFT MARK")]
        [InlineData('\u202A', true, "LEFT-TO-RIGHT EMBEDDING")]
        [InlineData('\u202B', true, "RIGHT-TO-LEFT EMBEDDING")]
        [InlineData('\u202C', true, "POP DIRECTIONAL FORMATTING")]
        [InlineData('\u202D', true, "LEFT-TO-RIGHT OVERRIDE")]
        [InlineData('\u202E', true, "RIGHT-TO-LEFT OVERRIDE")]
        [InlineData('\u2060', true, "WORD JOINER")]
        [InlineData('\u2061', true, "FUNCTION APPLICATION")]
        [InlineData('\u2062', true, "INVISIBLE TIMES")]
        [InlineData('\u2063', true, "INVISIBLE SEPARATOR")]
        [InlineData('\u2064', true, "INVISIBLE PLUS")]
        [InlineData('\u2066', true, "LEFT-TO-RIGHT ISOLATE")]
        [InlineData('\u2067', true, "RIGHT-TO-LEFT ISOLATE")]
        [InlineData('\u2068', true, "FIRST STRONG ISOLATE")]
        [InlineData('\u2069', true, "POP DIRECTIONAL ISOLATE")]
        [InlineData('\u206A', true, "INHIBIT SYMMETRIC SWAPPING")]
        [InlineData('\u206B', true, "ACTIVATE SYMMETRIC SWAPPING")]
        [InlineData('\u206C', true, "INHIBIT ARABIC FORM SHAPING")]
        [InlineData('\u206D', true, "ACTIVATE ARABIC FORM SHAPING")]
        [InlineData('\u206E', true, "NATIONAL DIGIT SHAPES")]
        [InlineData('\u206F', true, "NOMINAL DIGIT SHAPES")]
        [InlineData('\uFEFF', true, "ZERO WIDTH NO-BREAK SPACE")]
        [InlineData('\uFFF9', true, "INTERLINEAR ANNOTATION ANCHOR")]
        [InlineData('\uFFFA', true, "INTERLINEAR ANNOTATION SEPARATOR")]
        [InlineData('\uFFFB', true, "INTERLINEAR ANNOTATION TERMINATOR")]
        public void IsUnicodeFormatChar(char c, bool shouldMatch, string charName)
        {
            Assert.Equal(shouldMatch, c.IsUnicodeFormatChar());
        }
    }
}
