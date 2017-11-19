namespace DataFlow.Models
{
    public partial class EdfiDictionary
    {
        public int Id { get; set; }
        public string GroupSet { get; set; }
        public string OriginalValue { get; set; }
        public string DisplayValue { get; set; }
        public int? DisplayOrder { get; set; }
    }
}
