using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Sdk
{
    public class BulkOperationException
    {
        public int? id { get; set; }

        public string uploadFileId { get; set; }

        public string type { get; set; }

        public string element { get; set; }

        public string message { get; set; }
    }
}

