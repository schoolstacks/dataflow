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
    public class AssessmentController : BaseController
    {
        private readonly DataFlowDbContext dataFlowDbContext;
        private readonly EdFiService edFiService;

        public AssessmentController(DataFlowDbContext dataFlowDbContext, EdFiService edFiService)
        {
            this.dataFlowDbContext = dataFlowDbContext;
            this.edFiService = edFiService;
        }

        public ActionResult Index()
        {
            var assessments = edFiService.GetAssessments(null, null);

            return View(assessments);
        }

        public ActionResult Add()
        {
            var assessment = new DataFlow.EdFi.Models.AssessmentComposite.Assessment();

            return View(assessment);
        }

        public ActionResult Edit(string id)
        {
            var assessment = edFiService.GetAssessmentById(id);

            return View(assessment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(DataFlow.EdFi.Models.AssessmentComposite.Assessment vm)
        {
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DataFlow.EdFi.Models.AssessmentComposite.Assessment vm)
        {
            return View(vm);
        }
    }
}