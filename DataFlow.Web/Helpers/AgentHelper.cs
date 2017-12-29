using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFlow.Web.Helpers
{
    public class AgentHelper
    {
        public class Types
        {
            public const string Chrome = "Chrome";
            public const string Manual = "Manual";
            public const string SFTP = "SFTP";
            public const string FTPS = "FTPS";

            public static List<string> ToList() => new List<string>() {Chrome, Manual, SFTP, FTPS};
        }
    }
}