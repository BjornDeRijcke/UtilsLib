using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

        public static string MultipleReplace(this string text, Dictionary<string, string> replacements)
        {
            return Regex.Replace(
                text,
                "(" + String.Join("|", replacements.Keys.ToArray()) + ")",
                delegate (Match m)
                {
                    // replacement 'key' is simple string, so value is equal
                    // e.g. key="Smith", m.Value="Smith"
                    if (replacements.ContainsKey(m.Value))
                        return replacements[m.Value];

                    // replacement 'key' is a regex pattern. Match value is a different string then the
                    // key, so we must perform an additional match to find out which key resulted in a match
                    // for the given value.
                    // e.g. key="http[s]?[^\s]+" value="http://azerty.be"
                    foreach (var k in replacements.Keys)
                    {
                        if (Regex.IsMatch(m.Value, k))
                            return replacements[k];
                    }
                    throw new Exception("Was match but didn't know which pattern");
                });
        }
    }
}
