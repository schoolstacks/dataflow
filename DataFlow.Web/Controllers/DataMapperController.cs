using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsvHelper;
using DataFlow.Common.DAL;
using DataFlow.Common.ExtensionMethods;
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
            EdFiMetadataProcessor edFiMetadataProcessor, IBaseServices baseService) : base(baseService)
        {
            this.dataFlowDbContext = dataFlowDbContext;
            this.edFiService = edFiService;
            this.edFiMetadataProcessor = edFiMetadataProcessor;
        }

        public ActionResult Index()
        {
            var vm = InitializeViewModel();

            if (int.TryParse(Request.QueryString["entityId"], out var entityId))
            {
                vm.MapToEntity = entityId;
                vm = GetEntityFields(vm);
            }

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
            if (vm.MapToEntity == null)
            {
                ModelState.AddModelError("MapToEntity", "Please select an entity to map to.");
                return View(vm);
            }

            try
            {
                var map = new DataFlow.Models.DataMap
                {
                    Name = vm.MapName,
                    EntityId = vm.MapToEntity.Value,
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
                    MapToEntity = null,
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
                LogService.Error("Error Saving Advanced Data Map", ex);
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
            if (!int.TryParse(formCollection["MapToEntity"], out var entityId))
                throw new ArgumentException("Please select an entity to map to");

            var vm = InitializeViewModel(formCollection["MapName"], entityId, formCollection["CsvColumnHeaders"].Split(',').ToList());
            vm = GetEntityFields(vm);

            return PartialView("_PartialDataMapperFields", vm);
        }

        private DataMapperViewModel InitializeViewModel(string mapName = null, int? entityId = null, List<string> csvColumnHeaders = null)
        {
            var vm = new DataMapperViewModel
            {
                MapName = mapName ?? string.Empty,
                MapToEntity = entityId,
                JsonMap = string.Empty,
                CsvColumnHeaders = csvColumnHeaders ?? new List<string>(),
                Entities = GetEntityList,
                DataSources = GetDataSourceList,
                SourceTables = GetSourceTableList,
                Fields = new List<DataMapperViewModel.Field>()
            };
            return vm;
        }

        private DataMapperViewModel GetEntityFields(DataMapperViewModel vm)
        {
            var entitySelected = dataFlowDbContext.Entities.FirstOrDefault(x => x.Id == vm.MapToEntity);
            if (!string.IsNullOrWhiteSpace(entitySelected?.Url))
            {
                var entityJson = edFiMetadataProcessor.GetJsonFromUrl(entitySelected.Url);
                var apiFields = edFiMetadataProcessor.GetFieldListFromJson(entityJson, entitySelected.Name)
                    .Where(x => x.Required || GetAdditionalFields(entitySelected.Name).Contains(x.Name))
                    .ToList();

                apiFields.ForEach(x =>
                {
                    if (x.Name == "id")
                        return;

                    var dataMapperField = new DataMapperViewModel.Field(
                        name: x.Name,
                        dataType: x.Type,
                        childType: !string.IsNullOrWhiteSpace(x.SubType) ? x.Name : string.Empty,
                        parentType: string.Empty,
                        formFieldName: x.Name);
                    if (!string.IsNullOrWhiteSpace(x.SubType) && x.SubFields.Any())
                    {
                        x.SubFields.ForEach(subField =>
                        {
                            if (subField.Name == "id")
                                return;
                            ;
                            if (subField.Required)
                            {
                                dataMapperField.SubFields.Add(
                                    item: new DataMapperViewModel.Field(
                                        name: subField.Name,
                                        dataType: subField.Type,
                                        childType: !string.IsNullOrWhiteSpace(subField.SubType) ? subField.Name : string.Empty,
                                        parentType: !string.IsNullOrWhiteSpace(x.SubType) ? x.Name : string.Empty,
                                        formFieldName: $"{x.Name}_{subField.Name}")
                                );
                            }

                            if (!string.IsNullOrWhiteSpace(subField.SubType) && subField.SubFields.Any())
                            {
                                subField.SubFields.ForEach(triField =>
                                {
                                    if (triField.Name == "id")
                                        return;

                                    if (triField.Required)
                                    {
                                        dataMapperField.SubFields.Add(
                                            item: new DataMapperViewModel.Field(
                                                name: triField.Name,
                                                dataType: triField.Type,
                                                childType: !string.IsNullOrWhiteSpace(triField.SubType) ? triField.Name : string.Empty,
                                                parentType: !string.IsNullOrWhiteSpace(subField.SubType) ? $"{x.Name}:{subField.Name}" : string.Empty,
                                                formFieldName: $"{x.Name}_{subField.Name}_{triField.Name}")
                                        );
                                    }
                                });
                            }
                        });
                    }
                    vm.Fields.Add(dataMapperField);
                });
            }
            return vm;
        }

        [HttpPost]
        public JsonResult UpdateJsonMap(FormCollection formCollection, string triggeredBy)
        {
            var fields = formCollection["FieldNames"].Split(';').ToList();
            var errorAddingToJsonMap = new List<string>();
            var nonObjectsOrArrays = new[] { "string", "date-time", "boolean", "integer" };

            //var jObject = new JObject();

            var dataMapperModels = new List<DataMapper>();
            fields.ForEach(f =>
            {
                var fieldCount = formCollection[$"hf{f}_ChildType"]?.Split(',').Length ?? 0;

                for (var i = 0; i < fieldCount; i++)
                {
                    var dataType = formCollection[$"hf{f}_DataType"].SplitGetElementAt(',', i);
                    var childType = formCollection[$"hf{f}_ChildType"].SplitGetElementAt(',', i);
                    var parentType = formCollection[$"hf{f}_ParentType"].SplitGetElementAt(',', i);
                    var parentTypes = parentType?.Split(':').ToList() ?? new List<string>();
                    var firstParent = parentTypes.ElementAtOrDefault(0).NullIfWhiteSpace();
                    var secondParent = parentTypes.ElementAtOrDefault(1).NullIfWhiteSpace();

                    if (nonObjectsOrArrays.Contains(dataType) && firstParent == null)
                    {
                        var modelProperty = dataMapperModels.FirstOrDefault(x => x.Name == GetJsonFieldName(f));
                        if (modelProperty == null)
                        {
                            var model = new DataMapper
                            {
                                Name = GetJsonFieldName(f),
                                DataMapperProperty = new DataMapperProperty
                                {
                                    Source = formCollection[$"ddl{f}_SourceType"].SplitGetElementAt(',', i),
                                    SourceColumn = formCollection[$"ddl{f}_SourceColumn"].SplitGetElementAt(',', i),
                                    DataType = formCollection[$"hf{f}_DataType"].SplitGetElementAt(',', i),
                                    Default = formCollection[$"txt{f}_DefaultValue"].SplitGetElementAt(',', i),
                                    SourceTable = formCollection[$"ddl{f}_SourceTable"].SplitGetElementAt(',', i),
                                    Value = formCollection[$"txt{f}_StaticValue"].SplitGetElementAt(',', i),
                                    ChildType = formCollection[$"hf{f}_ChildType"].SplitGetElementAt(',', i),
                                    ParentType = formCollection[$"hf{f}_ParentType"].SplitGetElementAt(',', i)
                                }
                            };
                            dataMapperModels.Add(model);
                        }
                    }
                    else if (nonObjectsOrArrays.Contains(dataType) && secondParent != null)
                    {
                        var parentName = $"{firstParent}_Item{i}";

                        var parentModel = dataMapperModels
                                              .Where(x => x.Name == firstParent)
                                              .SelectMany(x => x.SubDataMappers)
                                              .Where(x => x.Name == parentName)
                                              .SelectMany(x => x.SubDataMappers)
                                              .Where(x => x.Name == secondParent)
                                              .SelectMany(x => x.SubDataMappers)
                                              .FirstOrDefault(x => x.Name == GetJsonFieldName(f))
                                          ??
                                          dataMapperModels
                                              .Where(x => x.Name == firstParent)
                                              .SelectMany(x => x.SubDataMappers)
                                              .Where(x => x.Name == parentName)
                                              .SelectMany(x => x.SubDataMappers)
                                              .FirstOrDefault(x => x.Name == secondParent);

                        parentModel?.SubDataMappers.Add(
                            new DataMapper()
                            {
                                Name = $"{GetJsonFieldName(f)}",
                                DataMapperProperty = new DataMapperProperty()
                                {
                                    Source = formCollection[$"ddl{f}_SourceType"].SplitGetElementAt(',', i),
                                    SourceColumn = formCollection[$"ddl{f}_SourceColumn"].SplitGetElementAt(',', i),
                                    DataType = formCollection[$"hf{f}_DataType"].SplitGetElementAt(',', i),
                                    Default = formCollection[$"txt{f}_DefaultValue"].SplitGetElementAt(',', i),
                                    SourceTable = formCollection[$"ddl{f}_SourceTable"].SplitGetElementAt(',', i),
                                    Value = formCollection[$"txt{f}_StaticValue"].SplitGetElementAt(',', i),
                                    ChildType = formCollection[$"hf{f}_ChildType"].SplitGetElementAt(',', i),
                                    ParentType = formCollection[$"hf{f}_ParentType"].SplitGetElementAt(',', i)
                                }
                            });
                    }
                    else
                    {
                        var addModel = false;

                        var model = dataMapperModels.FirstOrDefault(x => x.Name == GetJsonFieldName(f));

                        if (model == null)
                        {
                            addModel = true;
                            model = new DataMapper
                            {
                                Name = GetJsonFieldName(f)
                            };
                        }
                        if (model.SubDataMappers.All(x => x.Name != $"{GetJsonFieldName(f)}_Item{i}"))
                        {
                            model.SubDataMappers.Add(new DataMapper()
                            {
                                Name = $"{GetJsonFieldName(f)}_Item{i}",
                                DataMapperProperty = new DataMapperProperty()
                                {
                                    Source = formCollection[$"ddl{f}_SourceType"].SplitGetElementAt(',', i),
                                    SourceColumn = formCollection[$"ddl{f}_SourceColumn"].SplitGetElementAt(',', i),
                                    DataType = formCollection[$"hf{f}_DataType"].SplitGetElementAt(',', i),
                                    Default = formCollection[$"txt{f}_DefaultValue"].SplitGetElementAt(',', i),
                                    SourceTable = formCollection[$"ddl{f}_SourceTable"].SplitGetElementAt(',', i),
                                    Value = formCollection[$"txt{f}_StaticValue"].SplitGetElementAt(',', i),
                                    ChildType = formCollection[$"hf{f}_ChildType"].SplitGetElementAt(',', i),
                                    ParentType = formCollection[$"hf{f}_ParentType"].SplitGetElementAt(',', i)
                                }
                            });
                        }

                        if (firstParent != null && secondParent == null)
                        {
                            var parentName = $"{firstParent}_Item{i}";
                            var parentModel = dataMapperModels.SelectMany(x => x.SubDataMappers).FirstOrDefault(x => x.Name == parentName);

                            parentModel?.SubDataMappers.Add(
                                new DataMapper()
                                {
                                    Name = $"{GetJsonFieldName(f)}",
                                    DataMapperProperty = new DataMapperProperty()
                                    {
                                        Source = formCollection[$"ddl{f}_SourceType"].SplitGetElementAt(',', i),
                                        SourceColumn = formCollection[$"ddl{f}_SourceColumn"].SplitGetElementAt(',', i),
                                        DataType = formCollection[$"hf{f}_DataType"].SplitGetElementAt(',', i),
                                        Default = formCollection[$"txt{f}_DefaultValue"].SplitGetElementAt(',', i),
                                        SourceTable = formCollection[$"ddl{f}_SourceTable"].SplitGetElementAt(',', i),
                                        Value = formCollection[$"txt{f}_StaticValue"].SplitGetElementAt(',', i),
                                        ChildType = formCollection[$"hf{f}_ChildType"].SplitGetElementAt(',', i),
                                        ParentType = formCollection[$"hf{f}_ParentType"].SplitGetElementAt(',', i)
                                    }
                                });
                        }
                        else
                        {
                            if (addModel)
                                dataMapperModels.Add(model);
                        }
                    }


                }
            });

            //jObject.Add("_required", JArray.FromObject(fields));
            //jObject.Add("_errors", JArray.FromObject(errorAddingToJsonMap));

            var jsonMap = JsonConvert.SerializeObject(dataMapperModels, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });

            return Json(jsonMap);
        }

        private string GetJsonFieldName(string formField)
        {
            return formField.LastIndexOf('_') > 0 ? formField.Substring(formField.LastIndexOf('_') + 1) : formField;
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
                LogService.Error("Data Mapper Error Uploading File", ex);
                TempData["IsSuccess"] = false;
                TempData["ShowInfoMessage"] = true;
                TempData["InfoMessage"] = "There was an error uploading your file.";
            }

            return RedirectToAction("Index");
        }

        private List<string> GetAdditionalFields(string entityName)
        {
            var addtFields = new List<string>();

            if (entityName == "studentAssessments")
            {
                addtFields.AddRange(new[] { "performanceLevels", "scoreResults", "studentObjectiveAssessments" });
            }

            return addtFields;
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