namespace DataFlow.Models
{
    public partial class AgentSchedule
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }

        public Agent Agent { get; set; }
    }
}
