using System;
using System.Text;
using System.Text.RegularExpressions;

namespace DataFlow.Common.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string NullIfWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }

        /// <summary>
        /// Adds a space between uppercased words.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string UnPascalCase(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";
            var newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                var currentUpper = char.IsUpper(text[i]);
                var prevUpper = char.IsUpper(text[i - 1]);
                var nextUpper = (text.Length > i + 1) ? char.IsUpper(text[i + 1]) || char.IsWhiteSpace(text[i + 1]) : prevUpper;
                var spaceExists = char.IsWhiteSpace(text[i - 1]);
                if (currentUpper && !spaceExists && (!nextUpper || !prevUpper))
                    newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }

        /// <summary>
        /// Returns the input string with the first character converted to uppercase, or mutates any nulls passed into string.Empty
        /// </summary>
        public static string UpperCaseFirstLetter(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        /// <summary>
        /// Replace the * with an .* and the ? with a dot. Put ^ at the beginning and a $ at the end
        /// </summary>
        /// <param name="value"></param>
        /// <param name="textWithWildCard"></param>
        /// <returns></returns>
        public static bool IsLike(this string value, string textWithWildCard)
        {
            var pattern = "^" + Regex.Escape(textWithWildCard).Replace(@"\*", ".*").Replace(@"\?", ".") + "$";

            return new Regex(pattern, RegexOptions.IgnoreCase).IsMatch(value);
        }
    }
}
