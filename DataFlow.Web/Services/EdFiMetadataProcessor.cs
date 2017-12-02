using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using DataFlow.Common.Services;
using DataFlow.Models;
using Newtonsoft.Json.Linq;

namespace DataFlow.Web.Services
{
    public class EdFiMetadataProcessor
    {
        private readonly ICentralLogger logger;

        public EdFiMetadataProcessor(ICentralLogger logger)
        {
            this.logger = logger;
        }

        public JObject GetJsonFromFile(string fileName)
        {
            return JObject.Parse(System.IO.File.ReadAllText(fileName));
        }

        public JObject GetJsonFromUrl(string url)
        {
            using (var client = new WebClient())
            {
                var s = client.DownloadString(url);
                return JObject.Parse(s);
            }
        }

        private bool IsValueInArray(ArrayList fieldsArray, string valueName)
        {
            if (fieldsArray == null || valueName == null)
            {
                return false;
            }
            return fieldsArray.BinarySearch(valueName) >= 0;
        }

        public JObject GetApiPayloadfromSwaggerEntity(JObject json, string entity, ArrayList otherFieldsArray = null)
        {
            var returnObject = new JObject();
            var fieldList = GetFieldListFromJson(json, entity);

            foreach (var field in fieldList)
            {
                // If the user passed in "all" as the only option, return all fields // TODO: this actually changes the metadata, come up with another flag
                if (otherFieldsArray != null && otherFieldsArray.Count == 1 && otherFieldsArray[0].ToString() == "all")
                {
                    field.Required = true;
                }
                if (field.Name != "id" && (field.Required || IsValueInArray(otherFieldsArray, field.Name)))
                {
                    if (field.Type != "string" && field.Type != "date-time" && field.Type != "boolean" && field.Type != "integer")
                    {
                        if (field.Type == "array")
                        {
                            var array = new JArray { GetApiPayloadfromSwaggerEntity(json, field.SubType) };
                            returnObject.Add(field.Name, array);
                        }
                        else
                        {
                            returnObject.Add(field.Name, GetApiPayloadfromSwaggerEntity(json, field.Type));
                        }
                    }
                    else
                    {
                        var obj = new JObject(new JProperty("data-type", field.Type));
                        returnObject.Add(field.Name, obj);
                    }
                }
            }

            return returnObject;
        }

        public List<EdFiMetadataProcessorField> GetFieldListFromJson(JObject jsonObj, string entity)
        {
            var entityJsonName = entity;

            if (entity.Substring(entity.Length - 3) == "ies")
            {
                entityJsonName = entity.Substring(0, entity.Length - 3) + "y";
            }
            else if (entity.Substring(entity.Length - 1) == "s")
            {
                entityJsonName = entity.Substring(0, entity.Length - 1);
            }

            var fieldList = new List<EdFiMetadataProcessorField>();

            try
            {
                foreach (var jToken in jsonObj["models"][entityJsonName]["properties"])
                {
                    var property = (JProperty)jToken;
                    var returnField = new EdFiMetadataProcessorField
                    {
                        Name = property.Name,
                        Required = false
                    };
                    try
                    {
                        foreach (var jToken1 in property)
                        {
                            var variable = (JObject)jToken1;
                            if (variable["required"].ToString() == "True")
                            {
                                returnField.Required = true;
                            }
                            returnField.Type = variable["type"].ToString();

                            if (returnField.Type == "array")
                            {
                                returnField.SubType = variable["items"]["$ref"].Value<string>();

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error("EdFiMetaDataProcessor Error Getting Properties", ex);
                    }

                    fieldList.Add(returnField);
                }
            }
            catch (Exception ex)
            {
                logger.Error("EdFiMetaDataProcessor Error", ex);
            }

            return fieldList;
        }
    }
}
