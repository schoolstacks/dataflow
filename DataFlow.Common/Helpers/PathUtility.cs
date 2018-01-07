using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFlow.Common.Helpers
{
    public class PathUtility
    {
        public static string EnsureTrailingSlash(string path)
        {
            if (!path.EndsWith("\\"))
                path += "\\";

            return path;
        }
    }
}
