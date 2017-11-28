using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataFlow.Common.DAL;
using DataFlow.Common.Services;
using DataFlow.Web.Helpers;
using DataFlow.Web.Services;

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
            var vm = new Models.DataMapperViewModel();
            vm.Entities = GetEntityList;
            vm.Fields = new List<string>()
            {
                "FieldOne",
                "FieldTwo",
                "FieldThree"
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(Models.DataMapperViewModel vm)
        {
            return View(vm);
        }

        private List<SelectListItem> GetEntityList
        {
            get
            {
                var entityList = new List<SelectListItem>();
                entityList.Add(new SelectListItem() { Text = "Select Entity", Value = string.Empty });
                entityList.AddRange(dataFlowDbContext.Entities
                    .OrderBy(x => x.Name)
                    .Select(x =>
                        new SelectListItem()
                        {
                            Text = x.Name,
                            Value = x.Id.ToString()
                        }));

                return entityList;
            }
        }
    }
}