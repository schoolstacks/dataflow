using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DataFlow.Common.DAL;
using DataFlow.EdFi.Models.Resources;
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
            ViewBag.AcademicSubjects = new SelectList(GetAcademicSubjectList, "Value", "Text");
            ViewBag.IdentificationSystems = new SelectList(GetIdentificationSystemList, "Value", "Text");
            ViewBag.AssessmentCategories = new SelectList(GetAssessmentCategoryList, "Value", "Text");

            var vm = new Models.AssessmentViewModel.AddOrEdit();
            vm.GradeLevels = GetGradeLevels(new List<SchoolGradeLevel>());

            return View(vm);
        }

        public ActionResult Edit(string id)
        {
            var assessment = edFiService.GetAssessmentById(id);

            var vm = new Models.AssessmentViewModel.AddOrEdit();
            vm.Assessment = assessment;
            vm.GradeLevels = GetGradeLevels(new List<SchoolGradeLevel>());

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Models.AssessmentViewModel.AddOrEdit vm)
        {
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.AssessmentViewModel.AddOrEdit vm)
        {
            return View(vm);
        }

        private List<SelectListItem> GetAcademicSubjectList
        {
            get
            {
                var subjectList = new List<SelectListItem>();
                subjectList.Add(new SelectListItem() { Text = "Select Subject", Value = string.Empty });
                subjectList.AddRange(edFiService.GetAcademicSubjects(null,null).Select(x =>
                    new SelectListItem()
                    {
                        Text = x.description,
                        Value = x.description
                    }));

                return subjectList;
            }
        }

        private List<SelectListItem> GetIdentificationSystemList
        {
            get
            {
                var identificationList = new List<SelectListItem>();
                identificationList.Add(new SelectListItem() { Text = "Select System", Value = string.Empty });
                identificationList.AddRange(edFiService.GetAssessmentIdentificationSystems(null, null).Select(x =>
                    new SelectListItem()
                    {
                        Text = x.description,
                        Value = x.description
                    }));

                return identificationList;
            }
        }

        private List<SelectListItem> GetAssessmentCategoryList
        {
            get
            {
                var assessmentCategoryList = new List<SelectListItem>();
                assessmentCategoryList.Add(new SelectListItem() { Text = "Select Category", Value = string.Empty });
                assessmentCategoryList.AddRange(edFiService.GetAssessmentCategories(null, null).Select(x =>
                    new SelectListItem()
                    {
                        Text = x.description,
                        Value = x.description
                    }));

                return assessmentCategoryList;
            }
        }

        private List<CheckBox> GetGradeLevels(List<SchoolGradeLevel> selectedGrades)
        {
            var gradeLevelCheckBoxes = dataFlowDbContext.EdfiDictionary
                .Where(x => x.GroupSet == "levelDescriptors")
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new CheckBox() { Text = x.OriginalValue })
                .ToList();

            if (selectedGrades.Any())
            {
                selectedGrades.ForEach(grade =>
                {
                    var gradeCheckBox = gradeLevelCheckBoxes.FirstOrDefault(x => x.Text == grade.gradeLevelDescriptor);
                    if (gradeCheckBox != null)
                    {
                        gradeCheckBox.Checked = true;
                    }
                });
            }

            return gradeLevelCheckBoxes;
        }
    }
}