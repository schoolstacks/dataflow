using System;
using System.Collections.Generic;
using System.Linq;
using DataFlow.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataFlow.Web.Helpers
{
    public class DataMapperListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<DataMapper>);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var list = (List<DataMapper>)value;
            if (list.Any(dm => dm.DataMapperProperty != null))
            {
                var obj = new JObject(list.Select(dm =>
                {
                    var val = dm.DataMapperProperty != null
                        ? JToken.FromObject(dm.DataMapperProperty, serializer)
                        : JToken.FromObject(dm.SubDataMappers, serializer);
                    return new JProperty(dm.Name, val);
                }));
                obj.WriteTo(writer);
            }
            else
            {
                serializer.Serialize(writer,
                    list.Select(dm => new Dictionary<string, List<DataMapper>>
                    {
                        { dm.Name, dm.SubDataMappers }
                    }));
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            switch (token.Type)
            {
                case JTokenType.Object:
                    return token.Children<JProperty>()
                        .Select(jp =>
                        {
                            var mapper = new DataMapper { Name = jp.Name };
                            var val = jp.Value;
                            if (val["data-type"] != null)
                                mapper.DataMapperProperty = jp.Value.ToObject<DataMapperProperty>(serializer);
                            else
                                mapper.SubDataMappers = jp.Value.ToObject<List<DataMapper>>(serializer);
                            return mapper;
                        })
                        .ToList();
                case JTokenType.Array:
                    return token.Children<JObject>()
                        .SelectMany(jo => jo.Properties())
                        .Select(jp => new DataMapper
                        {
                            Name = jp.Name,
                            SubDataMappers = jp.Value.ToObject<List<DataMapper>>(serializer)
                        })
                        .ToList();
                default:
                    throw new JsonException("Unexpected token type: " + token.Type);
            }
        }
    }
}
