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
        public const string TRANSFORMED = "TRANSFORMED";
        public const string LOADED = "LOADED";
        public const string ERROR_UPLOAD = "ERROR_UPLOAD";
        public const string ERROR_LOAD = "ERROR_LOAD";
        public const string ERROR_TRANSFORM = "ERROR_TRANSFORM";
    }

}
