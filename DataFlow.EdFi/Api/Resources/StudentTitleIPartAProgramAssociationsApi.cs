using System;
using System.Collections.Generic;
using System.Linq;
using DataFlow.EdFi.Models.Resources;
using RestSharp;

namespace DataFlow.EdFi.Api.Resources 
{
    public class StudentTitleIPartAProgramAssociationsApi 
    {
        private readonly IRestClient client;

        public StudentTitleIPartAProgramAssociationsApi(IRestClient client)
        {
            this.client = client;
        }
      
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StudentTitleIPartAProgramAssociation>> GetStudentTitleIPartAProgramAssociationsAll(int? offset= null, int? limit= null) 
        {
            var request = new RestRequest("/studentTitleIPartAProgramAssociations", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            var response = client.Execute<List<StudentTitleIPartAProgramAssociation>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources matching values of an example resource (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get by Example&quot; search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="studentUniqueId">A unique alpha-numeric code assigned to a student.</param>
        /// <param name="educationOrganizationId">The education organization where the student is participating in or receiving the program services.</param>
        /// <param name="programType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="programName">The formal name of the program of instruction, training, services or benefits available through federal, state, or local agencies.</param>
        /// <param name="programEducationOrganizationId">The education organization where the student is participating in or receiving the program services.</param>
        /// <param name="beginDate">The month, day, and year on which the Student first received services.</param>
        /// <param name="titleIPartAParticipantType">An indication of the type of Title I program, if any, in which the student is participating and served:  Public Targeted Assistance Program  Public Schoolwide Program  Private school student participating  Local Neglected Program  NEDM: Title I Participlant</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<StudentTitleIPartAProgramAssociation>> GetStudentTitleIPartAProgramAssociationsAll(int? offset= null, int? limit= null, string studentUniqueId= null, int? educationOrganizationId= null, string programType= null, string programName= null, int? programEducationOrganizationId= null, DateTime? beginDate= null, string titleIPartAParticipantType= null) 
        {
            var request = new RestRequest("/studentTitleIPartAProgramAssociations", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (educationOrganizationId != null)
                request.AddParameter("educationOrganizationId", educationOrganizationId);
            if (programType != null)
                request.AddParameter("programType", programType);
            if (programName != null)
                request.AddParameter("programName", programName);
            if (programEducationOrganizationId != null)
                request.AddParameter("programEducationOrganizationId", programEducationOrganizationId);
            if (beginDate != null)
                request.AddParameter("beginDate", beginDate);
            if (titleIPartAParticipantType != null)
                request.AddParameter("titleIPartAParticipantType", titleIPartAParticipantType);
            var response = client.Execute<List<StudentTitleIPartAProgramAssociation>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the values of the resource's natural key (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get by Key&quot; search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="studentUniqueId">A unique alpha-numeric code assigned to a student.</param>
        /// <param name="educationOrganizationId">The education organization where the student is participating in or receiving the program services.</param>
        /// <param name="programType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="programName">The formal name of the program of instruction, training, services or benefits available through federal, state, or local agencies.</param>
        /// <param name="programEducationOrganizationId">The education organization where the student is participating in or receiving the program services.</param>
        /// <param name="beginDate">The month, day, and year on which the Student first received services.</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<StudentTitleIPartAProgramAssociation> GetStudentTitleIPartAProgramAssociationByKey(string studentUniqueId, int? educationOrganizationId, string programType, string programName, int? programEducationOrganizationId, DateTime? beginDate, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/studentTitleIPartAProgramAssociations", Method.GET);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (studentUniqueId == null || educationOrganizationId == null || programType == null || programName == null || programEducationOrganizationId == null || beginDate == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (educationOrganizationId != null)
                request.AddParameter("educationOrganizationId", educationOrganizationId);
            if (programType != null)
                request.AddParameter("programType", programType);
            if (programName != null)
                request.AddParameter("programName", programName);
            if (programEducationOrganizationId != null)
                request.AddParameter("programEducationOrganizationId", programEducationOrganizationId);
            if (beginDate != null)
                request.AddParameter("beginDate", beginDate);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<StudentTitleIPartAProgramAssociation>(request);

            return response;
        }
        /// <summary>
        /// Creates or updates resources based on the natural key values of the supplied resource. The POST operation can be used to create or update resources. In database terms, this is often referred to as an &quot;upsert&quot; operation (insert + update).  Clients should NOT include the resource &quot;id&quot; in the JSON body because it will result in an error (you must use a PUT operation to update a resource by &quot;id&quot;). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.
        /// </summary>
        /// <param name="body">The JSON representation of the &quot;studentTitleIPartAProgramAssociation&quot; resource to be created or updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PostStudentTitleIPartAProgramAssociations(StudentTitleIPartAProgramAssociation body) 
        {
            var request = new RestRequest("/studentTitleIPartAProgramAssociations", Method.POST);
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
        public IRestResponse<StudentTitleIPartAProgramAssociation> GetStudentTitleIPartAProgramAssociationsById(string id, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/studentTitleIPartAProgramAssociations/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<StudentTitleIPartAProgramAssociation>(request);

            return response;
        }
        /// <summary>
        /// Updates or creates a resource based on the resource identifier. The PUT operation is used to update or create a resource by identifier.  If the resource doesn't exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource &quot;id&quot; is provided in the JSON body, it will be ignored as well.
        /// </summary>
        /// <param name="id">A resource identifier specifying the resource to be updated.</param>
        /// <param name="IfMatch">The ETag header value used to prevent the PUT from updating a resource modified by another consumer.</param>
        /// <param name="body">The JSON representation of the &quot;studentTitleIPartAProgramAssociation&quot; resource to be updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PutStudentTitleIPartAProgramAssociation(string id, string IfMatch, StudentTitleIPartAProgramAssociation body) 
        {
            var request = new RestRequest("/studentTitleIPartAProgramAssociations/{id}", Method.PUT);
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
        public IRestResponse DeleteStudentTitleIPartAProgramAssociationById(string id, string IfMatch= null) 
        {
            var request = new RestRequest("/studentTitleIPartAProgramAssociations/{id}", Method.DELETE);
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

