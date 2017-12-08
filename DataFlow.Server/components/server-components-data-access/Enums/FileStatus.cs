using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server_components_data_access.Enums
{
    public static class FileStatus
    {
        public const string UPLOADED = "UPLOADED";
        public const string ERROR_UPLOADED = "ERROR_UPLOADED";
        public const string TRANSFORMING = "TRANSFORMING";
        public const string ERROR_TRANSFORM = "ERROR_TRANSFORM";
        public const string LOADING = "LOADING";
        public const string ERROR_LOADING = "ERROR_LOADING";
        public const string LOADED = "LOADED";

    }

}
