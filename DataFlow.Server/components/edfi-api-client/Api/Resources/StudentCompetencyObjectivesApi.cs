using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.OdsApi.Sdk;
using EdFi.OdsApi.Models.Resources;
using RestSharp;
  
namespace EdFi.OdsApi.Api.Resources 
{
    public class StudentCompetencyObjectivesApi 
    {
        private readonly IRestClient client;

        public StudentCompetencyObjectivesApi(IRestClient client)
        {
            this.client = client;
        }
      
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StudentCompetencyObjective>> GetStudentCompetencyObjectivesAll(int? offset= null, int? limit= null) 
        {
            var request = new RestRequest("/studentCompetencyObjectives", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            var response = client.Execute<List<StudentCompetencyObjective>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources matching values of an example resource (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get by Example&quot; search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="studentUniqueId">A unique alpha-numeric code assigned to a student.</param>
        /// <param name="objective">The designated title of the learning objective.</param>
        /// <param name="objectiveGradeLevelDescriptor">The grade level for which the learning objective is targeted,</param>
        /// <param name="objectiveEducationOrganizationId">EducationOrganization Identity Column</param>
        /// <param name="schoolId">School Identity Column</param>
        /// <param name="gradingPeriodDescriptor">The name of the grading period during the school year in which the grade is offered (e.g., 1st cycle, 1st semester)</param>
        /// <param name="gradingPeriodBeginDate">Month, day, and year of the first day of the GradingPeriod.</param>
        /// <param name="competencyLevelDescriptor">The competency level assessed for the student for the referenced learning objective.</param>
        /// <param name="programEducationOrganizationId">EducationOrganization Identity Column</param>
        /// <param name="programType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="programName">The formal name of the program of instruction, training, services, or benefits available through federal, state, or local agencies.</param>
        /// <param name="educationOrganizationId">School Identity Column</param>
        /// <param name="diagnosticStatement">A statement provided by the teacher that provides information in addition to the grade or assessment score.</param>
        /// <param name="beginDate">Month, day and year of the student's entry or assignment to the section.  If blank, default is the start date of the first grading period. NEDM: EntryDate</param>
        /// <param name="uniqueSectionCode">A unique identifier for the section, that is defined for a campus by the classroom, the subjects taught, and the instructors that are assigned.  NEDM: Unique Course Code</param>
        /// <param name="sequenceOfCourse">When a section is part of a sequence of parts for a course, the number if the sequence.  If the course has only onle part, the value of this section attribute should be 1.</param>
        /// <param name="schoolYear">The identifier for the school year.</param>
        /// <param name="termDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="localCourseCode">The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.</param>
        /// <param name="classroomIdentificationCode">A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.</param>
        /// <param name="classPeriodName">An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period or AB schedules).  =</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StudentCompetencyObjective>> GetStudentCompetencyObjectivesAll(int? offset= null, int? limit= null, string studentUniqueId= null, string objective= null, string objectiveGradeLevelDescriptor= null, int? objectiveEducationOrganizationId= null, int? schoolId= null, string gradingPeriodDescriptor= null, DateTime? gradingPeriodBeginDate= null, string competencyLevelDescriptor= null, int? programEducationOrganizationId= null, string programType= null, string programName= null, int? educationOrganizationId= null, string diagnosticStatement= null, DateTime? beginDate= null, string uniqueSectionCode= null, int? sequenceOfCourse= null, int? schoolYear= null, string termDescriptor= null, string localCourseCode= null, string classroomIdentificationCode= null, string classPeriodName= null, string id= null) 
        {
            var request = new RestRequest("/studentCompetencyObjectives", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (objective != null)
                request.AddParameter("objective", objective);
            if (objectiveGradeLevelDescriptor != null)
                request.AddParameter("objectiveGradeLevelDescriptor", objectiveGradeLevelDescriptor);
            if (objectiveEducationOrganizationId != null)
                request.AddParameter("objectiveEducationOrganizationId", objectiveEducationOrganizationId);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (gradingPeriodDescriptor != null)
                request.AddParameter("gradingPeriodDescriptor", gradingPeriodDescriptor);
            if (gradingPeriodBeginDate != null)
                request.AddParameter("gradingPeriodBeginDate", gradingPeriodBeginDate);
            if (competencyLevelDescriptor != null)
                request.AddParameter("competencyLevelDescriptor", competencyLevelDescriptor);
            if (programEducationOrganizationId != null)
                request.AddParameter("programEducationOrganizationId", programEducationOrganizationId);
            if (programType != null)
                request.AddParameter("programType", programType);
            if (programName != null)
                request.AddParameter("programName", programName);
            if (educationOrganizationId != null)
                request.AddParameter("educationOrganizationId", educationOrganizationId);
            if (diagnosticStatement != null)
                request.AddParameter("diagnosticStatement", diagnosticStatement);
            if (beginDate != null)
                request.AddParameter("beginDate", beginDate);
            if (uniqueSectionCode != null)
                request.AddParameter("uniqueSectionCode", uniqueSectionCode);
            if (sequenceOfCourse != null)
                request.AddParameter("sequenceOfCourse", sequenceOfCourse);
            if (schoolYear != null)
                request.AddParameter("schoolYear", schoolYear);
            if (termDescriptor != null)
                request.AddParameter("termDescriptor", termDescriptor);
            if (localCourseCode != null)
                request.AddParameter("localCourseCode", localCourseCode);
            if (classroomIdentificationCode != null)
                request.AddParameter("classroomIdentificationCode", classroomIdentificationCode);
            if (classPeriodName != null)
                request.AddParameter("classPeriodName", classPeriodName);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<StudentCompetencyObjective>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the values of the resource's natural key (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get by Key&quot; search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="studentUniqueId">A unique alpha-numeric code assigned to a student.</param>
        /// <param name="objective">The designated title of the learning objective.</param>
        /// <param name="objectiveGradeLevelDescriptor">The grade level for which the learning objective is targeted,</param>
        /// <param name="objectiveEducationOrganizationId">EducationOrganization Identity Column</param>
        /// <param name="schoolId">School Identity Column</param>
        /// <param name="gradingPeriodDescriptor">The name of the grading period during the school year in which the grade is offered (e.g., 1st cycle, 1st semester)</param>
        /// <param name="gradingPeriodBeginDate">Month, day, and year of the first day of the GradingPeriod.</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<StudentCompetencyObjective> GetStudentCompetencyObjectiveByKey(string studentUniqueId, string objective, string objectiveGradeLevelDescriptor, int? objectiveEducationOrganizationId, int? schoolId, string gradingPeriodDescriptor, DateTime? gradingPeriodBeginDate, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/studentCompetencyObjectives", Method.GET);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (studentUniqueId == null || objective == null || objectiveGradeLevelDescriptor == null || objectiveEducationOrganizationId == null || schoolId == null || gradingPeriodDescriptor == null || gradingPeriodBeginDate == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (objective != null)
                request.AddParameter("objective", objective);
            if (objectiveGradeLevelDescriptor != null)
                request.AddParameter("objectiveGradeLevelDescriptor", objectiveGradeLevelDescriptor);
            if (objectiveEducationOrganizationId != null)
                request.AddParameter("objectiveEducationOrganizationId", objectiveEducationOrganizationId);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (gradingPeriodDescriptor != null)
                request.AddParameter("gradingPeriodDescriptor", gradingPeriodDescriptor);
            if (gradingPeriodBeginDate != null)
                request.AddParameter("gradingPeriodBeginDate", gradingPeriodBeginDate);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<StudentCompetencyObjective>(request);

            return response;
        }
        /// <summary>
        /// Creates or updates resources based on the natural key values of the supplied resource. The POST operation can be used to create or update resources. In database terms, this is often referred to as an &quot;upsert&quot; operation (insert + update).  Clients should NOT include the resource &quot;id&quot; in the JSON body because it will result in an error (you must use a PUT operation to update a resource by &quot;id&quot;). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.
        /// </summary>
        /// <param name="body">The JSON representation of the &quot;studentCompetencyObjective&quot; resource to be created or updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PostStudentCompetencyObjectives(StudentCompetencyObjective body) 
        {
            var request = new RestRequest("/studentCompetencyObjectives", Method.POST);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (body == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddBody(body);
            var response = client.Execute(request);

            var location = response.Headers.FirstOrDefault(x => x.Name == "Location");

            if (location != null && !string.IsNullOrWhiteSpace(location.Value.ToString()))
                body.id = location.Value.ToString().Split('/').Last();
            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the resource's identifier (using the &quot;Get By Id&quot; pattern). This GET operation retrieves a resource by the specified resource identifier.
        /// </summary>
        /// <param name="id">A resource identifier specifying the resource to be retrieved.</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<StudentCompetencyObjective> GetStudentCompetencyObjectivesById(string id, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/studentCompetencyObjectives/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<StudentCompetencyObjective>(request);

            return response;
        }
        /// <summary>
        /// Updates or creates a resource based on the resource identifier. The PUT operation is used to update or create a resource by identifier.  If the resource doesn't exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource &quot;id&quot; is provided in the JSON body, it will be ignored as well.
        /// </summary>
        /// <param name="id">A resource identifier specifying the resource to be updated.</param>
        /// <param name="IfMatch">The ETag header value used to prevent the PUT from updating a resource modified by another consumer.</param>
        /// <param name="body">The JSON representation of the &quot;studentCompetencyObjective&quot; resource to be updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PutStudentCompetencyObjective(string id, string IfMatch, StudentCompetencyObjective body) 
        {
            var request = new RestRequest("/studentCompetencyObjectives/{id}", Method.PUT);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null || body == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("If-Match", IfMatch);
            request.AddBody(body);
            var response = client.Execute(request);

            var location = response.Headers.FirstOrDefault(x => x.Name == "Location");

            if (location != null && !string.IsNullOrWhiteSpace(location.Value.ToString()))
                body.id = location.Value.ToString().Split('/').Last();
            return response;
        }
        /// <summary>
        /// Deletes an existing resource using the resource identifier. The DELETE operation is used to delete an existing resource by identifier.  If the resource doesn't exist, an error will result (the resource will not be found).
        /// </summary>
        /// <param name="id">A resource identifier specifying the resource to be deleted.</param>
        /// <param name="IfMatch">The ETag header value used to prevent the DELETE from removing a resource modified by another consumer.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse DeleteStudentCompetencyObjectiveById(string id, string IfMatch= null) 
        {
            var request = new RestRequest("/studentCompetencyObjectives/{id}", Method.DELETE);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("If-Match", IfMatch);
            var response = client.Execute(request);

            return response;
        }
        }
    }

