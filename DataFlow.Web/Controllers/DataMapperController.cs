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
            var vm = new DataMapperViewModel();
            vm.Entities = GetEntityList;
            vm.Fields = new List<string>
            {
                "FieldOne",
                "FieldTwo",
                "FieldThree"
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(DataMapperViewModel vm)
        {
            return View(vm);
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
                        DataType = "string",
                        Default = formCollection[$"txt{f}_DefaultValue"].NullIfWhiteSpace(),
                        SourceTable = formCollection[$"txt{f}_SourceTable"].NullIfWhiteSpace(),
                        Value = formCollection[$"txt{f}_StaticValue"].NullIfWhiteSpace()
                    }
                };

                jObject.Add(model.Name, JObject.FromObject(model.DataMapperProperty));
            });

            var cleanJson = JsonHelper.RemoveEmptyChildren(jObject);
            var jsonMap = cleanJson.ToString(Formatting.Indented);

            return Json(jsonMap);
        }

        private List<SelectListItem> GetEntityList
        {
            get
            {
                var entityList = new List<SelectListItem>();
                entityList.Add(new SelectListItem { Text = "Select Entity", Value = string.Empty });
                entityList.AddRange(dataFlowDbContext.Entities
                    .OrderBy(x => x.Name)
                    .Select(x =>
                        new SelectListItem
                        {
                            Text = x.Name,
                            Value = x.Id.ToString()
                        }));

                return entityList;
            }
        }
    }
}