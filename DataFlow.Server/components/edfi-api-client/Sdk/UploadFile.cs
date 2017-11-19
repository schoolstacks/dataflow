namespace EdFi.OdsApi.Sdk
{
    public class UploadFile
    {
        public string id { get; set; }
        public string format { get; set; }
        public string interchangeType { get; set; }
        public long size { get; set; }

        // 0 Initialized 
        // 1 Incomplete
        // 2 Ready
        // 3 Started
        // 4 Completed
        // 5 Error
        // 6 Expired after 24 hours
        public string status { get; set; }
    }
}

