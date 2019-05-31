using System;
using System.Linq;

namespace UtilsLib.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveControlChars(this string s)
        {
            if (String.IsNullOrWhiteSpace(s))
                return "";

            return new string(s.Where(c => !Char.IsControl(c)).ToArray());
        }

        /// <summary>
        /// Creates a new string where all unicode cateogry 15 'Format' (Cf) characters are removed.
        /// </summary>
        /// <param name="s"></param>
        /// <returns>string withouth format characters</returns>
        public static string RemoveFormatChars(this string s)
        {
            if (String.IsNullOrWhiteSpace(s))
                return "";

            return new string(s.Where(c => !c.IsUnicodeFormatChar()).ToArray());
        }

        public static string RemoveControlAndFormatChars(this string s)
        {
            if (String.IsNullOrWhiteSpace(s))
                return "";

            return new string(s.Where(c => !c.IsUnicodeFormatChar() && !Char.IsControl(c)).ToArray());
        }

        /// <summary>
        /// Returns the input string with the first character converted to uppercase, 
        /// or mutates any nulls passed into string.Empty
        /// </summary>
        public static string FirstCharacterToUpperCase(this string s)
        {
            if (String.IsNullOrEmpty(s))
                return String.Empty;

            char[] a = s.ToLowerInvariant().ToCharArray();
            a[0] = Char.ToUpper(a[0]);
            return new string(a);
        }
    }
}
