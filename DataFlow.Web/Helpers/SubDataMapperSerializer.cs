using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataFlow.Web.Models;
using Newtonsoft.Json;

namespace DataFlow.Web.Helpers
{
    public class SubDataMapperSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is List<DataMapper> foo)
                foo.ForEach(f =>
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName(f.Name);
                    serializer.Serialize(writer, f.DataMapperProperty);
                    writer.WriteEndObject();
                });
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(List<DataMapper>).IsAssignableFrom(objectType);
        }
    }
}