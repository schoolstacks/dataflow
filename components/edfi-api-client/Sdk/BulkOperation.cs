using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace EdFi.OdsApi.Sdk
{
    public class BulkOperation
    {
        public string id { get; set; }
        public List<UploadFile> uploadFiles { get; set; }
        public string status { get; set; }
    }
}

