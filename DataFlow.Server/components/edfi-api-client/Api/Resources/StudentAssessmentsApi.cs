using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.OdsApi.Sdk;
using EdFi.OdsApi.Models.Resources;
using RestSharp;
  
namespace EdFi.OdsApi.Api.Resources 
{
    public class StudentAssessmentsApi 
    {
        private readonly IRestClient client;

        public StudentAssessmentsApi(IRestClient client)
        {
            this.client = client;
        }
      
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StudentAssessment>> GetStudentAssessmentsAll(int? offset= null, int? limit= null) 
        {
            var request = new RestRequest("/studentAssessments", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            var response = client.Execute<List<StudentAssessment>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources matching values of an example resource (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get by Example&quot; search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="studentUniqueId">A unique alpha-numeric code assigned to a student.</param>
        /// <param name="assessmentTitle">The title or name of the assessment.  NEDM: Assessment Title</param>
        /// <param name="academicSubjectDescriptor">The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject</param>
        /// <param name="assessedGradeLevelDescriptor">The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="version">The version identifier for the test assessment.  NEDM: Assessment Version</param>
        /// <param name="administrationDate">The month(s), day(s), and year on which an assessment is administered or first day of administration if over multiple days.</param>
        /// <param name="administrationEndDate">Assessment Administration End Date, if administered over multiple days.</param>
        /// <param name="serialNumber">The unique number for the assessment form or answer document.</param>
        /// <param name="administrationLanguageDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="administrationEnvironmentType">The environment in which the test was administered.  For example:  Electronic  Classroom  Testing Center  ...  ....</param>
        /// <param name="retestIndicatorType">Indicator if the test was retaken.  For example:  Primary administration  First retest  Second retest  ...</param>
        /// <param name="reasonNotTestedType">The primary reason student is not tested. For example:  Absent  Refusal by parent  Refusal by student  Medical waiver  Illness  Disruptive behavior  LEP Exempt  ...</param>
        /// <param name="whenAssessedGradeLevelDescriptor">The grade level of a student when assessed.</param>
        /// <param name="eventCircumstanceType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="eventDescription">Describes special events that occur before during or after the assessment session that may impact use of results.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StudentAssessment>> GetStudentAssessmentsAll(int? offset= null, int? limit= null, string studentUniqueId= null, string assessmentTitle= null, string academicSubjectDescriptor= null, string assessedGradeLevelDescriptor= null, int? version= null, DateTime? administrationDate= null, DateTime? administrationEndDate= null, string serialNumber= null, string administrationLanguageDescriptor= null, string administrationEnvironmentType= null, string retestIndicatorType= null, string reasonNotTestedType= null, string whenAssessedGradeLevelDescriptor= null, string eventCircumstanceType= null, string eventDescription= null, string id= null) 
        {
            var request = new RestRequest("/studentAssessments", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (assessmentTitle != null)
                request.AddParameter("assessmentTitle", assessmentTitle);
            if (academicSubjectDescriptor != null)
                request.AddParameter("academicSubjectDescriptor", academicSubjectDescriptor);
            if (assessedGradeLevelDescriptor != null)
                request.AddParameter("assessedGradeLevelDescriptor", assessedGradeLevelDescriptor);
            if (version != null)
                request.AddParameter("version", version);
            if (administrationDate != null)
                request.AddParameter("administrationDate", administrationDate);
            if (administrationEndDate != null)
                request.AddParameter("administrationEndDate", administrationEndDate);
            if (serialNumber != null)
                request.AddParameter("serialNumber", serialNumber);
            if (administrationLanguageDescriptor != null)
                request.AddParameter("administrationLanguageDescriptor", administrationLanguageDescriptor);
            if (administrationEnvironmentType != null)
                request.AddParameter("administrationEnvironmentType", administrationEnvironmentType);
            if (retestIndicatorType != null)
                request.AddParameter("retestIndicatorType", retestIndicatorType);
            if (reasonNotTestedType != null)
                request.AddParameter("reasonNotTestedType", reasonNotTestedType);
            if (whenAssessedGradeLevelDescriptor != null)
                request.AddParameter("whenAssessedGradeLevelDescriptor", whenAssessedGradeLevelDescriptor);
            if (eventCircumstanceType != null)
                request.AddParameter("eventCircumstanceType", eventCircumstanceType);
            if (eventDescription != null)
                request.AddParameter("eventDescription", eventDescription);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<StudentAssessment>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the values of the resource's natural key (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get by Key&quot; search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="studentUniqueId">A unique alpha-numeric code assigned to a student.</param>
        /// <param name="assessmentTitle">The title or name of the assessment.  NEDM: Assessment Title</param>
        /// <param name="academicSubjectDescriptor">The description of the content or subject area (e.g., arts, mathematics, reading, stenography, or a foreign language) of an assessment.  NEDM: Assessment Content, Academic Subject</param>
        /// <param name="assessedGradeLevelDescriptor">The typical grade level for which an assessment is designed. If the test assessment spans a range of grades, then this attribute holds the highest grade assessed.  If only one grade level is assessed, then only this attribute is used. For example:  Adult  Prekindergarten  First grade  Second grade  ...</param>
        /// <param name="version">The version identifier for the test assessment.  NEDM: Assessment Version</param>
        /// <param name="administrationDate">The month(s), day(s), and year on which an assessment is administered or first day of administration if over multiple days.</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<StudentAssessment> GetStudentAssessmentByKey(string studentUniqueId, string assessmentTitle, string academicSubjectDescriptor, string assessedGradeLevelDescriptor, int? version, DateTime? administrationDate, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/studentAssessments", Method.GET);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (studentUniqueId == null || assessmentTitle == null || academicSubjectDescriptor == null || assessedGradeLevelDescriptor == null || version == null || administrationDate == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (assessmentTitle != null)
                request.AddParameter("assessmentTitle", assessmentTitle);
            if (academicSubjectDescriptor != null)
                request.AddParameter("academicSubjectDescriptor", academicSubjectDescriptor);
            if (assessedGradeLevelDescriptor != null)
                request.AddParameter("assessedGradeLevelDescriptor", assessedGradeLevelDescriptor);
            if (version != null)
                request.AddParameter("version", version);
            if (administrationDate != null)
                request.AddParameter("administrationDate", administrationDate);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<StudentAssessment>(request);

            return response;
        }
        /// <summary>
        /// Creates or updates resources based on the natural key values of the supplied resource. The POST operation can be used to create or update resources. In database terms, this is often referred to as an &quot;upsert&quot; operation (insert + update).  Clients should NOT include the resource &quot;id&quot; in the JSON body because it will result in an error (you must use a PUT operation to update a resource by &quot;id&quot;). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.
        /// </summary>
        /// <param name="body">The JSON representation of the &quot;studentAssessment&quot; resource to be created or updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PostStudentAssessments(StudentAssessment body) 
        {
            var request = new RestRequest("/studentAssessments", Method.POST);
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
        public IRestResponse<StudentAssessment> GetStudentAssessmentsById(string id, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/studentAssessments/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<StudentAssessment>(request);

            return response;
        }
        /// <summary>
        /// Updates or creates a resource based on the resource identifier. The PUT operation is used to update or create a resource by identifier.  If the resource doesn't exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource &quot;id&quot; is provided in the JSON body, it will be ignored as well.
        /// </summary>
        /// <param name="id">A resource identifier specifying the resource to be updated.</param>
        /// <param name="IfMatch">The ETag header value used to prevent the PUT from updating a resource modified by another consumer.</param>
        /// <param name="body">The JSON representation of the &quot;studentAssessment&quot; resource to be updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PutStudentAssessment(string id, string IfMatch, StudentAssessment body) 
        {
            var request = new RestRequest("/studentAssessments/{id}", Method.PUT);
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
        public IRestResponse DeleteStudentAssessmentById(string id, string IfMatch= null) 
        {
            var request = new RestRequest("/studentAssessments/{id}", Method.DELETE);
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

