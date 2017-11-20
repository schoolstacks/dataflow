using System;
using System.Collections.Generic;
using System.Linq;
using DataFlow.EdFi.Models.Resources;
using RestSharp;

namespace DataFlow.EdFi.Api.Resources 
{
    public class StaffsApi 
    {
        private readonly IRestClient client;

        public StaffsApi(IRestClient client)
        {
            this.client = client;
        }
      
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Staff>> GetStaffsAll(int? offset= null, int? limit= null) 
        {
            var request = new RestRequest("/staffs", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            var response = client.Execute<List<Staff>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources matching values of an example resource (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get by Example&quot; search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="staffUniqueId">A unique alpha-numeric code assigned to a staff.</param>
        /// <param name="personalTitlePrefix">A prefix used to denote the title, degree, position, or seniority of the person.</param>
        /// <param name="firstName">A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.</param>
        /// <param name="middleName">A secondary name given to an individual at birth, baptism, or during another naming ceremony.</param>
        /// <param name="lastSurname">The name borne in common by members of a family.</param>
        /// <param name="generationCodeSuffix">An appendage, if any, used to denote an individual's generation in his family (e.g., Jr., Sr., III).</param>
        /// <param name="maidenName">The person's maiden name.</param>
        /// <param name="sexType">A person''s gender.</param>
        /// <param name="birthDate">The month, day, and year on which an individual was born.</param>
        /// <param name="hispanicLatinoEthnicity">An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, &quot;Spanish origin,&quot; can be used in addition to &quot;Hispanic or Latino.&quot;</param>
        /// <param name="oldEthnicityType">Previous definition of Ethnicity combining Hispanic/latino and race:  1 - American Indian or Alaskan Native  2 - Asian or Pacific Islander  3 - Black, not of Hispanic origin  4 - Hispanic  5 - White, not of Hispanic origin</param>
        /// <param name="highestCompletedLevelOfEducationDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="yearsOfPriorProfessionalExperience">The total number of years that an individual has previously held a similar professional position in one or more education institutions.</param>
        /// <param name="yearsOfPriorTeachingExperience">The total number of years that an individual has previously held a teaching position in one or more education institutions.</param>
        /// <param name="highlyQualifiedTeacher">An indication of whether a teacher is classified as highly qualified for his/her assignment according to state definition. This attribute indicates the teacher is highly qualified for ALL Sections being taught.</param>
        /// <param name="loginId">The login ID for the user; used for security access control interface.</param>
        /// <param name="citizenshipStatusType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Staff>> GetStaffsAll(int? offset= null, int? limit= null, string staffUniqueId= null, string personalTitlePrefix= null, string firstName= null, string middleName= null, string lastSurname= null, string generationCodeSuffix= null, string maidenName= null, string sexType= null, DateTime? birthDate= null, bool? hispanicLatinoEthnicity= null, string oldEthnicityType= null, string highestCompletedLevelOfEducationDescriptor= null, double? yearsOfPriorProfessionalExperience= null, double? yearsOfPriorTeachingExperience= null, bool? highlyQualifiedTeacher= null, string loginId= null, string citizenshipStatusType= null, string id= null) 
        {
            var request = new RestRequest("/staffs", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (staffUniqueId != null)
                request.AddParameter("staffUniqueId", staffUniqueId);
            if (personalTitlePrefix != null)
                request.AddParameter("personalTitlePrefix", personalTitlePrefix);
            if (firstName != null)
                request.AddParameter("firstName", firstName);
            if (middleName != null)
                request.AddParameter("middleName", middleName);
            if (lastSurname != null)
                request.AddParameter("lastSurname", lastSurname);
            if (generationCodeSuffix != null)
                request.AddParameter("generationCodeSuffix", generationCodeSuffix);
            if (maidenName != null)
                request.AddParameter("maidenName", maidenName);
            if (sexType != null)
                request.AddParameter("sexType", sexType);
            if (birthDate != null)
                request.AddParameter("birthDate", birthDate);
            if (hispanicLatinoEthnicity != null)
                request.AddParameter("hispanicLatinoEthnicity", hispanicLatinoEthnicity);
            if (oldEthnicityType != null)
                request.AddParameter("oldEthnicityType", oldEthnicityType);
            if (highestCompletedLevelOfEducationDescriptor != null)
                request.AddParameter("highestCompletedLevelOfEducationDescriptor", highestCompletedLevelOfEducationDescriptor);
            if (yearsOfPriorProfessionalExperience != null)
                request.AddParameter("yearsOfPriorProfessionalExperience", yearsOfPriorProfessionalExperience);
            if (yearsOfPriorTeachingExperience != null)
                request.AddParameter("yearsOfPriorTeachingExperience", yearsOfPriorTeachingExperience);
            if (highlyQualifiedTeacher != null)
                request.AddParameter("highlyQualifiedTeacher", highlyQualifiedTeacher);
            if (loginId != null)
                request.AddParameter("loginId", loginId);
            if (citizenshipStatusType != null)
                request.AddParameter("citizenshipStatusType", citizenshipStatusType);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Staff>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the values of the resource's natural key (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get by Key&quot; search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="staffUniqueId">A unique alpha-numeric code assigned to a staff.</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<Staff> GetStaffByKey(string staffUniqueId, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/staffs", Method.GET);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (staffUniqueId == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (staffUniqueId != null)
                request.AddParameter("staffUniqueId", staffUniqueId);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<Staff>(request);

            return response;
        }
        /// <summary>
        /// Creates or updates resources based on the natural key values of the supplied resource. The POST operation can be used to create or update resources. In database terms, this is often referred to as an &quot;upsert&quot; operation (insert + update).  Clients should NOT include the resource &quot;id&quot; in the JSON body because it will result in an error (you must use a PUT operation to update a resource by &quot;id&quot;). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.
        /// </summary>
        /// <param name="body">The JSON representation of the &quot;staff&quot; resource to be created or updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PostStaffs(Staff body) 
        {
            var request = new RestRequest("/staffs", Method.POST);
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
        public IRestResponse<Staff> GetStaffsById(string id, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/staffs/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<Staff>(request);

            return response;
        }
        /// <summary>
        /// Updates or creates a resource based on the resource identifier. The PUT operation is used to update or create a resource by identifier.  If the resource doesn't exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource &quot;id&quot; is provided in the JSON body, it will be ignored as well.
        /// </summary>
        /// <param name="id">A resource identifier specifying the resource to be updated.</param>
        /// <param name="IfMatch">The ETag header value used to prevent the PUT from updating a resource modified by another consumer.</param>
        /// <param name="body">The JSON representation of the &quot;staff&quot; resource to be updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PutStaff(string id, string IfMatch, Staff body) 
        {
            var request = new RestRequest("/staffs/{id}", Method.PUT);
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
        public IRestResponse DeleteStaffById(string id, string IfMatch= null) 
        {
            var request = new RestRequest("/staffs/{id}", Method.DELETE);
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

