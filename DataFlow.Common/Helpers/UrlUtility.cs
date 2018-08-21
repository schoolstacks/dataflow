using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFlow.Common.Helpers
{
    public class UrlUtility
    {
        public static string GetUntilOrEmpty(string text, string stopAt)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.LastIndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                    return text.Substring(0, charLocation);
            }

            return string.Empty;
        }

        public static string ConvertLocalPathToUri(string localPath)
        {
            return new System.Uri(localPath).AbsoluteUri;
        }
    }
}
