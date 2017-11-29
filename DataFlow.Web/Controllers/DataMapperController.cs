using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataFlow.Common.DAL;
using DataFlow.Common.ExtensionMethods;
using DataFlow.Common.Services;
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

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DataMapperViewModel vm)
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
                Fields = new List<DataMapperViewModel.Field>()
            };

            ViewBag.Success = true;

            return View(vm);
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
                Fields = new List<DataMapperViewModel.Field>()
            };

            if (int.TryParse(vm.MapToEntity, out var entityId))
            {
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
                            vm.Fields.Add(new DataMapperViewModel.Field(x.Name, x.Type));
                    });
                }
            }

            return PartialView("_PartialDataMapperFields", vm);
        }

        [HttpPost]
        public JsonResult UpdateJsonMap(FormCollection formCollection)
        {
            var fields = formCollection["FieldNames"].Split(';').ToList();

            var jObject = new JObject();

            fields.ForEach(f =>
            {
                var model = new DataMapper
                {
                    Name = f,
                    DataMapperProperty = new DataMapperProperty
                    {
                        Source = formCollection[$"txt{f}_SourceType"].NullIfWhiteSpace(),
                        SourceColumn = formCollection[$"txt{f}_SourceColumn"].NullIfWhiteSpace(),
                        DataType = formCollection[$"hf{f}_DataType"].NullIfWhiteSpace(),
                        Default = formCollection[$"txt{f}_DefaultValue"].NullIfWhiteSpace(),
                        SourceTable = formCollection[$"txt{f}_SourceTable"].NullIfWhiteSpace(),
                        Value = formCollection[$"txt{f}_StaticValue"].NullIfWhiteSpace()
                    }
                };

                jObject.Add(model.Name, JObject.FromObject(model.DataMapperProperty));
            });

            jObject.Add("_required", JArray.FromObject(fields));

            var cleanJson = JsonHelper.RemoveEmptyChildren(jObject);
            var jsonMap = cleanJson.ToString(Formatting.Indented);

            return Json(jsonMap);
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
                    .Select(x => new SelectListItem {Text = x.Name, Value = x.Id.ToString()}));

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
                    .Select(x => new SelectListItem {Text = x.GetDescription(), Value = x.GetDescription()}));

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
                    .Select(x => new SelectListItem {Text = x.GroupSet, Value = x.GroupSet})
                    .Distinct());

                return sourceTableList;
            }
        }
    }
}