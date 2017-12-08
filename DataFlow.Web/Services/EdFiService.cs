using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using DataFlow.Common.DAL;
using DataFlow.EdFi.Api.AssessmentComposite;
using DataFlow.EdFi.Api.Descriptors;
using DataFlow.EdFi.Api.EnrollmentComposite;
using DataFlow.EdFi.Api.Resources;
using DataFlow.EdFi.Models.Descriptors;
using DataFlow.EdFi.Models.Resources;
using DataFlow.EdFi.Sdk;
using DataFlow.Models;
using DataFlow.Web.Helpers;
using RestSharp;
using Assessment = DataFlow.EdFi.Models.AssessmentComposite.Assessment;
using School = DataFlow.EdFi.Models.EnrollmentComposite.School;
using Section = DataFlow.EdFi.Models.EnrollmentComposite.Section;
using Staff = DataFlow.EdFi.Models.EnrollmentComposite.Staff;
using Student = DataFlow.EdFi.Models.EnrollmentComposite.Student;
using StudentAssessment = DataFlow.EdFi.Models.AssessmentComposite.StudentAssessment;

namespace DataFlow.Web.Services
{
    public class EdFiService
    {
        private readonly DataFlowDbContext dataFlowDbContext;
        private readonly ConfigurationService configurationService;

        public EdFiService(DataFlowDbContext dataFlowDbContext, ConfigurationService configurationService)
        {
            this.dataFlowDbContext = dataFlowDbContext;
            this.configurationService = configurationService;
        }

        private IRestClient EstablishApiClient()
        {
            // Ignore SSL errors for now
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var conf = configurationService.GetConfiguration();
            var odsapiurlbase = conf.API_SERVER_URL;
            var odsapioauthurl = Helpers.Common.GetUntilOrEmpty(odsapiurlbase, "/api/");
            var odsapikey = conf.API_SERVER_KEY;
            var odsapisecret = conf.API_SERVER_SECRET;

            IRestClient client = null;
            TokenRetriever tokenRetriever = new TokenRetriever(odsapioauthurl, odsapikey, odsapisecret);
            client = new RestClient(odsapiurlbase);
            client.Authenticator = new BearerTokenAuthenticator(tokenRetriever);

            return client;
        }

        public List<Staff> GetStaffBySchoolId(string schoolId)
        {
            IRestClient client = EstablishApiClient();
            EnrollmentApi api = new EnrollmentApi(client);
            IRestResponse<List<Staff>> response = api.GetStaffsBySchool(schoolId, null, 100);
            return response.Data;
        }

        public List<Student> GetStudentsBySchoolId(string schoolId)
        {
            IRestClient client = EstablishApiClient();
            EnrollmentApi api = new EnrollmentApi(client);
            IRestResponse<List<Student>> response = api.GetStudentsBySchool(schoolId, null, 100);
            return response.Data;
        }

        public List<Section> GetSectionsBySchoolId(string schoolId)
        {
            IRestClient client = EstablishApiClient();
            EnrollmentApi api = new EnrollmentApi(client);
            IRestResponse<List<Section>> response = api.GetSectionsBySchool(schoolId, null, 100);
            return response.Data;
        }

        public List<Assessment> GetAssessments(int? offset, int? limit)
        {
            var api = new AssessmentApi(EstablishApiClient());
            return api.GetAssessmentsAll(offset, limit).Data;
        }

        public List<Assessment> GetAssessmentsBySchoolId(string schoolId)
        {
            IRestClient client = EstablishApiClient();
            AssessmentApi api = new AssessmentApi(client);
            var response = api.GetAssessmentsBySchool(schoolId, null, 100);
            return response.Data;
        }

        public Assessment GetAssessmentById(string id)
        {
            IRestClient client = EstablishApiClient();
            AssessmentApi api = new AssessmentApi(client);
            var response = api.GetAssessmentsById(id);
            return response.Data;
        }
        public List<StudentAssessment> GetStudentAssessmentsByAssessmentId(string assessmentId)
        {
            IRestClient client = EstablishApiClient();
            AssessmentApi api = new AssessmentApi(client);
            var response = api.GetStudentAssessmentsByAssessment(assessmentId, null, 100);
            return response.Data;
        }
        public List<School> GetSchools(int? offset, int? limit)
        {
            IRestClient client = EstablishApiClient();
            EnrollmentApi api = new EnrollmentApi(client);
            IRestResponse<List<School>> response = api.GetSchoolsAll(offset, limit);
            return response.Data;
        }

