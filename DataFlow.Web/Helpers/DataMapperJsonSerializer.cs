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
            //List<DataMapper> list = (List<DataMapper>)value;
            //if (list.Any(dm => dm.DataMapperProperty != null))
            //{
            //    serializer.Serialize(writer,
            //        list.ToDictionary(dm => dm.Name, dm => dm.DataMapperProperty));
            //}
            //else if (list.SelectMany(x => x.SubDataMappers.SelectMany(y => y.SubDataMappers)).Any(dm => dm.DataMapperProperty != null))
            //{
            //    serializer.Serialize(writer,
            //        list.SelectMany(x => x.SubDataMappers.SelectMany(y => y.SubDataMappers)).ToDictionary(dm=> dm.Name, dm=>dm.DataMapperProperty));
            //}
            //else
            //{

            //    serializer.Serialize(writer,
            //        list.Select(dm => new Dictionary<string, List<DataMapper>>
            //        {
            //            { dm.Name, dm.SubDataMappers.SelectMany(x=>x.SubDataMappers).Any() ? dm.SubDataMappers.SelectMany(x=>x.SubDataMappers).ToList() : dm.SubDataMappers }
            //        }));

            //    if(list.SelectMany(x=>x.SubDataMappers).Any(x=>x.SubDataMappers.Any()))
            //    {
            //        serializer.Serialize(writer,
            //        list.SelectMany(x=>x.SubDataMappers)
            //        .Select(dm => new Dictionary<string, List<DataMapper>>
            //            {
            //                { dm.Name, dm.SubDataMappers }
            //            }));

            //    }
            //}

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


                                    if (subObj.SubDataMappers.Any())
                                    {
                                        writer.WriteStartObject();
                                        for (var t = 0; t < subObj.SubDataMappers.Count; t++)
                                        {
                                            var triObj = subObj.SubDataMappers.ElementAt(t);
                                            writer.WritePropertyName(triObj.Name);
                                            serializer.Serialize(writer, triObj.DataMapperProperty);
                                        }
                                        writer.WriteEndObject();
                                    }
                                    else
                                    {
                                        serializer.Serialize(writer, subObj.DataMapperProperty);
                                    }
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
            //JToken token = JToken.Load(reader);
            //if (token.Type == JTokenType.Object)
            //{
            //    return token.Children<JProperty>()
            //        .Select(jp => new DataMapper
            //        {
            //            Name = jp.Name,
            //            DataMapperProperty = jp.Value.ToObject<DataMapperProperty>(serializer)
            //        })
            //        .ToList();
            //}
            //else if (token.Type == JTokenType.Array)
            //{
            //    return token.Children<JObject>()
            //        .SelectMany(jo => jo.Properties())
            //        .Select(jp => new DataMapper
            //        {
            //            Name = jp.Name,
            //            SubDataMappers = jp.Value.ToObject<List<DataMapper>>(serializer)
            //        })
            //        .ToList();
            //}
            //else
            //{
            //    throw new JsonException("Unexpected token type: " + token.Type.ToString());
            //}

            var dataMapperModels = new List<DataMapper>();

            JArray jArray = JArray.Load(reader);
            foreach (JToken jToken in jArray)
            {
                JObject jObject = (JObject)jToken;
                var properties = jObject.Properties().ToList();


                var dataMapper = new DataMapper();
                dataMapper.Name = properties[0].Name;
                dataMapper.DataMapperProperty = new DataMapperProperty();
                dataMapper.SubDataMappers = new List<DataMapper>();

                dataMapperModels.Add(dataMapper);
            }

           // var properties = jsonObject.Properties().ToList();
            //return new DataMapper()
            //{
            //    Name = properties[0].Name,
            //    DataMapperProperty = (DataMapperProperty)properties[0].Value
            //};
            return dataMapperModels;
        }

        public override bool CanConvert(Type objectType)
        {
            //return objectType == typeof(List<DataMapper>);
            return typeof(DataMapper).IsAssignableFrom(objectType);
        }

        private string CleanJsonArrayObjectName(string objectName)
        {
            return objectName.LastIndexOf('_') > 0 ? objectName.Remove(objectName.LastIndexOf('_')) : objectName;
        }
    }
}