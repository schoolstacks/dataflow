using System;
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

        /// <summary>
        /// Serializer settings so that the DataMap is generated and read correctly.
        /// </summary>
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

        public DataMapperProperty(string dataType)
        {
            DataType = dataType;
        }

        public DataMapperProperty(string dataType, string childType)
        {
            DataType = dataType;
            ChildType = childType;
        }

        /// <summary>
        /// The data type for this property (auto generated from the EdFi api)
        /// </summary>
        [JsonProperty(PropertyName = "data-type", NullValueHandling = NullValueHandling.Ignore)]
        public string DataType { get; set; }

        /// <summary>
        /// The source of the property: column, lookup-table, or static
        /// </summary>
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        /// <summary>
        /// The column in the CSV that maps to this property
        /// </summary>
        [JsonProperty(PropertyName = "source-column", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceColumn { get; set; }

        /// <summary>
        /// The source table, or lookup table, that should be used to determine the final value
        /// </summary>
        [JsonProperty(PropertyName = "source-table", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceTable { get; set; }

        /// <summary>
        /// The default value
        /// </summary>
        [JsonProperty(PropertyName = "default", NullValueHandling = NullValueHandling.Ignore)]
        public string Default { get; set; }

        /// <summary>
        /// The static value
        /// </summary>
        [JsonProperty(PropertyName = "value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        /// <summary>
        /// Used to determine if fields should be shown for this object
        /// </summary>
        [JsonIgnore]
        public string ChildType { get; set; }

        /// <summary>
        /// The parent object
        /// </summary>
        [JsonIgnore]
        public string ParentType { get; set; }

        /// <summary>
        /// An unique key that is used to determine the field name when generating inputs
        /// </summary>
        [JsonIgnore]
        public string UniqueKey { get; set; }

        /// <summary>
        /// If the source is column or lookup-table
        /// </summary>
        [JsonIgnore]
        public bool ShowSourceColumn => Source != null && (Source == "column" || Source == "lookup-table");

        /// <summary>
        /// If the source is lookup-table
        /// </summary>
        [JsonIgnore]
        public bool ShowSourceTable => Source != null && Source == "lookup-table";

        /// <summary>
        /// If the source is static
        /// </summary>
        [JsonIgnore]
        public bool ShowStaticValue => Source != null && Source == "static";

        /// <summary>
        /// If the source is column or lookup-table
        /// </summary>
        [JsonIgnore]
        public bool ShowDefaultValue => Source != null && (Source == "column" || Source == "lookup-table");
    }


    public class DataMapperBuilder
    {
        /// <summary>
        /// Builds the unique key for an existing map so it can be displayed properly.
        /// </summary>
        /// <param name="dataMappers"></param>
        /// <returns></returns>
        public static List<DataMapper> BuildPropertyUniqueKey(List<DataMapper> dataMappers)
        {
            var toMove = dataMappers.SelectMany(x => x.SubDataMappers.Where(y => y.Name.Contains("_Item"))).ToList();

            var lastEntityName = string.Empty;
            var insertDataMapperAt = 0;

            foreach (var moveMapper in toMove)
            {
                var replace = dataMappers.FirstOrDefault(x => x.Name == DataMapperHelpers.CleanJsonArrayObjectName(moveMapper.Name));
                if (replace != null)
                {
                    var index = dataMappers.IndexOf(replace);
                    
                    if (dataMappers[index].SubDataMappers.Count == 1)
                    {
                        dataMappers[index].SubDataMappers.Clear();
                        dataMappers[index].SubDataMappers.AddRange(moveMapper.SubDataMappers);
                    }
                    else
                    {
                        if (lastEntityName != replace.Name)
                        {
                            lastEntityName = replace.Name;
                            insertDataMapperAt = index;
                            dataMappers.RemoveAt(index);
                        }

                        if (dataMappers.Count <= insertDataMapperAt)
                            dataMappers.InsertRange(insertDataMapperAt, replace.SubDataMappers);
                        else
                        {
                            dataMappers.AddRange(replace.SubDataMappers);
                        }
                    }
                }
            }

            dataMappers.ForEach(dm =>
            {
                dm.Name = DataMapperHelpers.CleanJsonArrayObjectName(dm.Name);

                if (dm.DataMapperProperty == null)
                    dm.DataMapperProperty = new DataMapperProperty(dm.Name);

                dm.DataMapperProperty.UniqueKey = dm.Name;

                if (dm.SubDataMappers.Any())
                {
                    dm.DataMapperProperty.DataType = dm.DataMapperProperty.DataType.EndsWith("Reference")
                                                        ? dm.DataMapperProperty.DataType
                                                        : "array";

                    dm.DataMapperProperty.ChildType = dm.Name;

                    dm.SubDataMappers.ForEach(sub =>
                    {
                        sub.Name = DataMapperHelpers.CleanJsonArrayObjectName(sub.Name);

                        if (sub.DataMapperProperty == null)
                        {
                            sub.DataMapperProperty = new DataMapperProperty(sub.Name);
                        }

                        sub.DataMapperProperty.ParentType = dm.Name;
                        sub.DataMapperProperty.UniqueKey = $"{dm.Name}_{sub.Name}";


                        if (sub.SubDataMappers.Any())
                        {
                            sub.DataMapperProperty.DataType = sub.DataMapperProperty.DataType.EndsWith("Reference")
                                ? sub.DataMapperProperty.DataType
                                : "array";

                            sub.DataMapperProperty.ChildType = sub.Name;

                            sub.SubDataMappers.ForEach(tri =>
                            {
                                tri.Name = DataMapperHelpers.CleanJsonArrayObjectName(tri.Name);

                                if (tri.DataMapperProperty == null)
                                    tri.DataMapperProperty = new DataMapperProperty(tri.Name);

                                //if (dm.Name != sub.Name)
                                //{
                                // this item is third object that differs from the parent
                                tri.DataMapperProperty.ParentType = $"{dm.Name}:{sub.Name}";
                                tri.DataMapperProperty.UniqueKey = $"{dm.Name}_{sub.Name}_{tri.Name}";
                                //}
                                //else
                                //{
                                //    tri.DataMapperProperty.ParentType = dm.Name;
                                //    tri.DataMapperProperty.UniqueKey = $"{dm.Name}_{sub.Name}";
                                //}

                            });
                        }
                    });
                }
            });

            return dataMappers;
        }
    }

    public class DataMapperHelpers
    {
        public static string CleanJsonArrayObjectName(string objectName)
        {
            return objectName.LastIndexOf('_') > 0 ? objectName.Remove(objectName.LastIndexOf('_')) : objectName;
        }
    }

    public class DataMapperEnums
    {
        public enum Sources
        {
            [Description("column")]
            Column,
            [Description("lookup-table")]
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