using Newtonsoft.Json;

namespace DataFlow.Web.Models
{
    public class DataMapper
    {
        public string Name { get; set; }

        public DataMapperProperty DataMapperProperty { get; set; }
    }

    public class DataMapperProperty
    {
        [JsonProperty(PropertyName = "data-type")]
        public string DataType { get; set; }

        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "source-column")]
        public string SourceColumn { get; set; }

        [JsonProperty(PropertyName = "source-table", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceTable { get; set; }

        [JsonProperty(PropertyName = "default", NullValueHandling = NullValueHandling.Ignore)]
        public string Default { get; set; }

        [JsonProperty(PropertyName = "value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }
}