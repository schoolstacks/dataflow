using System;
using System.Collections.Generic;
using System.ComponentModel;
using DataFlow.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataFlow.Web.Models
{
    [JsonConverter(typeof(DataMapperJsonSerializer))]
    public class DataMapper
    {
        public DataMapper()
        {
            SubDataMappers = new List<DataMapper>();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DataMapperProperty DataMapperProperty { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<DataMapper> SubDataMappers { get; set; }
    }

    public class DataMapperProperty
    {
        [JsonProperty(PropertyName = "data-type", NullValueHandling = NullValueHandling.Ignore)]
        public string DataType { get; set; }

        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "source-column", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceColumn { get; set; }

        [JsonProperty(PropertyName = "source-table", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceTable { get; set; }

        [JsonProperty(PropertyName = "default", NullValueHandling = NullValueHandling.Ignore)]
        public string Default { get; set; }

        [JsonProperty(PropertyName = "value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonIgnore]
        public string ChildType { get; set; }

        [JsonIgnore]
        public string ParentType { get; set; }

        public static explicit operator DataMapperProperty(JToken v)
        {
            return new DataMapperProperty()
            {
                DataType = v.Value<string>("data-type"),
                Source = v.Value<string>("source"),
                SourceColumn = v.Value<string>("source-column"),
                SourceTable = v.Value<string>("source-table"),
                Default = v.Value<string>("default"),
                Value = v.Value<string>("value")
            };
        }
    }

    public class DataMapperEnums
    {
        public enum Sources
        {
            [Description("column")]
            Column,
            [Description("lookup_table")]
            LookupTable,
            [Description("static")]
            Static
        }

        public enum DataTypes
        {
            [Description("boolean")]
            Boolean,
            [Description("date")]
            Date,
            [Description("date-time")]
            DateTime,
            [Description("integer")]
            Integer,
            [Description("string")]
            String
        }
    }
}