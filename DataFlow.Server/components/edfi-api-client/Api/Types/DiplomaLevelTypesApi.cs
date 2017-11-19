using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.OdsApi.Sdk;
using EdFi.OdsApi.Models.Types;
using RestSharp;
  
namespace EdFi.OdsApi.Api.Types 
{
    public class DiplomaLevelTypesApi 
    {
        private readonly IRestClient client;

        public DiplomaLevelTypesApi(IRestClient client)
        {
            this.client = client;
        }
      
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<DiplomaLevelType>> GetDiplomaLevelTypesAll(int? offset= null, int? limit= null) 
        {
            var request = new RestRequest("/diplomaLevelTypes", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            var response = client.Execute<List<DiplomaLevelType>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources matching values of an example resource (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get by Example&quot; search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="diplomaLevelTypeId">Key for DiplomaLevel</param>
        /// <param name="codeValue">Code for DiplomaLevel type.</param>
        /// <param name="description">The description of the descriptor.</param>
        /// <param name="shortDescription">A shortened description for the diploma level type.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<DiplomaLevelType>> GetDiplomaLevelTypesAll(int? offset= null, int? limit= null, int? diplomaLevelTypeId= null, string codeValue= null, string description= null, string shortDescription= null, string id= null) 
        {
            var request = new RestRequest("/diplomaLevelTypes", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (diplomaLevelTypeId != null)
                request.AddParameter("diplomaLevelTypeId", diplomaLevelTypeId);
            if (codeValue != null)
                request.AddParameter("codeValue", codeValue);
            if (description != null)
                request.AddParameter("description", description);
            if (shortDescription != null)
                request.AddParameter("shortDescription", shortDescription);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<DiplomaLevelType>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the values of the resource's natural key (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get by Key&quot; search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="diplomaLevelTypeId">Key for DiplomaLevel</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<DiplomaLevelType> GetDiplomaLevelTypeByKey(int? diplomaLevelTypeId, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/diplomaLevelTypes", Method.GET);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (diplomaLevelTypeId == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (diplomaLevelTypeId != null)
                request.AddParameter("diplomaLevelTypeId", diplomaLevelTypeId);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<DiplomaLevelType>(request);

            return response;
        }
        /// <summary>
        /// Creates or updates resources based on the natural key values of the supplied resource. The POST operation can be used to create or update resources. In database terms, this is often referred to as an &quot;upsert&quot; operation (insert + update).  Clients should NOT include the resource &quot;id&quot; in the JSON body because it will result in an error (you must use a PUT operation to update a resource by &quot;id&quot;). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.
        /// </summary>
        /// <param name="body">The JSON representation of the &quot;diplomaLevelType&quot; resource to be created or updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PostDiplomaLevelTypes(DiplomaLevelType body) 
        {
            var request = new RestRequest("/diplomaLevelTypes", Method.POST);
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
        public IRestResponse<DiplomaLevelType> GetDiplomaLevelTypesById(string id, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/diplomaLevelTypes/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<DiplomaLevelType>(request);

            return response;
        }
        /// <summary>
        /// Updates or creates a resource based on the resource identifier. The PUT operation is used to update or create a resource by identifier.  If the resource doesn't exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource &quot;id&quot; is provided in the JSON body, it will be ignored as well.
        /// </summary>
        /// <param name="id">A resource identifier specifying the resource to be updated.</param>
        /// <param name="IfMatch">The ETag header value used to prevent the PUT from updating a resource modified by another consumer.</param>
        /// <param name="body">The JSON representation of the &quot;diplomaLevelType&quot; resource to be updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PutDiplomaLevelType(string id, string IfMatch, DiplomaLevelType body) 
        {
            var request = new RestRequest("/diplomaLevelTypes/{id}", Method.PUT);
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
        public IRestResponse DeleteDiplomaLevelTypeById(string id, string IfMatch= null) 
        {
            var request = new RestRequest("/diplomaLevelTypes/{id}", Method.DELETE);
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

