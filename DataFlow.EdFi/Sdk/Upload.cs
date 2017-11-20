namespace DataFlow.EdFi.Sdk
{
    public class Upload
    {
        public string id { get; set; }
        public int offset { get; set; }
        public int size{ get; set; }
        public byte[] fileBytes { get; set; }
    }
}

