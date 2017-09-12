using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.OdsApi.Sdk;
using EdFi.OdsApi.Models.Resources;
using RestSharp;
  
namespace EdFi.OdsApi.Api.Resources 
{
    public class SectionAttendanceTakenEventsApi 
    {
        private readonly IRestClient client;

        public SectionAttendanceTakenEventsApi(IRestClient client)
        {
            this.client = client;
        }
      
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<SectionAttendanceTakenEvent>> GetSectionAttendanceTakenEventsAll(int? offset= null, int? limit= null) 
        {
            var request = new RestRequest("/sectionAttendanceTakenEvents", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            var response = client.Execute<List<SectionAttendanceTakenEvent>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources matching values of an example resource (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get by Example&quot; search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="schoolId">School Identity Column</param>
        /// <param name="classPeriodName">An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period</param>
        /// <param name="classroomIdentificationCode">A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.</param>
        /// <param name="localCourseCode">The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.</param>
        /// <param name="termDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="schoolYear">The identifier for the school year.</param>
        /// <param name="uniqueSectionCode">A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned.</param>
        /// <param name="sequenceOfCourse">When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1.</param>
        /// <param name="date">The month, day, and year of the CalendarDate.</param>
        /// <param name="eventDate">The date the SectionAttendanceTakenEvent was submitted, which could be a different date than the instructional day.</param>
        /// <param name="staffUniqueId">A unique alpha-numeric code assigned to a staff.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<SectionAttendanceTakenEvent>> GetSectionAttendanceTakenEventsAll(int? offset= null, int? limit= null, int? schoolId= null, string classPeriodName= null, string classroomIdentificationCode= null, string localCourseCode= null, string termDescriptor= null, int? schoolYear= null, string uniqueSectionCode= null, int? sequenceOfCourse= null, DateTime? date= null, DateTime? eventDate= null, string staffUniqueId= null, string id= null) 
        {
            var request = new RestRequest("/sectionAttendanceTakenEvents", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (classPeriodName != null)
                request.AddParameter("classPeriodName", classPeriodName);
            if (classroomIdentificationCode != null)
                request.AddParameter("classroomIdentificationCode", classroomIdentificationCode);
            if (localCourseCode != null)
                request.AddParameter("localCourseCode", localCourseCode);
            if (termDescriptor != null)
                request.AddParameter("termDescriptor", termDescriptor);
            if (schoolYear != null)
                request.AddParameter("schoolYear", schoolYear);
            if (uniqueSectionCode != null)
                request.AddParameter("uniqueSectionCode", uniqueSectionCode);
            if (sequenceOfCourse != null)
                request.AddParameter("sequenceOfCourse", sequenceOfCourse);
            if (date != null)
                request.AddParameter("date", date);
            if (eventDate != null)
                request.AddParameter("eventDate", eventDate);
            if (staffUniqueId != null)
                request.AddParameter("staffUniqueId", staffUniqueId);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<SectionAttendanceTakenEvent>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the values of the resource's natural key (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get by Key&quot; search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="schoolId">School Identity Column</param>
        /// <param name="classPeriodName">An indication of the portion of a typical daily session in which students receive instruction in a specified subject (e.g., morning, sixth period, block period, or AB schedules).   NEDM: Class Period</param>
        /// <param name="classroomIdentificationCode">A unique number or alphanumeric code assigned to a room by a school, school system, state, or other agency or entity.</param>
        /// <param name="localCourseCode">The local code assigned by the LEA or Campus that identifies the organization of subject matter and related learning experiences provided for the instruction of students.</param>
        /// <param name="termDescriptor">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="schoolYear">The identifier for the school year.</param>
        /// <param name="uniqueSectionCode">A unique identifier for the Section, that is defined by the classroom, the subjects taught, and the instructors that are assigned.</param>
        /// <param name="sequenceOfCourse">When a Section is part of a sequence of parts for a course, the number if the sequence. If the course has only one part, the value of this Section attribute should be 1.</param>
        /// <param name="date">The month, day, and year of the CalendarDate.</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<SectionAttendanceTakenEvent> GetSectionAttendanceTakenEventByKey(int? schoolId, string classPeriodName, string classroomIdentificationCode, string localCourseCode, string termDescriptor, int? schoolYear, string uniqueSectionCode, int? sequenceOfCourse, DateTime? date, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/sectionAttendanceTakenEvents", Method.GET);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (schoolId == null || classPeriodName == null || classroomIdentificationCode == null || localCourseCode == null || termDescriptor == null || schoolYear == null || uniqueSectionCode == null || sequenceOfCourse == null || date == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (schoolId != null)
                request.AddParameter("schoolId", schoolId);
            if (classPeriodName != null)
                request.AddParameter("classPeriodName", classPeriodName);
            if (classroomIdentificationCode != null)
                request.AddParameter("classroomIdentificationCode", classroomIdentificationCode);
            if (localCourseCode != null)
                request.AddParameter("localCourseCode", localCourseCode);
            if (termDescriptor != null)
                request.AddParameter("termDescriptor", termDescriptor);
            if (schoolYear != null)
                request.AddParameter("schoolYear", schoolYear);
            if (uniqueSectionCode != null)
                request.AddParameter("uniqueSectionCode", uniqueSectionCode);
            if (sequenceOfCourse != null)
                request.AddParameter("sequenceOfCourse", sequenceOfCourse);
            if (date != null)
                request.AddParameter("date", date);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<SectionAttendanceTakenEvent>(request);

            return response;
        }
        /// <summary>
        /// Creates or updates resources based on the natural key values of the supplied resource. The POST operation can be used to create or update resources. In database terms, this is often referred to as an &quot;upsert&quot; operation (insert + update).  Clients should NOT include the resource &quot;id&quot; in the JSON body because it will result in an error (you must use a PUT operation to update a resource by &quot;id&quot;). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.
        /// </summary>
        /// <param name="body">The JSON representation of the &quot;sectionAttendanceTakenEvent&quot; resource to be created or updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PostSectionAttendanceTakenEvents(SectionAttendanceTakenEvent body) 
        {
            var request = new RestRequest("/sectionAttendanceTakenEvents", Method.POST);
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
        public IRestResponse<SectionAttendanceTakenEvent> GetSectionAttendanceTakenEventsById(string id, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/sectionAttendanceTakenEvents/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<SectionAttendanceTakenEvent>(request);

            return response;
        }
        /// <summary>
        /// Updates or creates a resource based on the resource identifier. The PUT operation is used to update or create a resource by identifier.  If the resource doesn't exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource &quot;id&quot; is provided in the JSON body, it will be ignored as well.
        /// </summary>
        /// <param name="id">A resource identifier specifying the resource to be updated.</param>
        /// <param name="IfMatch">The ETag header value used to prevent the PUT from updating a resource modified by another consumer.</param>
        /// <param name="body">The JSON representation of the &quot;sectionAttendanceTakenEvent&quot; resource to be updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PutSectionAttendanceTakenEvent(string id, string IfMatch, SectionAttendanceTakenEvent body) 
        {
            var request = new RestRequest("/sectionAttendanceTakenEvents/{id}", Method.PUT);
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
        public IRestResponse DeleteSectionAttendanceTakenEventById(string id, string IfMatch= null) 
        {
            var request = new RestRequest("/sectionAttendanceTakenEvents/{id}", Method.DELETE);
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

