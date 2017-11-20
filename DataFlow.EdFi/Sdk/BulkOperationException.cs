namespace DataFlow.EdFi.Sdk
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

