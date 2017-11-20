using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataFlow.Common.DAL;
using DataFlow.Web.Helpers;
using DataFlow.Web.Models;
using DataFlow.Web.Services;

namespace DataFlow.Web.Controllers
{
    public class SchoolController : BaseController
    {
        private DataFlowDbContext dataFlowDbContext;
        private EdFiService edFiService;

        public SchoolController(DataFlowDbContext dataFlowDbContext, EdFiService edFiService)
        {
            this.dataFlowDbContext = dataFlowDbContext;
            this.edFiService = edFiService;
        }

        // GET: School
        public ActionResult Index()
        {
            var schools = edFiService.GetSchools(0, 50);
            var schoolGrid = new List<SchoolViewModel.Grid>();
            schools.ForEach(x =>
            {
                var school = new SchoolViewModel.Grid()
                {
                    Id = x.id,
                    Name = x.nameOfInstitution,
                    Abbreviation = x.shortNameOfInstitution
                };
                schoolGrid.Add(school);
            });

            return View(schoolGrid);
        }
    }
}