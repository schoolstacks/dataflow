using System.Collections.Generic;
using System.Web.Mvc;
using DataFlow.Common.DAL;
using DataFlow.Web.Helpers;
using DataFlow.Web.Models;
using DataFlow.Web.Services;

namespace DataFlow.Web.Controllers
{
    public class SchoolController : BaseController
    {
        private readonly DataFlowDbContext dataFlowDbContext;
        private readonly EdFiService edFiService;

        public SchoolController(DataFlowDbContext dataFlowDbContext, EdFiService edFiService)
        {
            this.dataFlowDbContext = dataFlowDbContext;
            this.edFiService = edFiService;
        }

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

        public ActionResult Details(string id)
        {
            var school = edFiService.GetSchool(id);

            var vm = new SchoolViewModel.Detail
            {
                Id = school.id,
                Name = school.nameOfInstitution,
                Students = edFiService.GetStudentsBySchoolId(id),
                Staves = edFiService.GetStaffBySchoolId(id),
                Sections = edFiService.GetSectionsBySchoolId(id),
                Assessments = edFiService.GetAssessmentsBySchoolId(id)
            };

            return View(vm);
        }
    }
}