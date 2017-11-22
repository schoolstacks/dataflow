using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DataFlow.Common.DAL;
using DataFlow.EdFi.Models.Resources;
using DataFlow.Models;
using DataFlow.Web.Helpers;
using DataFlow.Web.Models;
using DataFlow.Web.Services;
using System;

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
                Id = school.Id,
                Name = school.NameOfInstitution,
                Students = edFiService.GetStudentsBySchoolId(id),
                Staves = edFiService.GetStaffBySchoolId(id),
                Sections = edFiService.GetSectionsBySchoolId(id),
                Assessments = edFiService.GetAssessmentsBySchoolId(id)
            };

            return View(vm);
        }

        public ActionResult Add()
        {
            var vm = new SchoolViewModel.AddOrUpdate();
            vm.GradeLevels = GetGradeLevels;

            ViewBag.Districts = ViewBag.Entities = new SelectList(GetDistrictList, "Value", "Text");

            return View(vm);
        }

        public ActionResult Edit(string id)
        {
            var school = edFiService.GetSchool(id);

            var vm = new SchoolViewModel.AddOrUpdate
            {
                School = school,
                MailingAddress = school.Addresses.FirstOrDefault(x => x.AddressType == "Mailing") ?? school.Addresses.FirstOrDefault(),
                GradeLevels = GetGradeLevels
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(SchoolViewModel.AddOrUpdate vm)
        {
            var selectedGradeLevels = vm.GradeLevels
                .Where(x => x.Checked)
                .Select(x => new SchoolGradeLevel()
                {
                    gradeLevelDescriptor = x.Text
                })
                .ToList();

            var school = new EdFi.Models.Resources.School();
            school.SchoolId = vm.School.SchoolId;
            school.NameOfInstitution = vm.School.NameOfInstitution;
            school.ShortNameOfInstitution = vm.School.ShortNameOfInstitution;
            school.Website = vm.School.Website;
            school.StateOrganizationId = Convert.ToString(vm.School.SchoolId);
            school.LocalEducationAgencyReference = new LocalEducationAgencyReference()
            {
                localEducationAgencyId = vm.School.LocalEducationAgencyReference.localEducationAgencyId
            };
            school.Addresses = new List<EducationOrganizationAddress>()
            {
                new EducationOrganizationAddress()
                {
                    AddressType = "Mailing",
                    StreetNumberName = vm.MailingAddress.StreetNumberName,
                    City = vm.MailingAddress.City,
                    StateAbbreviationType = vm.MailingAddress.StateAbbreviationType,
                    PostalCode = vm.MailingAddress.PostalCode
                }
            };
            school.IdentificationCodes = new List<EducationOrganizationIdentificationCode>()
            {
                new EducationOrganizationIdentificationCode()
                {
                    educationOrganizationIdentificationSystemDescriptor = "School",
                    identificationCode = Convert.ToString(vm.School.SchoolId)
                }
            };
            school.EducationOrganizationCategories = new List<EducationOrganizationCategory>()
            {
                new EducationOrganizationCategory()
                {
                    type = "School"
                }
            };
            school.GradeLevels = new List<SchoolGradeLevel>(selectedGradeLevels);

            edFiService.CreateSchool(school);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(EdFi.Models.Resources.School vm)
        {
            return RedirectToAction("Index");
        }

        private List<CheckBox> GetGradeLevels
        {
            get
            {
                return dataFlowDbContext.EdfiDictionary
                    .OrderBy(x => x.DisplayOrder)
                    .Select(x=>new CheckBox(){Text = x.OriginalValue})
                    .ToList();
            }
        }

        private List<SelectListItem> GetDistrictList
        {
            get
            {
                var entityList = new List<SelectListItem>();
                entityList.Add(new SelectListItem() { Text = "Select Entity", Value = string.Empty });
                entityList.AddRange(edFiService.GetLocalEducationAgencies(0, 100).Select(x =>
                    new SelectListItem()
                    {
                        Text = x.nameOfInstitution,
                        Value = x.localEducationAgencyId.ToString()
                    }));

                return entityList;
            }
        }
    }
}