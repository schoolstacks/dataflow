using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using CsvHelper;
using DataFlow.Common.DAL;
using DataFlow.Common.ExtensionMethods;
using DataFlow.Common.Services;
using DataFlow.Models;
using DataFlow.Web.Helpers;
using DataFlow.Web.Models;
using DataFlow.Web.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataFlow.Web.Controllers
{
    public class DataMapperController : BaseController
    {
        private readonly DataFlowDbContext dataFlowDbContext;
        private readonly EdFiService edFiService;
        private readonly EdFiMetadataProcessor edFiMetadataProcessor;

        public DataMapperController(DataFlowDbContext dataFlowDbContext, EdFiService edFiService,
            EdFiMetadataProcessor edFiMetadataProcessor, ICentralLogger logger) : base(logger)
        {
            this.dataFlowDbContext = dataFlowDbContext;
            this.edFiService = edFiService;
            this.edFiMetadataProcessor = edFiMetadataProcessor;
        }

        public ActionResult Index()
        {
            var vm = new DataMapperViewModel
            {
                Entities = GetEntityList
            };

            if (TempData["CsvColumnHeaders"] is string csvColumnHeaders)
            {
                vm.CsvColumnHeaders = csvColumnHeaders.Split(',').ToList();
            }

            if (TempData["CsvDataPreview"] is DataTable csvDataTable)
            {
                vm.CsvPreviewDataTable = csvDataTable;
            }

            if (TempData["IsSuccess"] is bool isSuccess)
            {
                vm.IsSuccess = isSuccess;
            }

            if (TempData["ShowInfoMessage"] is bool showInfoMessage)
            {
                vm.ShowInfoMessage = showInfoMessage;
            }

            if (TempData["InfoMessage"] is string infoMessage)
            {
                vm.InfoMessage = infoMessage;
            }

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DataMapperViewModel vm)
        {
            try
            {
                var map = new DataFlow.Models.DataMap
                {
                    Name = vm.MapName,
                    EntityId = Convert.ToInt32(vm.MapToEntity),
                    Map = vm.JsonMap,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };

                dataFlowDbContext.DataMaps.Add(map);
                dataFlowDbContext.SaveChanges();

                ModelState.Clear();

                vm = new DataMapperViewModel
                {
                    MapName = string.Empty,
                    MapToEntity = string.Empty,
                    JsonMap = string.Empty,
                    Entities = GetEntityList,
                    DataSources = GetDataSourceList,
                    SourceTables = GetSourceTableList,
                    Fields = new List<DataMapperViewModel.Field>(),
                    CsvColumnHeaders = new List<string>(),
                    IsSuccess = true,
                    ShowInfoMessage = true,
                    InfoMessage = "Data Map was created successfully!"
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                Logger.Error("Error Saving Advanced Data Map", ex);
                vm.Entities = GetEntityList;
                vm.DataSources = GetDataSourceList;
                vm.SourceTables = GetSourceTableList;
                vm.IsSuccess = false;
                vm.ShowInfoMessage = true;
                vm.InfoMessage = "There was an error saving the data map.";

                return View(vm);
            }
        }

        [HttpPost]
        public ActionResult AddModelFields(FormCollection formCollection)
        {
            var vm = new DataMapperViewModel
            {
                MapName = formCollection["MapName"],
                MapToEntity = formCollection["MapToEntity"],
                JsonMap = string.Empty,
                Entities = GetEntityList,
                DataSources = GetDataSourceList,
                SourceTables = GetSourceTableList,
                CsvColumnHeaders = formCollection["CsvColumnHeaders"].Split(',').ToList(),
                Fields = new List<DataMapperViewModel.Field>()
            };

            if (int.TryParse(vm.MapToEntity, out var entityId))
            {
                //TODO: This can be vastly improved.
                var entitySelected = dataFlowDbContext.Entities.FirstOrDefault(x => x.Id == entityId);
                if (!string.IsNullOrWhiteSpace(entitySelected?.Url))
                {
                    var entityJson = edFiMetadataProcessor.GetJsonFromUrl(entitySelected.Url);
                    var apiFields = edFiMetadataProcessor.GetFieldListFromJson(entityJson, entitySelected.Name)
                        .Where(x => x.Required)
                        .ToList();

                    apiFields.ForEach(x =>
                    {
                        if (x.Name == "id")
                            return;

                        if (x.Required)
                        {
                            var dataMapperField = new DataMapperViewModel.Field(x.Name, x.Type, !string.IsNullOrWhiteSpace(x.SubType) ? x.Name : string.Empty, string.Empty);
                            if (!string.IsNullOrWhiteSpace(x.SubType) && x.SubFields.Any())
                            {
                                x.SubFields.ForEach(subField =>
                                {
                                    if (subField.Name == "id")
                                        return;
                                    ;
                                    if (subField.Required)
                                    {
                                        dataMapperField.SubFields.Add(new DataMapperViewModel.Field(subField.Name, subField.Type,  !string.IsNullOrWhiteSpace(subField.SubType) ? subField.Name : string.Empty, !string.IsNullOrWhiteSpace(x.SubType) ? x.Name : string.Empty));
                                    }
                                });
                            }
                            vm.Fields.Add(dataMapperField);
                        }
                    });
                }
            }

            return PartialView("_PartialDataMapperFields", vm);
        }

        [HttpPost]
        public JsonResult UpdateJsonMap(FormCollection formCollection)
        {
            var fields = formCollection["FieldNames"].Split(';').ToList();
            //var subFields = new List<Tuple<string,List<string>>>();

            var jObject = new JObject();

            fields.ForEach(f =>
            {
                //var subType = formCollection[$"hf{f}_SubType"].NullIfWhiteSpace();
                //if (subType != null)
                //{
                //    if (subFields.All(x => x.Item1 != subType))
                //    {
                //        subFields.Add(new Tuple<string, List<string>>(subType, formCollection.AllKeys.Where(x=>x.EndsWith(subType)).Select(x=>x).ToList()));
                //    }
                //}


                //if (subType == null)
                //{
                var parentType = formCollection[$"hf{f}_ParentType"]?.NullIfWhiteSpace();
                var dataType = formCollection[$"hf{f}_DataType"]?.NullIfWhiteSpace();

                var model = new DataMapper();
                model.Name = f;

                if (parentType == null && dataType != "array")
                {
                    model.DataMapperProperty = new DataMapperProperty
                    {
                        Source = formCollection[$"ddl{f}_SourceType"]?.NullIfWhiteSpace(),
                        SourceColumn = formCollection[$"ddl{f}_SourceColumn"]?.NullIfWhiteSpace(),
                        DataType = formCollection[$"hf{f}_DataType"]?.NullIfWhiteSpace(),
                        Default = formCollection[$"txt{f}_DefaultValue"]?.NullIfWhiteSpace(),
                        SourceTable = formCollection[$"ddl{f}_SourceTable"]?.NullIfWhiteSpace(),
                        Value = formCollection[$"txt{f}_StaticValue"]?.NullIfWhiteSpace(),
                        ChildType = formCollection[$"hf{f}_ChildType"].NullIfWhiteSpace(),
                        ParentType = formCollection[$"hf{f}_ParentType"].NullIfWhiteSpace()
                    };

                    jObject.Add(model.Name, JObject.FromObject(model.DataMapperProperty));
                }
                else if(parentType != null)
                {
                    model.DataMapperProperty = new DataMapperProperty
                    {
                        Source = formCollection[$"ddl{f}_SourceType_{parentType}"]?.NullIfWhiteSpace(),
                        SourceColumn = formCollection[$"ddl{f}_SourceColumn_{parentType}"]?.NullIfWhiteSpace(),
                        DataType = formCollection[$"hf{f}_DataType_{parentType}"]?.NullIfWhiteSpace(),
                        Default = formCollection[$"txt{f}_DefaultValue_{parentType}"]?.NullIfWhiteSpace(),
                        SourceTable = formCollection[$"ddl{f}_SourceTable_{parentType}"]?.NullIfWhiteSpace(),
                        Value = formCollection[$"txt{f}_StaticValue_{parentType}"]?.NullIfWhiteSpace(),
                        ChildType = formCollection[$"hf{f}_ChildType"].NullIfWhiteSpace(),
                        ParentType = formCollection[$"hf{f}_ParentType"].NullIfWhiteSpace()
                    };

                    var jObjectChild = new JObject(new JProperty(f, (JObject)JToken.FromObject(model.DataMapperProperty)));

                    if (jObject.Property(parentType) == null)
                    {
                        jObject.Add(parentType, new JArray(jObjectChild));
                    }
                    else
                    {
                        ((JArray)jObject[parentType]).Last().AddAfterSelf(jObjectChild);
                    }
                }
            });

            jObject.Add("_required", JArray.FromObject(fields));

            var cleanJson = JsonHelper.RemoveEmptyChildren(jObject);
            var jsonMap = cleanJson.ToString(Formatting.Indented);

            return Json(jsonMap);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadFile(HttpPostedFileBase uploadCsvFile)
        {
            try
            {
                if (uploadCsvFile.ContentLength > 0)
                {
                    var csvDataTable = new DataTable();

                    var csvPreviewHeaders = new List<string>();
                    var linesToRead = 5;
                    var linesRead = 1;

                    var csvConfg = new CsvHelper.Configuration.Configuration
                    {
                        HasHeaderRecord = true,
                        TrimOptions = CsvHelper.Configuration.TrimOptions.InsideQuotes,
                        MissingFieldFound = null,
                    };

                    using (var streamReader = new StreamReader(uploadCsvFile.InputStream))
                    {
                        using (var csvHelper = new CsvReader(streamReader, csvConfg))
                        {
                            csvHelper.Read();
                            csvHelper.ReadHeader();
                            csvPreviewHeaders.AddRange(csvHelper.Context.HeaderRecord);
                            TempData["CsvColumnHeaders"] = string.Join(",", csvPreviewHeaders);

                            csvPreviewHeaders.ForEach(x =>
                            {
                                csvDataTable.Columns.Add(x);

                            });
                            csvHelper.Read();
                            do
                            {
                                var row = csvDataTable.NewRow();
                                foreach (DataColumn column in csvDataTable.Columns)
                                {
                                    row[column.ColumnName] = csvHelper.GetField(column.DataType, column.ColumnName);
                                }
                                csvDataTable.Rows.Add(row);
                                linesRead++;
                            } while (csvHelper.Read() && linesRead <= linesToRead);
                        }
                    }

                    TempData["CsvDataPreview"] = csvDataTable;
                    TempData["IsSuccess"] = true;
                    TempData["ShowInfoMessage"] = true;
                    TempData["InfoMessage"] = "File Uploaded! Please continue creating your map below.";
                }
                else
                {
                    TempData["IsSuccess"] = false;
                    TempData["ShowInfoMessage"] = true;
                    TempData["InfoMessage"] = "The file you've uploaded does not contain any information.";
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Data Mapper Error Uploading File", ex);
                TempData["IsSuccess"] = false;
                TempData["ShowInfoMessage"] = true;
                TempData["InfoMessage"] = "There was an error uploading your file.";
            }

            return RedirectToAction("Index");
        }

        private List<SelectListItem> GetEntityList
        {
            get
            {
                var entityList = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Select Entity", Value = string.Empty}
                };
                entityList.AddRange(dataFlowDbContext.Entities
                    .OrderBy(x => x.Name)
                    .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }));

                return entityList;
            }
        }

        private List<SelectListItem> GetDataSourceList
        {
            get
            {
                var dataTypeList = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Select Data Source", Value = string.Empty}
                };
                dataTypeList.AddRange(Enum.GetValues(typeof(DataMapperEnums.Sources))
                    .Cast<DataMapperEnums.Sources>()
                    .Select(x => new SelectListItem { Text = x.GetDescription(), Value = x.GetDescription() }));

                return dataTypeList;
            }
        }

        private List<SelectListItem> GetSourceTableList
        {
            get
            {
                var sourceTableList = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Select Source Table", Value = string.Empty}
                };
                sourceTableList.AddRange(dataFlowDbContext.Lookups
                    .Select(x => new SelectListItem { Text = x.GroupSet, Value = x.GroupSet })
                    .Distinct());

                return sourceTableList;
            }
        }
    }
}