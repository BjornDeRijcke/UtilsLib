using System;
using System.Globalization;

namespace UtilsLib.Extensions
{
    public static class CharExtensions
    {
        public static bool IsUnicodeFormatChar(this char c)
        {
            // Cases not covered in .net framework
            if (c == '\u00AD'
                || c == '\u08E2')
                return true;

            return Char.GetUnicodeCategory(c) == UnicodeCategory.Format;
        }
    }
}
