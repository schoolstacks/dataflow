using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DataFlow.Web.Helpers;
using Newtonsoft.Json;

namespace DataFlow.Web.Models
{
    public class DataMapper
    {
        public DataMapper()
        {
            SubDataMappers = new List<DataMapper>();
        }

        public DataMapper(string name, DataMapperProperty dataMapperProperty = null)
        {
            Name = name;
            DataMapperProperty = dataMapperProperty;
            SubDataMappers = new List<DataMapper>();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DataMapperProperty DataMapperProperty { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<DataMapper> SubDataMappers { get; set; }

        [JsonIgnore]
        public static JsonSerializerSettings JsonSerializerSettings => new JsonSerializerSettings()
        {
            Converters = new List<JsonConverter> { new DataMapperListConverter() },
            Formatting = Formatting.Indented
        };
    }

    public class DataMapperProperty
    {
        public DataMapperProperty()
        {
        }

        public DataMapperProperty(string dataType, string childType)
        {
            DataType = dataType;
            ChildType = childType;
        }

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

        [JsonIgnore]
        public string UniqueKey { get; set; }
    }

    public class DataMapperBuilder
    {
        public static List<DataMapper> BuildPropertyUniqueKey(List<DataMapper> dataMappers)
        {
            dataMappers.ForEach(dm =>
            {
                dm.DataMapperProperty.UniqueKey = dm.Name;

                if(dm.SubDataMappers.Any())
                {
                    dm.SubDataMappers.ForEach(sub =>
                    {
                        sub.DataMapperProperty.ParentType = dm.Name;
                        sub.DataMapperProperty.UniqueKey = $"{dm.Name}_{sub.Name}";

                        if (sub.SubDataMappers.Any())
                        {
                            sub.SubDataMappers.ForEach(tri =>
                            {
                                tri.DataMapperProperty.ParentType = $"{dm.Name}:{sub.Name}";
                                tri.DataMapperProperty.UniqueKey = $"{dm.Name}_{sub.Name}_{tri.Name}";
                            });
                        }
                    });
                }
            });

            return dataMappers;
        }
    }

    public class DataMapperComparer : IEqualityComparer<DataMapper>
    {
        public bool Equals(DataMapper x, DataMapper y)
        {
            if (x == null || y == null)
                return false;

            if (x.SubDataMappers.Any() == false && y.SubDataMappers.Any() == false)
            {
                return x.DataMapperProperty.UniqueKey == y.DataMapperProperty.UniqueKey;
            }
            else
            {
                return Equals(x.SubDataMappers.Select(s => s.DataMapperProperty.UniqueKey), y.SubDataMappers.Select(s => s.DataMapperProperty.UniqueKey));
            }
            
        }

        public int GetHashCode(DataMapper dm)
        {
            return dm.DataMapperProperty.UniqueKey.GetHashCode();
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