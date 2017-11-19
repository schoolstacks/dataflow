using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.OdsApi.Sdk;
using EdFi.OdsApi.Models.Resources;
using RestSharp;
  
namespace EdFi.OdsApi.Api.Resources 
{
    public class StudentSchoolAssociationsApi 
    {
        private readonly IRestClient client;

        public StudentSchoolAssociationsApi(IRestClient client)
        {
            this.client = client;
        }
      
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StudentSchoolAssociation>> GetStudentSchoolAssociationsAll(int? offset= null, int? limit= null) 
        {
            var request = new RestRequest("/studentSchoolAssociations", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            var response = client.Execute<List<StudentSchoolAssociation>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources matching values of an example resource (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get by Example&quot; search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="studentUniqueId">A unique alpha-numeric code assigned to a student.</param>
        /// <param name="schoolId">School Identity Column</param>
        /// <param name="entryDate">The month, day, and year on which an individual enters and begins to receive instructional services in a school.</param>
        /// <param name="schoolYear">Identifier for a school year.</param>
        /// <param name="entryGradeLevelDescriptor">The grade level or primary instructional level at which a student enters and receives services in a school or an educational institution during a given academic session.</param>
        /// <param name="entryGradeLevelReasonType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="entryTypeDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="repeatGradeIndicator">An indicator of whether the student is enrolling to repeat a grade level, either by failure or an agreement to hold the student back.</param>
        /// <param name="schoolChoiceTransfer">An indication of whether students transferred in or out of the school did so during the school year under the provisions for public school choice in accordance with Title I, Part A, Section 1116.</param>
        /// <param name="exitWithdrawDate">The month, day, and year of the first day after the date of an individual's last attendance at a school (if known), the day on which an individual graduated, or the date on which it becomes known officially that an individual left school.</param>
        /// <param name="exitWithdrawTypeDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="residencyStatusDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="primarySchool">Indicates if a given enrollment record should be considered the primary record for a student. If omitted, the default is true.</param>
        /// <param name="employedWhileEnrolled">An individual who is a paid employee or works in his or her own business, profession, or farm and at the same time is enrolled in secondary, postsecondary, or adult education.</param>
        /// <param name="classOfSchoolYear">Projected High School graduation year</param>
        /// <param name="educationOrganizationId">EducationOrganization Identity Column</param>
        /// <param name="graduationPlanTypeDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="graduationSchoolYear">The identifier for the school year.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StudentSchoolAssociation>> GetStudentSchoolAssociationsAll(int? offset= null, int? limit= null, string studentUniqueId= null, int? schoolId= null, DateTime? entryDate= null, int? schoolYear= null, string entryGradeLevelDescriptor= null, string entryGradeLevelReasonType= null, string entryTypeDescriptor= null, bool? repeatGradeIndicator= null, bool? schoolChoiceTransfer= null, DateTime? exitWithdrawDate= null, string exitWithdrawTypeDescriptor= null, string residencyStatusDescriptor= null, bool? primarySchool= null, bool? employedWhileEnrolled= null, int? classOfSchoolYear= null, int? educationOrganizationId= null, string graduationPlanTypeDescriptor= null, int? graduationSchoolYear= null, string id= null) 
        {
            var request = new RestRequest("/studentSchoolAssociations", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (entryDate != null)
                request.AddParameter("entryDate", entryDate);
            if (schoolYear != null)
                request.AddParameter("schoolYear", schoolYear);
            if (entryGradeLevelDescriptor != null)
                request.AddParameter("entryGradeLevelDescriptor", entryGradeLevelDescriptor);
            if (entryGradeLevelReasonType != null)
                request.AddParameter("entryGradeLevelReasonType", entryGradeLevelReasonType);
            if (entryTypeDescriptor != null)
                request.AddParameter("entryTypeDescriptor", entryTypeDescriptor);
            if (repeatGradeIndicator != null)
                request.AddParameter("repeatGradeIndicator", repeatGradeIndicator);
            if (schoolChoiceTransfer != null)
                request.AddParameter("schoolChoiceTransfer", schoolChoiceTransfer);
            if (exitWithdrawDate != null)
                request.AddParameter("exitWithdrawDate", exitWithdrawDate);
            if (exitWithdrawTypeDescriptor != null)
                request.AddParameter("exitWithdrawTypeDescriptor", exitWithdrawTypeDescriptor);
            if (residencyStatusDescriptor != null)
                request.AddParameter("residencyStatusDescriptor", residencyStatusDescriptor);
            if (primarySchool != null)
                request.AddParameter("primarySchool", primarySchool);
            if (employedWhileEnrolled != null)
                request.AddParameter("employedWhileEnrolled", employedWhileEnrolled);
            if (classOfSchoolYear != null)
                request.AddParameter("classOfSchoolYear", classOfSchoolYear);
            if (educationOrganizationId != null)
                request.AddParameter("educationOrganizationId", educationOrganizationId);
            if (graduationPlanTypeDescriptor != null)
                request.AddParameter("graduationPlanTypeDescriptor", graduationPlanTypeDescriptor);
            if (graduationSchoolYear != null)
                request.AddParameter("graduationSchoolYear", graduationSchoolYear);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<StudentSchoolAssociation>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the values of the resource's natural key (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get by Key&quot; search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="studentUniqueId">A unique alpha-numeric code assigned to a student.</param>
        /// <param name="schoolId">School Identity Column</param>
        /// <param name="entryDate">The month, day, and year on which an individual enters and begins to receive instructional services in a school.</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<StudentSchoolAssociation> GetStudentSchoolAssociationByKey(string studentUniqueId, int? schoolId, DateTime? entryDate, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/studentSchoolAssociations", Method.GET);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (studentUniqueId == null || schoolId == null || entryDate == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (entryDate != null)
                request.AddParameter("entryDate", entryDate);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<StudentSchoolAssociation>(request);

            return response;
        }
        /// <summary>
        /// Creates or updates resources based on the natural key values of the supplied resource. The POST operation can be used to create or update resources. In database terms, this is often referred to as an &quot;upsert&quot; operation (insert + update).  Clients should NOT include the resource &quot;id&quot; in the JSON body because it will result in an error (you must use a PUT operation to update a resource by &quot;id&quot;). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.
        /// </summary>
        /// <param name="body">The JSON representation of the &quot;studentSchoolAssociation&quot; resource to be created or updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PostStudentSchoolAssociations(StudentSchoolAssociation body) 
        {
            var request = new RestRequest("/studentSchoolAssociations", Method.POST);
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
        public IRestResponse<StudentSchoolAssociation> GetStudentSchoolAssociationsById(string id, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/studentSchoolAssociations/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<StudentSchoolAssociation>(request);

            return response;
        }
        /// <summary>
        /// Updates or creates a resource based on the resource identifier. The PUT operation is used to update or create a resource by identifier.  If the resource doesn't exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource &quot;id&quot; is provided in the JSON body, it will be ignored as well.
        /// </summary>
        /// <param name="id">A resource identifier specifying the resource to be updated.</param>
        /// <param name="IfMatch">The ETag header value used to prevent the PUT from updating a resource modified by another consumer.</param>
        /// <param name="body">The JSON representation of the &quot;studentSchoolAssociation&quot; resource to be updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PutStudentSchoolAssociation(string id, string IfMatch, StudentSchoolAssociation body) 
        {
            var request = new RestRequest("/studentSchoolAssociations/{id}", Method.PUT);
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
        public IRestResponse DeleteStudentSchoolAssociationById(string id, string IfMatch= null) 
        {
            var request = new RestRequest("/studentSchoolAssociations/{id}", Method.DELETE);
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

