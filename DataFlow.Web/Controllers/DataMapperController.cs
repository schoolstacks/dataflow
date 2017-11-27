using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataFlow.Common.DAL;
using DataFlow.Web.Helpers;
using DataFlow.Web.Services;

namespace DataFlow.Web.Controllers
{
    public class DataMapperController : BaseController
    {
        private readonly DataFlowDbContext dataFlowDbContext;
        private readonly EdFiService edFiService;

        public DataMapperController(DataFlowDbContext dataFlowDbContext, EdFiService edFiService)
        {
            this.dataFlowDbContext = dataFlowDbContext;
            this.edFiService = edFiService;
        }

        // GET: DataMapper
        public ActionResult Index()
        {
            return View();
        }

        private List<SelectListItem> GetEntityList
        {
            get
            {
                var entityList = new List<SelectListItem>();
                entityList.Add(new SelectListItem() { Text = "Select Entity", Value = string.Empty });
                entityList.AddRange(dataFlowDbContext.Entities.Select(x =>
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