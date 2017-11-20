using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataFlow.Common.Helpers
{
    public class Helper
    {
        public static string GetRequestBody(HttpRequest r)
        {
            Stream req = r.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            StreamReader s = new StreamReader(req);
            return s.ReadToEnd();
        }
    }
}
