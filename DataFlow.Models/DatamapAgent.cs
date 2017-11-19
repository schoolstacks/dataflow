namespace DataFlow.Models
{
    public partial class DataMapAgent
    {
        public int Id { get; set; }
        public int DataMapId { get; set; }
        public int AgentId { get; set; }
        public int ProcessingOrder { get; set; }

        public Agent Agent { get; set; }
        public DataMap DataMap { get; set; }
    }
}
