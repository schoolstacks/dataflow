using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFlow.Common.Enums
{
    public static class AgentTypeCodeEnum
    {
        public const string SFTP = "SFTP";
        public const string FTPS = "FTPS";
        public const string Chrome = "Chrome";
        public const string Manual = "Manual";

        public static List<string> ToList() => new List<string>() { Chrome, Manual, SFTP, FTPS };
    }
}