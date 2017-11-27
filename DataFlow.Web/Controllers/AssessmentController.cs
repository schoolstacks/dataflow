using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Antlr.Runtime.Misc;
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
            var assessments = edFiService.GetResourceAssessments(null, null)
                .OrderBy(x=>x.Title)
                .ToList();

            return View(assessments);
        }

        public ActionResult Add()
        {
            ViewBag.AcademicSubjects = new SelectList(GetAcademicSubjectList, "Value", "Text");
            ViewBag.IdentificationSystems = new SelectList(GetIdentificationSystemList, "Value", "Text");
            ViewBag.AssessmentCategories = new SelectList(GetAssessmentCategoryList, "Value", "Text");

            var vm = new Models.AssessmentViewModel.AddOrEdit
            {
                GradeLevels = GetGradeLevels(new List<SchoolGradeLevel>())
            };

            return View(vm);
        }

        public ActionResult Edit(string id)
        {
            ViewBag.AcademicSubjects = new SelectList(GetAcademicSubjectList, "Value", "Text");
            ViewBag.IdentificationSystems = new SelectList(GetIdentificationSystemList, "Value", "Text");
            ViewBag.AssessmentCategories = new SelectList(GetAssessmentCategoryList, "Value", "Text");

            var assessment = edFiService.GetResourceAssessmentById(id);
            var objectiveAssessments = edFiService.GetObjectiveAssessments(0, 100, assessment.Title);

            var vm = new Models.AssessmentViewModel.AddOrEdit
            {
                Assessment = assessment,
                IdentificationCode = assessment.IdentificationCodes.FirstOrDefault(),
                GradeLevels = GetGradeLevels(new ListStack<SchoolGradeLevel>()
                {
                    new SchoolGradeLevel() {GradeLevelDescriptor = assessment.AssessedGradeLevelDescriptor}
                }),
                ObjectiveAssessmentsText = string.Join(Environment.NewLine, objectiveAssessments.Select(x=>x.IdentificationCode))
            };

            return View(vm);
        }

        public ActionResult Delete(string id)
        {
            var assessment = edFiService.GetResourceAssessmentById(id);
            var objectiveAssessments = edFiService.GetObjectiveAssessments(0, 100, assessment.Title);

            objectiveAssessments.ForEach(x =>
            {
                edFiService.DeleteObjectiveAssessment(x.id);
            });

            edFiService.DeleteAssessment(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Models.AssessmentViewModel.AddOrEdit vm)
        {
            ViewBag.AcademicSubjects = new SelectList(GetAcademicSubjectList, "Value", "Text");
            ViewBag.IdentificationSystems = new SelectList(GetIdentificationSystemList, "Value", "Text");
            ViewBag.AssessmentCategories = new SelectList(GetAssessmentCategoryList, "Value", "Text");

            if (!GetSelectedGradeLevels(vm).Any())
            {
                ModelState.AddModelError("NoGradesSelected", "Please select the grade levels for this assessment.");
            }

            if (!ModelState.IsValid)
                return View(vm);

            SaveAssessment(vm);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.AssessmentViewModel.AddOrEdit vm)
        {
            ViewBag.AcademicSubjects = new SelectList(GetAcademicSubjectList, "Value", "Text");
            ViewBag.IdentificationSystems = new SelectList(GetIdentificationSystemList, "Value", "Text");
            ViewBag.AssessmentCategories = new SelectList(GetAssessmentCategoryList, "Value", "Text");

            if (!GetSelectedGradeLevels(vm).Any())
            {
                ModelState.AddModelError("NoGradesSelected", "Please select the grade levels for this assessment.");
            }

            if (!ModelState.IsValid)
                return View(vm);

            SaveAssessment(vm);

            return RedirectToAction("Index");
        }

        private void SaveAssessment(Models.AssessmentViewModel.AddOrEdit vm)
        {
            var selectedGradeLevels = GetSelectedGradeLevels(vm);

            var objectiveAssessments = vm.ObjectiveAssessmentsText
                .Split(new[] { Environment.NewLine, "," }, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim())
                .ToList();

            var assementCount = 0;
            var responseMsg = string.Empty;

            try
            {
                selectedGradeLevels.ForEach(gradeLevel =>
                {
                    var assessment = new EdFi.Models.Resources.Assessment()
                    {
                        Title = vm.Assessment.Title,
                        Version = vm.Assessment.Version,
                        Namespace = vm.Assessment.Namespace,
                        AcademicSubjectDescriptor = vm.Assessment.AcademicSubjectDescriptor,
                        AssessedGradeLevelDescriptor = gradeLevel.GradeLevelDescriptor,
                        CategoryDescriptor = vm.Assessment.CategoryDescriptor,
                        IdentificationCodes = new List<AssessmentIdentificationCode>
                        {
                            new AssessmentIdentificationCode
                            {
                                AssessmentIdentificationSystemDescriptor = vm.IdentificationCode.AssessmentIdentificationSystemDescriptor,
                                IdentificationCode = vm.Assessment.Title
                            }
                        }
                    };

                    var assementResponse = edFiService.CreateAssessment(assessment);
                    responseMsg = assementResponse.StatusDescription;

                    if (assementResponse.StatusCode == HttpStatusCode.Created)
                    {
                        assementCount++;

                        objectiveAssessments.ForEach(x =>
                        {
                            var objectiveAssessment = new ObjectiveAssessment
                            {
                                IdentificationCode = x,
                                assessmentReference = new AssessmentReference
                                {
                                    title = assessment.Title,
                                    academicSubjectDescriptor = assessment.AcademicSubjectDescriptor,
                                    assessedGradeLevelDescriptor = assessment.AssessedGradeLevelDescriptor,
                                    version = assessment.Version
                                }
                            };

                            edFiService.CreateObjectiveAssessment(objectiveAssessment);
                        });
                    }
                });
            }
            catch (Exception ex)
            {
                responseMsg = ex.Message;
            }
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

        private List<SchoolGradeLevel> GetSelectedGradeLevels(Models.AssessmentViewModel.AddOrEdit vm)
        {
            return vm.GradeLevels
                .Where(x => x.Checked)
                .Select(x => new SchoolGradeLevel()
                {
                    GradeLevelDescriptor = x.Text.Replace("_", " ") //In the view, for the labels to work we replace spaces with underscores
                })
                .ToList();
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
                    var gradeCheckBox = gradeLevelCheckBoxes.FirstOrDefault(x => x.Text == grade.GradeLevelDescriptor);
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