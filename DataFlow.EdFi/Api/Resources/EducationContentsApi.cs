using System;
using System.Collections.Generic;
using System.Linq;
using DataFlow.EdFi.Models.Resources;
using RestSharp;

namespace DataFlow.EdFi.Api.Resources 
{
    public class EducationContentsApi 
    {
        private readonly IRestClient client;

        public EducationContentsApi(IRestClient client)
        {
            this.client = client;
        }
      
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<EducationContent>> GetEducationContentsAll(int? offset= null, int? limit= null) 
        {
            var request = new RestRequest("/educationContents", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            var response = client.Execute<List<EducationContent>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources matching values of an example resource (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get by Example&quot; search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="contentIdentifier">The identifier of the content standard.</param>
        /// <param name="learningResourceMetadataURI">The public web site address (URL), file, or ftp locator.</param>
        /// <param name="shortDescription">A shortened description for reference.</param>
        /// <param name="description">A detailed description of the entity.</param>
        /// <param name="additionalAuthorsIndicator">Indicates whether there are additional un-named authors. In a research report, this is often marked by the abbreviation &quot;et al&quot;.</param>
        /// <param name="publisher">The organization credited with publishing the resource.</param>
        /// <param name="timeRequired">Approximate or typical time it takes to work with or through this learning resource for the typical intended target audience.</param>
        /// <param name="interactivityStyleType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="contentClassType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="useRightsURL">The URL where the owner specifies permissions for using the resource.</param>
        /// <param name="publicationDate">The date on which this content was first published.</param>
        /// <param name="publicationYear">The year at which this content was first published.</param>
        /// <param name="version">The version identifier for the content.</param>
        /// <param name="learningStandardId">The identifier for the specific learning standard (e.g., 111.15.3.1.A).  </param>
        /// <param name="cost">An amount that has to be paid or spent to buy or obtain the EducationContent.</param>
        /// <param name="costRateType">A unique identifier used as Primary Key, not derived from business logic, when acting as Foreign Key, references the parent table.</param>
        /// <param name="namespace">Namespace for the EducationContent.</param>
        /// <param name="id"></param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<EducationContent>> GetEducationContentsAll(int? offset= null, int? limit= null, string contentIdentifier= null, string learningResourceMetadataURI= null, string shortDescription= null, string description= null, bool? additionalAuthorsIndicator= null, string publisher= null, string timeRequired= null, string interactivityStyleType= null, string contentClassType= null, string useRightsURL= null, DateTime? publicationDate= null, int? publicationYear= null, string version= null, string learningStandardId= null, double? cost= null, string costRateType= null, string @namespace= null, string id= null) 
        {
            var request = new RestRequest("/educationContents", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (contentIdentifier != null)
                request.AddParameter("contentIdentifier", contentIdentifier);
            if (learningResourceMetadataURI != null)
                request.AddParameter("learningResourceMetadataURI", learningResourceMetadataURI);
            if (shortDescription != null)
                request.AddParameter("shortDescription", shortDescription);
            if (description != null)
                request.AddParameter("description", description);
            if (additionalAuthorsIndicator != null)
                request.AddParameter("additionalAuthorsIndicator", additionalAuthorsIndicator);
            if (publisher != null)
                request.AddParameter("publisher", publisher);
            if (timeRequired != null)
                request.AddParameter("timeRequired", timeRequired);
            if (interactivityStyleType != null)
                request.AddParameter("interactivityStyleType", interactivityStyleType);
            if (contentClassType != null)
                request.AddParameter("contentClassType", contentClassType);
            if (useRightsURL != null)
                request.AddParameter("useRightsURL", useRightsURL);
            if (publicationDate != null)
                request.AddParameter("publicationDate", publicationDate);
            if (publicationYear != null)
                request.AddParameter("publicationYear", publicationYear);
            if (version != null)
                request.AddParameter("version", version);
            if (learningStandardId != null)
                request.AddParameter("learningStandardId", learningStandardId);
            if (cost != null)
                request.AddParameter("cost", cost);
            if (costRateType != null)
                request.AddParameter("costRateType", costRateType);
            if (@namespace != null)
                request.AddParameter("@namespace", @namespace);
            if (id != null)
                request.AddParameter("id", id);
            var response = client.Execute<List<EducationContent>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the values of the resource's natural key (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get by Key&quot; search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="contentIdentifier">The identifier of the content standard.</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<EducationContent> GetEducationContentByKey(string contentIdentifier, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/educationContents", Method.GET);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (contentIdentifier == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (contentIdentifier != null)
                request.AddParameter("contentIdentifier", contentIdentifier);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<EducationContent>(request);

            return response;
        }
        /// <summary>
        /// Creates or updates resources based on the natural key values of the supplied resource. The POST operation can be used to create or update resources. In database terms, this is often referred to as an &quot;upsert&quot; operation (insert + update).  Clients should NOT include the resource &quot;id&quot; in the JSON body because it will result in an error (you must use a PUT operation to update a resource by &quot;id&quot;). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.
        /// </summary>
        /// <param name="body">The JSON representation of the &quot;educationContent&quot; resource to be created or updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PostEducationContents(EducationContent body) 
        {
            var request = new RestRequest("/educationContents", Method.POST);
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
        public IRestResponse<EducationContent> GetEducationContentsById(string id, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/educationContents/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<EducationContent>(request);

            return response;
        }
        /// <summary>
        /// Updates or creates a resource based on the resource identifier. The PUT operation is used to update or create a resource by identifier.  If the resource doesn't exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource &quot;id&quot; is provided in the JSON body, it will be ignored as well.
        /// </summary>
        /// <param name="id">A resource identifier specifying the resource to be updated.</param>
        /// <param name="IfMatch">The ETag header value used to prevent the PUT from updating a resource modified by another consumer.</param>
        /// <param name="body">The JSON representation of the &quot;educationContent&quot; resource to be updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PutEducationContent(string id, string IfMatch, EducationContent body) 
        {
            var request = new RestRequest("/educationContents/{id}", Method.PUT);
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
        public IRestResponse DeleteEducationContentById(string id, string IfMatch= null) 
        {
            var request = new RestRequest("/educationContents/{id}", Method.DELETE);
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

