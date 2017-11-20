using System;
using System.Collections.Generic;
using System.Linq;
using DataFlow.EdFi.Models.Resources;
using RestSharp;

namespace DataFlow.EdFi.Api.Resources 
{
    public class CoursesApi 
    {
        private readonly IRestClient client;

        public CoursesApi(IRestClient client)
        {
            this.client = client;
        }
      
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Course>> GetCoursesAll(int? offset= null, int? limit= null) 
        {
            var request = new RestRequest("/courses", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            var response = client.Execute<List<Course>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources matching values of an example resource (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get by Example&quot; search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="educationOrganizationId">The Education Organization that defines the curriculum and courses offered - often the LEA or school.</param>
        /// <param name="code">TThe actual code that identifies the organization of subject matter and related learning experiences provided for the instruction of students.</param>
        /// <param name="title">The descriptive name given to a course of study offered in a school or other institution or organization. In departmentalized classes at the elementary, secondary, and postsecondary levels (and for staff development activities), this refers to the name by which a course is identified (e.g., American History, English III). For elementary and other non-departmentalized classes, it refers to any portion of the instruction for which a grade or report is assigned (e.g., reading, composition, spelling, and language arts).</param>
        /// <param name="numberOfParts">The number of parts identified for a course.</param>
        /// <param name="academicSubjectDescriptor">The intended major subject area of the course.  NEDM: Secondary Course Subject Area</param>
        /// <param name="description">A description of the content standards and goals covered in the course. Reference may be made to state or national content standards.  NEDM: Course Description</param>
        /// <param name="dateCourseAdopted">Date the course was adopted by the education agency.</param>
        /// <param name="highSchoolCourseRequirement">An indication that this course may satisfy high school graduation requirements in the course's subject area.</param>
        /// <param name="gpaApplicabilityType">An indicator of whether or not this course being described is included in the computation of the student's Grade Point Average, and if so, if it weighted differently from regular courses.</param>
        /// <param name="definedByType">Key for CourseDefinedByType.</param>
        /// <param name="minimumAvailableCreditType">Key for Credit</param>
        /// <param name="minimumAvailableCreditConversion">Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.</param>
        /// <param name="minimumAvailableCredits">The minimum amount of credit available to a student who successfully completes the course</param>
        /// <param name="maximumAvailableCreditType">Key for Credit</param>
        /// <param name="maximumAvailableCreditConversion">Conversion factor that when multiplied by the number of credits is equivalent to Carnegie units.</param>
        /// <param name="maximumAvailableCredits">The maximum amount of credit available to a student who successfully completes the course</param>
        /// <param name="careerPathwayType">Key for CareerPathway</param>
        /// <param name="timeRequiredForCompletion">The actual or estimated number of clock minutes required for class completion. This number is especially important for career and technical education classes and may represent (in minutes) the clock hour requirement of the class.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<Course>> GetCoursesAll(int? offset= null, int? limit= null, int? educationOrganizationId= null, string code= null, string title= null, int? numberOfParts= null, string academicSubjectDescriptor= null, string description= null, DateTime? dateCourseAdopted= null, bool? highSchoolCourseRequirement= null, string gpaApplicabilityType= null, string definedByType= null, string minimumAvailableCreditType= null, double? minimumAvailableCreditConversion= null, double? minimumAvailableCredits= null, string maximumAvailableCreditType= null, double? maximumAvailableCreditConversion= null, double? maximumAvailableCredits= null, string careerPathwayType= null, int? timeRequiredForCompletion= null, string id= null) 
        {
            var request = new RestRequest("/courses", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (educationOrganizationId != null)
                request.AddParameter("educationOrganizationId", educationOrganizationId);
            if (code != null)
                request.AddParameter("code", code);
            if (title != null)
                request.AddParameter("title", title);
            if (numberOfParts != null)
                request.AddParameter("numberOfParts", numberOfParts);
            if (academicSubjectDescriptor != null)
                request.AddParameter("academicSubjectDescriptor", academicSubjectDescriptor);
            if (description != null)
                request.AddParameter("description", description);
            if (dateCourseAdopted != null)
                request.AddParameter("dateCourseAdopted", dateCourseAdopted);
            if (highSchoolCourseRequirement != null)
                request.AddParameter("highSchoolCourseRequirement", highSchoolCourseRequirement);
            if (gpaApplicabilityType != null)
                request.AddParameter("gpaApplicabilityType", gpaApplicabilityType);
            if (definedByType != null)
                request.AddParameter("definedByType", definedByType);
            if (minimumAvailableCreditType != null)
                request.AddParameter("minimumAvailableCreditType", minimumAvailableCreditType);
            if (minimumAvailableCreditConversion != null)
                request.AddParameter("minimumAvailableCreditConversion", minimumAvailableCreditConversion);
            if (minimumAvailableCredits != null)
                request.AddParameter("minimumAvailableCredits", minimumAvailableCredits);
            if (maximumAvailableCreditType != null)
                request.AddParameter("maximumAvailableCreditType", maximumAvailableCreditType);
            if (maximumAvailableCreditConversion != null)
                request.AddParameter("maximumAvailableCreditConversion", maximumAvailableCreditConversion);
            if (maximumAvailableCredits != null)
                request.AddParameter("maximumAvailableCredits", maximumAvailableCredits);
            if (careerPathwayType != null)
                request.AddParameter("careerPathwayType", careerPathwayType);
            if (timeRequiredForCompletion != null)
                request.AddParameter("timeRequiredForCompletion", timeRequiredForCompletion);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<Course>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the values of the resource's natural key (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get by Key&quot; search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="educationOrganizationId">The Education Organization that defines the curriculum and courses offered - often the LEA or school.</param>
        /// <param name="code">TThe actual code that identifies the organization of subject matter and related learning experiences provided for the instruction of students.</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<Course> GetCourseByKey(int? educationOrganizationId, string code, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/courses", Method.GET);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (educationOrganizationId == null || code == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (educationOrganizationId != null)
                request.AddParameter("educationOrganizationId", educationOrganizationId);
            if (code != null)
                request.AddParameter("code", code);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<Course>(request);

            return response;
        }
        /// <summary>
        /// Creates or updates resources based on the natural key values of the supplied resource. The POST operation can be used to create or update resources. In database terms, this is often referred to as an &quot;upsert&quot; operation (insert + update).  Clients should NOT include the resource &quot;id&quot; in the JSON body because it will result in an error (you must use a PUT operation to update a resource by &quot;id&quot;). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.
        /// </summary>
        /// <param name="body">The JSON representation of the &quot;course&quot; resource to be created or updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PostCourses(Course body) 
        {
            var request = new RestRequest("/courses", Method.POST);
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
        public IRestResponse<Course> GetCoursesById(string id, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/courses/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<Course>(request);

            return response;
        }
        /// <summary>
        /// Updates or creates a resource based on the resource identifier. The PUT operation is used to update or create a resource by identifier.  If the resource doesn't exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource &quot;id&quot; is provided in the JSON body, it will be ignored as well.
        /// </summary>
        /// <param name="id">A resource identifier specifying the resource to be updated.</param>
        /// <param name="IfMatch">The ETag header value used to prevent the PUT from updating a resource modified by another consumer.</param>
        /// <param name="body">The JSON representation of the &quot;course&quot; resource to be updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PutCourse(string id, string IfMatch, Course body) 
        {
            var request = new RestRequest("/courses/{id}", Method.PUT);
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
        public IRestResponse DeleteCourseById(string id, string IfMatch= null) 
        {
            var request = new RestRequest("/courses/{id}", Method.DELETE);
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

