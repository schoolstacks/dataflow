using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.OdsApi.Sdk;
using EdFi.OdsApi.Models.Resources;
using RestSharp;
  
namespace EdFi.OdsApi.Api.Resources 
{
    public class DisciplineActionsApi 
    {
        private readonly IRestClient client;

        public DisciplineActionsApi(IRestClient client)
        {
            this.client = client;
        }
      
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<DisciplineAction>> GetDisciplineActionsAll(int? offset= null, int? limit= null) 
        {
            var request = new RestRequest("/disciplineActions", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            var response = client.Execute<List<DisciplineAction>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources matching values of an example resource (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get by Example&quot; search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="identifier">Identifier assigned by the education organization to the discipline action.</param>
        /// <param name="studentUniqueId">A unique alpha-numeric code assigned to a student.</param>
        /// <param name="disciplineDate">The date of the DisciplineAction.</param>
        /// <param name="length">The length of time in school days for the Discipline Action (e.g. removal, detention), if applicable.</param>
        /// <param name="actualDisciplineActionLength">Indicates the actual length in school days of a student's disciplinary assignment.</param>
        /// <param name="lengthDifferenceReasonType">Key for DisciplineActionLengthDifferenceReason</param>
        /// <param name="relatedToZeroTolerancePolicy">An indication of whether or not this disciplinary action taken against a student was imposed as a consequence of state or local zero tolerance policies.</param>
        /// <param name="responsibilitySchoolId">School responsible for student's discipline.</param>
        /// <param name="assignmentSchoolId">Optional school where student is transferred for discipline.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<DisciplineAction>> GetDisciplineActionsAll(int? offset= null, int? limit= null, string identifier= null, string studentUniqueId= null, DateTime? disciplineDate= null, int? length= null, int? actualDisciplineActionLength= null, string lengthDifferenceReasonType= null, bool? relatedToZeroTolerancePolicy= null, int? responsibilitySchoolId= null, int? assignmentSchoolId= null, string id= null) 
        {
            var request = new RestRequest("/disciplineActions", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (identifier != null)
                request.AddParameter("identifier", identifier);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (disciplineDate != null)
                request.AddParameter("disciplineDate", disciplineDate);
            if (length != null)
                request.AddParameter("length", length);
            if (actualDisciplineActionLength != null)
                request.AddParameter("actualDisciplineActionLength", actualDisciplineActionLength);
            if (lengthDifferenceReasonType != null)
                request.AddParameter("lengthDifferenceReasonType", lengthDifferenceReasonType);
            if (relatedToZeroTolerancePolicy != null)
                request.AddParameter("relatedToZeroTolerancePolicy", relatedToZeroTolerancePolicy);
            if (responsibilitySchoolId != null)
                request.AddParameter("responsibilitySchoolId", responsibilitySchoolId);
            if (assignmentSchoolId != null)
                request.AddParameter("assignmentSchoolId", assignmentSchoolId);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<DisciplineAction>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the values of the resource's natural key (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get by Key&quot; search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="identifier">Identifier assigned by the education organization to the discipline action.</param>
        /// <param name="studentUniqueId">A unique alpha-numeric code assigned to a student.</param>
        /// <param name="disciplineDate">The date of the DisciplineAction.</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<DisciplineAction> GetDisciplineActionByKey(string identifier, string studentUniqueId, DateTime? disciplineDate, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/disciplineActions", Method.GET);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (identifier == null || studentUniqueId == null || disciplineDate == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (identifier != null)
                request.AddParameter("identifier", identifier);
            if (studentUniqueId != null)
                request.AddParameter("studentUniqueId", studentUniqueId);
            if (disciplineDate != null)
                request.AddParameter("disciplineDate", disciplineDate);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<DisciplineAction>(request);

            return response;
        }
        /// <summary>
        /// Creates or updates resources based on the natural key values of the supplied resource. The POST operation can be used to create or update resources. In database terms, this is often referred to as an &quot;upsert&quot; operation (insert + update).  Clients should NOT include the resource &quot;id&quot; in the JSON body because it will result in an error (you must use a PUT operation to update a resource by &quot;id&quot;). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.
        /// </summary>
        /// <param name="body">The JSON representation of the &quot;disciplineAction&quot; resource to be created or updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PostDisciplineActions(DisciplineAction body) 
        {
            var request = new RestRequest("/disciplineActions", Method.POST);
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
        public IRestResponse<DisciplineAction> GetDisciplineActionsById(string id, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/disciplineActions/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<DisciplineAction>(request);

            return response;
        }
        /// <summary>
        /// Updates or creates a resource based on the resource identifier. The PUT operation is used to update or create a resource by identifier.  If the resource doesn't exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource &quot;id&quot; is provided in the JSON body, it will be ignored as well.
        /// </summary>
        /// <param name="id">A resource identifier specifying the resource to be updated.</param>
        /// <param name="IfMatch">The ETag header value used to prevent the PUT from updating a resource modified by another consumer.</param>
        /// <param name="body">The JSON representation of the &quot;disciplineAction&quot; resource to be updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PutDisciplineAction(string id, string IfMatch, DisciplineAction body) 
        {
            var request = new RestRequest("/disciplineActions/{id}", Method.PUT);
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
        public IRestResponse DeleteDisciplineActionById(string id, string IfMatch= null) 
        {
            var request = new RestRequest("/disciplineActions/{id}", Method.DELETE);
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

