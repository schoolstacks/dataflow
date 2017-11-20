using System.Collections.Generic;

namespace DataFlow.EdFi.Sdk
{
    public class BulkOperation
    {
        public string id { get; set; }
        public List<UploadFile> uploadFiles { get; set; }
        public string status { get; set; }
    }
}

