using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFlow.Web.Helpers
{
    public static class ExtensionMethods
    {
        public static string SplitGetElementAt(this string text, char splitCharacter, int elementAt, bool returnNullIfEmtpty = true)
        {
            if (string.IsNullOrWhiteSpace(text))
                return returnNullIfEmtpty ? null : text;

            var returnValue = text.Split(splitCharacter).ElementAtOrDefault(elementAt);

            if (string.IsNullOrWhiteSpace(returnValue))
                return returnNullIfEmtpty ? null : returnValue;

            return returnValue;
        }
    }
}