        public List<StateEducationAgency> GetStateEducationAgencies(int? offset, int? limit)
        {
            var api = new StateEducationAgenciesApi(EstablishApiClient());
            return api.GetStateEducationAgenciesAll(offset, limit).Data;
        }

        public List<LocalEducationAgency> GetLocalEducationAgencies(int? offset, int? limit)
        {
            var api = new LocalEducationAgenciesApi(EstablishApiClient());
            return api.GetLocalEducationAgenciesAll(offset, limit).Data;
        }

        public LocalEducationAgency GetLocalEducationAgencyById(string id)
        {
            var api = new LocalEducationAgenciesApi(EstablishApiClient());
            return api.GetLocalEducationAgenciesById(id).Data;
        }

        public List<LevelDescriptor> GetGradeLevels(int? offsent, int? limit)
        {
            var api = new LevelDescriptorsApi(EstablishApiClient());
            return api.GetLevelDescriptorsAll(offsent, limit).Data;
        }

        public List<DataFlow.EdFi.Models.Resources.Assessment> GetResourceAssessments(int? offset, int? limit)
        {
            var api = new DataFlow.EdFi.Api.Resources.AssessmentsApi(EstablishApiClient());
            return api.GetAssessmentsAll(offset, limit).Data;
        }

        public DataFlow.EdFi.Models.Resources.Assessment GetResourceAssessmentById(string id)
        {
            var api = new DataFlow.EdFi.Api.Resources.AssessmentsApi(EstablishApiClient());
            return api.GetAssessmentsById(id).Data;
        }

        public List<ObjectiveAssessment> GetObjectiveAssessments(int offset, int limit, string assessmentTitle = null)
        {
            var api = new ObjectiveAssessmentsApi(EstablishApiClient());
            return api.GetObjectiveAssessmentsAll(offset, limit, assessmentTitle).Data;
        }

        public List<AssessmentIdentificationSystemDescriptor> GetAssessmentIdentificationSystems(int? offset, int? limit)
        {
            var api = new AssessmentIdentificationSystemDescriptorsApi(EstablishApiClient());
            return api.GetAssessmentIdentificationSystemDescriptorsAll(offset, limit).Data;
        }

        public List<AssessmentCategoryDescriptor> GetAssessmentCategories(int? offset, int? limit)
        {
            var api = new AssessmentCategoryDescriptorsApi(EstablishApiClient());
            return api.GetAssessmentCategoryDescriptorsAll(offset, limit).Data;
        }

        public List<AcademicSubjectDescriptor> GetAcademicSubjects(int? offset, int? limit)
        {
            var api = new AcademicSubjectDescriptorsApi(EstablishApiClient());
            return api.GetAcademicSubjectDescriptorsAll(offset, limit).Data;
        }

        public EdFi.Models.Resources.School GetSchool(string id)
        {
            var api = new SchoolsApi(EstablishApiClient());
            return api.GetSchoolsById(id).Data;
        }

        public EdFi.Models.Resources.School GetSchoolBySchoolId(int schoolId)
        {
            var api = new SchoolsApi(EstablishApiClient());
            return api.GetSchoolByKey(schoolId).Data;
        }

        public IRestResponse CreateSchool(EdFi.Models.Resources.School school)
        {
            var api = new SchoolsApi(EstablishApiClient());
            return api.PostSchools(school);
        }

        public IRestResponse DeleteSchool(string id)
        {
            var api = new SchoolsApi(EstablishApiClient());
            return api.DeleteSchoolById(id);
        }

        public IRestResponse CreateAssessment(EdFi.Models.Resources.Assessment assessment)
        {
            var api = new AssessmentsApi(EstablishApiClient());
            return api.PostAssessments(assessment);
        }

        public IRestResponse CreateObjectiveAssessment(ObjectiveAssessment objectiveAssessment)
        {
            var api = new ObjectiveAssessmentsApi(EstablishApiClient());
            return api.PostObjectiveAssessments(objectiveAssessment);
        }

        public IRestResponse DeleteAssessment(string id)
        {
            var api = new AssessmentsApi(EstablishApiClient());
            return api.DeleteAssessmentById(id);
        }

        public IRestResponse DeleteObjectiveAssessment(string id)
        {
            var api = new ObjectiveAssessmentsApi(EstablishApiClient());
            return api.DeleteObjectiveAssessmentById(id);
        }
    }
}