using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.OdsApi.Sdk;
using EdFi.OdsApi.Models.Resources;
using RestSharp;
  
namespace EdFi.OdsApi.Api.Resources 
{
    public class StudentAcademicRecordsApi 
    {
        private readonly IRestClient client;

        public StudentAcademicRecordsApi(IRestClient client)
        {
            this.client = client;
        }
      
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StudentAcademicRecord>> GetStudentAcademicRecordsAll(int? offset= null, int? limit= null) 
        {
            var request = new RestRequest("/studentAcademicRecords", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            var response = client.Execute<List<StudentAcademicRecord>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources matching values of an example resource (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get by Example&quot; search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="studentUniqueId">A unique alpha-numeric code assigned to a student.</param>
        /// <param name="educationOrganizationId">EducationOrganization Identity Column</param>
        /// <param name="schoolYear">The identifier for the school year.</param>
        /// <param name="termDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="cumulativeEarnedCreditType">Key for Credit</param>
        /// <param name="cumulativeEarnedCreditConversion">Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.</param>
        /// <param name="cumulativeEarnedCredits">The cumulative number of credits an individual earns by completing courses or examinations during his or her enrollment in the current school as well as those credits transferred from schools in which the individual had been previously enrolled.</param>
        /// <param name="cumulativeAttemptedCreditType">Key for Credit</param>
        /// <param name="cumulativeAttemptedCreditConversion">Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.</param>
        /// <param name="cumulativeAttemptedCredits">The cumulative number of credits an individual attempts to earn by taking courses during his or her enrollment in the current school as well as those credits transferred from schools in which the individual had been previously enrolled.</param>
        /// <param name="cumulativeGradePointsEarned">The cumulative number of grade points an individual earns by successfully completing courses or examinations during his or her enrollment in the current school as well as those transferred from schools in which the individual had been previously enrolled.</param>
        /// <param name="cumulativeGradePointAverage">A measure of average performance in all courses taken by an individual during his or her school career as determined for record-keeping purposes. This is obtained by dividing the total grade points received by the total number of credits attempted. This usually includes grade points received and credits attempted in his or her current school as well as those transferred from schools in which the individual was previously enrolled.</param>
        /// <param name="gradeValueQualifier">The scale of equivalents, if applicable, for grades awarded as indicators of performance in schoolwork. For example, numerical equivalents for letter grades used in determining a student's Grade Point Average (A=4, B=3, C=2, D=1 in a four-point system) or letter equivalents for percentage grades (90-100%=A, 80-90%=B, etc.).</param>
        /// <param name="projectedGraduationDate">The month and year the student is projected to graduate.</param>
        /// <param name="sessionEarnedCreditType">Key for Credit</param>
        /// <param name="sessionEarnedCreditConversion">Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.</param>
        /// <param name="sessionEarnedCredits">The number of an credits an individual earned in this session.</param>
        /// <param name="sessionAttemptedCreditType">Key for Credit</param>
        /// <param name="sessionAttemptedCreditConversion">Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.</param>
        /// <param name="sessionAttemptedCredits">The number of an credits an individual attempted to earn in this session.</param>
        /// <param name="sessionGradePointsEarned">The number of grade points an individual earned for this session.</param>
        /// <param name="sessionGradePointAverage">The grade point average for an individual computed as the grade points earned during the session divided by the number of credits attempted.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StudentAcademicRecord>> GetStudentAcademicRecordsAll(int? offset= null, int? limit= null, string studentUniqueId= null, int? educationOrganizationId= null, int? schoolYear= null, string termDescriptor= null, string cumulativeEarnedCreditType= null, double? cumulativeEarnedCreditConversion= null, double? cumulativeEarnedCredits= null, string cumulativeAttemptedCreditType= null, double? cumulativeAttemptedCreditConversion= null, double? cumulativeAttemptedCredits= null, double? cumulativeGradePointsEarned= null, double? cumulativeGradePointAverage= null, string gradeValueQualifier= null, DateTime? projectedGraduationDate= null, string sessionEarnedCreditType= null, double? sessionEarnedCreditConversion= null, double? sessionEarnedCredits= null, string sessionAttemptedCreditType= null, double? sessionAttemptedCreditConversion= null, double? sessionAttemptedCredits= null, double? sessionGradePointsEarned= null, double? sessionGradePointAverage= null, string id= null) 
        {
            var request = new RestRequest("/studentAcademicRecords", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (educationOrganizationId != null)
                request.AddParameter("educationOrganizationId", educationOrganizationId);
            if (schoolYear != null)
                request.AddParameter("schoolYear", schoolYear);
            if (termDescriptor != null)
                request.AddParameter("termDescriptor", termDescriptor);
            if (cumulativeEarnedCreditType != null)
                request.AddParameter("cumulativeEarnedCreditType", cumulativeEarnedCreditType);
            if (cumulativeEarnedCreditConversion != null)
                request.AddParameter("cumulativeEarnedCreditConversion", cumulativeEarnedCreditConversion);
            if (cumulativeEarnedCredits != null)
                request.AddParameter("cumulativeEarnedCredits", cumulativeEarnedCredits);
            if (cumulativeAttemptedCreditType != null)
                request.AddParameter("cumulativeAttemptedCreditType", cumulativeAttemptedCreditType);
            if (cumulativeAttemptedCreditConversion != null)
                request.AddParameter("cumulativeAttemptedCreditConversion", cumulativeAttemptedCreditConversion);
            if (cumulativeAttemptedCredits != null)
                request.AddParameter("cumulativeAttemptedCredits", cumulativeAttemptedCredits);
            if (cumulativeGradePointsEarned != null)
                request.AddParameter("cumulativeGradePointsEarned", cumulativeGradePointsEarned);
            if (cumulativeGradePointAverage != null)
                request.AddParameter("cumulativeGradePointAverage", cumulativeGradePointAverage);
            if (gradeValueQualifier != null)
                request.AddParameter("gradeValueQualifier", gradeValueQualifier);
            if (projectedGraduationDate != null)
                request.AddParameter("projectedGraduationDate", projectedGraduationDate);
            if (sessionEarnedCreditType != null)
                request.AddParameter("sessionEarnedCreditType", sessionEarnedCreditType);
            if (sessionEarnedCreditConversion != null)
                request.AddParameter("sessionEarnedCreditConversion", sessionEarnedCreditConversion);
            if (sessionEarnedCredits != null)
                request.AddParameter("sessionEarnedCredits", sessionEarnedCredits);
            if (sessionAttemptedCreditType != null)
                request.AddParameter("sessionAttemptedCreditType", sessionAttemptedCreditType);
            if (sessionAttemptedCreditConversion != null)
                request.AddParameter("sessionAttemptedCreditConversion", sessionAttemptedCreditConversion);
            if (sessionAttemptedCredits != null)
                request.AddParameter("sessionAttemptedCredits", sessionAttemptedCredits);
            if (sessionGradePointsEarned != null)
                request.AddParameter("sessionGradePointsEarned", sessionGradePointsEarned);
            if (sessionGradePointAverage != null)
                request.AddParameter("sessionGradePointAverage", sessionGradePointAverage);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<StudentAcademicRecord>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the values of the resource's natural key (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get by Key&quot; search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="studentUniqueId">A unique alpha-numeric code assigned to a student.</param>
        /// <param name="educationOrganizationId">EducationOrganization Identity Column</param>
        /// <param name="schoolYear">The identifier for the school year.</param>
        /// <param name="termDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<StudentAcademicRecord> GetStudentAcademicRecordByKey(string studentUniqueId, int? educationOrganizationId, int? schoolYear, string termDescriptor, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/studentAcademicRecords", Method.GET);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (studentUniqueId == null || educationOrganizationId == null || schoolYear == null || termDescriptor == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (educationOrganizationId != null)
                request.AddParameter("educationOrganizationId", educationOrganizationId);
            if (schoolYear != null)
                request.AddParameter("schoolYear", schoolYear);
            if (termDescriptor != null)
                request.AddParameter("termDescriptor", termDescriptor);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<StudentAcademicRecord>(request);

            return response;
        }
        /// <summary>
        /// Creates or updates resources based on the natural key values of the supplied resource. The POST operation can be used to create or update resources. In database terms, this is often referred to as an &quot;upsert&quot; operation (insert + update).  Clients should NOT include the resource &quot;id&quot; in the JSON body because it will result in an error (you must use a PUT operation to update a resource by &quot;id&quot;). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.
        /// </summary>
        /// <param name="body">The JSON representation of the &quot;studentAcademicRecord&quot; resource to be created or updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PostStudentAcademicRecords(StudentAcademicRecord body) 
        {
            var request = new RestRequest("/studentAcademicRecords", Method.POST);
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
        public IRestResponse<StudentAcademicRecord> GetStudentAcademicRecordsById(string id, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/studentAcademicRecords/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<StudentAcademicRecord>(request);

            return response;
        }
        /// <summary>
        /// Updates or creates a resource based on the resource identifier. The PUT operation is used to update or create a resource by identifier.  If the resource doesn't exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource &quot;id&quot; is provided in the JSON body, it will be ignored as well.
        /// </summary>
        /// <param name="id">A resource identifier specifying the resource to be updated.</param>
        /// <param name="IfMatch">The ETag header value used to prevent the PUT from updating a resource modified by another consumer.</param>
        /// <param name="body">The JSON representation of the &quot;studentAcademicRecord&quot; resource to be updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PutStudentAcademicRecord(string id, string IfMatch, StudentAcademicRecord body) 
        {
            var request = new RestRequest("/studentAcademicRecords/{id}", Method.PUT);
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
        public IRestResponse DeleteStudentAcademicRecordById(string id, string IfMatch= null) 
        {
            var request = new RestRequest("/studentAcademicRecords/{id}", Method.DELETE);
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

