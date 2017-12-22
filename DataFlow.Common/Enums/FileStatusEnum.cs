using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFlow.Common.Enums
{
    public static class FileStatusEnum
    {
        public const string UPLOADED = "UPLOADED";
        public const string ERROR_UPLOADED = "ERROR_UPLOADED";
        public const string TRANSFORMING = "TRANSFORMING";
        public const string ERROR_TRANSFORM = "ERROR_TRANSFORM";
        public const string LOADING = "LOADING";
        public const string ERROR_LOADING = "ERROR_LOADING";
        public const string LOADED = "LOADED";
        public const string RETRY = "RETRY";
    }
}