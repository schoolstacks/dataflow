using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataFlow.Models;
using DataFlow.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataFlow.Web.Helpers
{
    public class DataMapperJsonSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            try
            {
                if (value is DataMapper dataMapper)
                {
                    if (dataMapper.SubDataMappers.Any())
                    {
                        writer.WriteStartObject();
                        writer.WritePropertyName(dataMapper.Name);
                        writer.WriteStartArray();
                        dataMapper.SubDataMappers.ForEach(sub =>
                        {
                            writer.WriteStartObject();
                            writer.WritePropertyName(sub.Name);
                            if (sub.SubDataMappers.Any())
                            {
                                writer.WriteStartObject();
                                for (var i = 0; i < sub.SubDataMappers.Count; i++)
                                {
                                    var subObj = sub.SubDataMappers.ElementAt(i);
                                    writer.WritePropertyName(subObj.Name);
                                    serializer.Serialize(writer, subObj.DataMapperProperty);
                                }
                                writer.WriteEndObject();
                            }
                            writer.WriteEndObject();
                        });
                        writer.WriteEndArray();
                        writer.WriteEndObject();
                    }
                    else
                    {
                        writer.WriteStartObject();
                        writer.WritePropertyName(dataMapper.Name);
                        serializer.Serialize(writer, dataMapper.DataMapperProperty);
                        writer.WriteEndObject();
                    }
                }
            }
            catch (Exception e)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("Error");
                serializer.Serialize(writer, e);
                writer.WriteEndObject();
            }

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            var properties = jsonObject.Properties().ToList();
            return new DataMapper()
            {
                Name = properties[0].Name,
                DataMapperProperty = (DataMapperProperty)properties[0].Value
            };
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(DataMapper).IsAssignableFrom(objectType);
        }
    }
}