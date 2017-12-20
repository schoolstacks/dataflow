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
    public class DataMapperListConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var list = (List<DataMapper>)value;
            var obj = new JObject(list.Select(dm =>
            {
                var val = dm.DataMapperProperty != null
                    ? JToken.FromObject(dm.DataMapperProperty, serializer)
                    : JToken.FromObject(dm.SubDataMappers, serializer);

                return new JProperty(dm.Name, val);
            }));
            obj.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            var list = token
                .Children<JProperty>()
                .Select(jp =>
                {
                    var mapper = new DataMapper { Name = jp.Name };

                    if (jp.Value["data-type"] != null)
                        mapper.DataMapperProperty = jp.Value.ToObject<DataMapperProperty>(serializer);
                    else
                        mapper.SubDataMappers = jp.Value.ToObject<List<DataMapper>>(serializer);
                    return mapper;
                })
                .ToList();
            return list;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<DataMapper>);
        }
    }
}
