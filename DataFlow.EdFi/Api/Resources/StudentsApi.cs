using System;
using System.Collections.Generic;
using System.Linq;
using DataFlow.EdFi.Models.Resources;
using RestSharp;

namespace DataFlow.EdFi.Api.Resources 
{
    public class StudentsApi 
    {
        private readonly IRestClient client;

        public StudentsApi(IRestClient client)
        {
            this.client = client;
        }
      
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Student>> GetStudentsAll(int? offset= null, int? limit= null) 
        {
            var request = new RestRequest("/students", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            var response = client.Execute<List<Student>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources matching values of an example resource (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get by Example&quot; search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="studentUniqueId">A unique alpha-numeric code assigned to a student.</param>
        /// <param name="personalTitlePrefix">A prefix used to denote the title, degree, position, or seniority of the person.</param>
        /// <param name="firstName">A name given to an individual at birth, baptism, or during another naming ceremony, or through legal change.</param>
        /// <param name="middleName">A secondary name given to an individual at birth, baptism, or during another naming ceremony.</param>
        /// <param name="lastSurname">The name borne in common by members of a family.</param>
        /// <param name="generationCodeSuffix">An appendage, if any, used to denote an individual's generation in his family (e.g., Jr., Sr., III).</param>
        /// <param name="maidenName">The person's maiden name.</param>
        /// <param name="sexType">A person''s gender.</param>
        /// <param name="birthDate">The month, day, and year on which an individual was born.</param>
        /// <param name="birthCity">The set of elements that capture relevant data regarding a person's birth, including birth date and place of birth.</param>
        /// <param name="birthStateAbbreviationType">The abbreviation for the name of the state (within the United States) or extra-state jurisdiction in which an individual was born.</param>
        /// <param name="dateEnteredUS">For students born outside of the U.S., the date the student entered the U.S.</param>
        /// <param name="multipleBirthStatus">Indicator of whether the student was born with other siblings (i.e., twins, triplets, etc.)</param>
        /// <param name="profileThumbnail">ProfileThumbnail.</param>
        /// <param name="hispanicLatinoEthnicity">An indication that the individual traces his or her origin or descent to Mexico, Puerto Rico, Cuba, Central, and South America, and other Spanish cultures, regardless of race. The term, &quot;Spanish origin,&quot; can be used in addition to &quot;Hispanic or Latino.&quot;</param>
        /// <param name="oldEthnicityType">Previous definition of Ethnicity combining Hispanic/latino and race:  1 - American Indian or Alaskan Native  2 - Asian or Pacific Islander  3 - Black, not of Hispanic origin  4 - Hispanic  5 - White, not of Hispanic origin</param>
        /// <param name="economicDisadvantaged">An indication of inadequate financial condition of an individual's family, as determined by family income, number of family members/dependents, participation in public assistance programs, and/or other characteristics considered relevant by federal, state, and local policy.</param>
        /// <param name="schoolFoodServicesEligibilityDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="limitedEnglishProficiencyDescriptor">An indication that the student has sufficient difficulty speaking, reading, writing, or understanding the English language, as to require special English Language services.</param>
        /// <param name="displacementStatus">Indicates a state health or weather related event that displaces a group of students, and may require additional funding, educational, or social services.</param>
        /// <param name="loginId">The login ID for the user; used for security access control interface.</param>
        /// <param name="birthInternationalProvince">For students born outside of the US, the Province or jurisdiction in which an individual is born.</param>
        /// <param name="citizenshipStatusType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="id"></param>
        /// <param name="birthCountryDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Student>> GetStudentsAll(int? offset= null, int? limit= null, string studentUniqueId= null, string personalTitlePrefix= null, string firstName= null, string middleName= null, string lastSurname= null, string generationCodeSuffix= null, string maidenName= null, string sexType= null, DateTime? birthDate= null, string birthCity= null, string birthStateAbbreviationType= null, DateTime? dateEnteredUS= null, bool? multipleBirthStatus= null, string profileThumbnail= null, bool? hispanicLatinoEthnicity= null, string oldEthnicityType= null, bool? economicDisadvantaged= null, string schoolFoodServicesEligibilityDescriptor= null, string limitedEnglishProficiencyDescriptor= null, string displacementStatus= null, string loginId= null, string birthInternationalProvince= null, string citizenshipStatusType= null, string id= null, string birthCountryDescriptor= null) 
        {
            var request = new RestRequest("/students", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
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
            if (birthCity != null)
                request.AddParameter("birthCity", birthCity);
            if (birthStateAbbreviationType != null)
                request.AddParameter("birthStateAbbreviationType", birthStateAbbreviationType);
            if (dateEnteredUS != null)
                request.AddParameter("dateEnteredUS", dateEnteredUS);
            if (multipleBirthStatus != null)
                request.AddParameter("multipleBirthStatus", multipleBirthStatus);
            if (profileThumbnail != null)
                request.AddParameter("profileThumbnail", profileThumbnail);
            if (hispanicLatinoEthnicity != null)
                request.AddParameter("hispanicLatinoEthnicity", hispanicLatinoEthnicity);
            if (oldEthnicityType != null)
                request.AddParameter("oldEthnicityType", oldEthnicityType);
            if (economicDisadvantaged != null)
                request.AddParameter("economicDisadvantaged", economicDisadvantaged);
            if (schoolFoodServicesEligibilityDescriptor != null)
                request.AddParameter("schoolFoodServicesEligibilityDescriptor", schoolFoodServicesEligibilityDescriptor);
            if (limitedEnglishProficiencyDescriptor != null)
                request.AddParameter("limitedEnglishProficiencyDescriptor", limitedEnglishProficiencyDescriptor);
            if (displacementStatus != null)
                request.AddParameter("displacementStatus", displacementStatus);
            if (loginId != null)
                request.AddParameter("loginId", loginId);
            if (birthInternationalProvince != null)
                request.AddParameter("birthInternationalProvince", birthInternationalProvince);
            if (citizenshipStatusType != null)
                request.AddParameter("citizenshipStatusType", citizenshipStatusType);
            if (id != null)
                request.AddParameter("id", id);
            if (birthCountryDescriptor != null)
                request.AddParameter("birthCountryDescriptor", birthCountryDescriptor);
            var response = client.Execute<List<Student>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the values of the resource's natural key (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get by Key&quot; search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="studentUniqueId">A unique alpha-numeric code assigned to a student.</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<Student> GetStudentByKey(string studentUniqueId, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/students", Method.GET);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (studentUniqueId == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<Student>(request);

            return response;
        }
        /// <summary>
        /// Creates or updates resources based on the natural key values of the supplied resource. The POST operation can be used to create or update resources. In database terms, this is often referred to as an &quot;upsert&quot; operation (insert + update).  Clients should NOT include the resource &quot;id&quot; in the JSON body because it will result in an error (you must use a PUT operation to update a resource by &quot;id&quot;). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.
        /// </summary>
        /// <param name="body">The JSON representation of the &quot;student&quot; resource to be created or updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PostStudents(Student body) 
        {
            var request = new RestRequest("/students", Method.POST);
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
        public IRestResponse<Student> GetStudentsById(string id, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/students/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<Student>(request);

            return response;
        }
        /// <summary>
        /// Updates or creates a resource based on the resource identifier. The PUT operation is used to update or create a resource by identifier.  If the resource doesn't exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource &quot;id&quot; is provided in the JSON body, it will be ignored as well.
        /// </summary>
        /// <param name="id">A resource identifier specifying the resource to be updated.</param>
        /// <param name="IfMatch">The ETag header value used to prevent the PUT from updating a resource modified by another consumer.</param>
        /// <param name="body">The JSON representation of the &quot;student&quot; resource to be updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PutStudent(string id, string IfMatch, Student body) 
        {
            var request = new RestRequest("/students/{id}", Method.PUT);
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
        public IRestResponse DeleteStudentById(string id, string IfMatch= null) 
        {
            var request = new RestRequest("/students/{id}", Method.DELETE);
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

