using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFlow.Web.Helpers
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Splits the string by a char delimiter and then returns the string element at an index.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="splitCharacter"></param>
        /// <param name="elementAt"></param>
        /// <param name="returnNullIfEmtpty"></param>
        /// <returns></returns>
        public static string SplitGetElementAt(this string value, char splitCharacter, int elementAt, bool returnNullIfEmtpty = true)
        {
            if (string.IsNullOrWhiteSpace(value))
                return returnNullIfEmtpty ? null : value;

            var returnValue = value.Split(splitCharacter).ElementAtOrDefault(elementAt);

            if (string.IsNullOrWhiteSpace(returnValue))
                return returnNullIfEmtpty ? null : returnValue;

            return returnValue;
        }

        /// <summary>
        /// Extremely quick way to determine if a string ends with jpg, gif, or png.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool HasImageExtension(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return value.EndsWith("jpg") || value.EndsWith("gif") || value.EndsWith("png") || value.EndsWith("svg");
        }
    }
}