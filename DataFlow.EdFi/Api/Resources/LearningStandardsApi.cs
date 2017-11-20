using System;
using System.Collections.Generic;
using System.Linq;
using DataFlow.EdFi.Models.Resources;
using RestSharp;

namespace DataFlow.EdFi.Api.Resources 
{
    public class LearningStandardsApi 
    {
        private readonly IRestClient client;

        public LearningStandardsApi(IRestClient client)
        {
            this.client = client;
        }
      
        /// <summary>
        /// Retrieves resources based with paging capabilities (using the &quot;Get All&quot; pattern). This GET operation provides access to resources using the &quot;Get All&quot; pattern. In this version of the API there is support for paging.
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<LearningStandard>> GetLearningStandardsAll(int? offset= null, int? limit= null) 
        {
            var request = new RestRequest("/learningStandards", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            var response = client.Execute<List<LearningStandard>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves resources matching values of an example resource (using the &quot;Get By Example&quot; pattern). This GET operation provides access to resources using the &quot;Get by Example&quot; search pattern.  The values of any properties of the resource that are specified will be used to return all matching results (if it exists).
        /// </summary>
        /// <param name="offset">Indicates how many items should be skipped before returning results.</param>
        /// <param name="limit">Indicates the maximum number of items that should be returned in the results (defaults to 25).</param>
        /// <param name="learningStandardId">A unique number or alphanumeric code assigned to a Learning Standard.</param>
        /// <param name="parentLearningStandardId">The Identifier for the specific learning standard (e.g., 111.15.3.1.A)</param>
        /// <param name="description">A detailed description of the entity.</param>
        /// <param name="itemCode">A code designated by the promulgating body to identify the statement, e.g. 1.N.3 (usually not globally unique).</param>
        /// <param name="uri">The public web site address (URL), file, or ftp locator.</param>
        /// <param name="academicSubjectDescriptor">Subject area for the learning standard.</param>
        /// <param name="courseTitle">The descriptive name given to a course of study offered in a school or other institution or organization. In departmentalized classes at the elementary, secondary, and postsecondary levels (and for staff development activities), this refers to the name by which a course is identified (e.g., American History, English III). For elementary and other non-departmentalized classes, it refers to any portion of the instruction for which a grade or report is assigned (e.g., reading, composition, spelling, and language arts).</param>
        /// <param name="successCriteria">One or more statements that describes the criteria used by teachers and students to check for attainment of a learning standard. This criteria gives clear indications as to the degree to which learning is moving through the Zone or Proximal Development toward independent achievement of the LearningStandard.</param>
        /// <param name="id"></param>
        /// <param name="namespace">Namespace for the LearningStandard.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<List<LearningStandard>> GetLearningStandardsAll(int? offset= null, int? limit= null, string learningStandardId= null, string parentLearningStandardId= null, string description= null, string itemCode= null, string uri= null, string academicSubjectDescriptor= null, string courseTitle= null, string successCriteria= null, string id= null, string @namespace= null) 
        {
            var request = new RestRequest("/learningStandards", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (offset != null)
                request.AddParameter("offset", offset);
            if (limit != null)
                request.AddParameter("limit", limit);
            if (learningStandardId != null)
                request.AddParameter("learningStandardId", learningStandardId);
            if (parentLearningStandardId != null)
                request.AddParameter("parentLearningStandardId", parentLearningStandardId);
            if (description != null)
                request.AddParameter("description", description);
            if (itemCode != null)
                request.AddParameter("itemCode", itemCode);
            if (uri != null)
                request.AddParameter("uri", uri);
            if (academicSubjectDescriptor != null)
                request.AddParameter("academicSubjectDescriptor", academicSubjectDescriptor);
            if (courseTitle != null)
                request.AddParameter("courseTitle", courseTitle);
            if (successCriteria != null)
                request.AddParameter("successCriteria", successCriteria);
            if (id != null)
                request.AddParameter("id", id);
            if (@namespace != null)
                request.AddParameter("@namespace", @namespace);
            var response = client.Execute<List<LearningStandard>>(request);

            return response;
        }
        /// <summary>
        /// Retrieves a specific resource using the values of the resource's natural key (using the &quot;Get By Key&quot; pattern). This GET operation provides access to resources using the &quot;Get by Key&quot; search pattern. The values of the natural key of the resource must be fully specified, and the service will return the matching result (if it exists).
        /// </summary>
        /// <param name="learningStandardId">A unique number or alphanumeric code assigned to a Learning Standard.</param>
        /// <param name="IfNoneMatch">The previously returned ETag header value, used here to prevent the unnecessary data transfer of an unchanged resource.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<LearningStandard> GetLearningStandardByKey(string learningStandardId, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/learningStandards", Method.GET);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (learningStandardId == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            if (learningStandardId != null)
                request.AddParameter("learningStandardId", learningStandardId);
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<LearningStandard>(request);

            return response;
        }
        /// <summary>
        /// Creates or updates resources based on the natural key values of the supplied resource. The POST operation can be used to create or update resources. In database terms, this is often referred to as an &quot;upsert&quot; operation (insert + update).  Clients should NOT include the resource &quot;id&quot; in the JSON body because it will result in an error (you must use a PUT operation to update a resource by &quot;id&quot;). The web service will identify whether the resource already exists based on the natural key values provided, and update or create the resource appropriately.
        /// </summary>
        /// <param name="body">The JSON representation of the &quot;learningStandard&quot; resource to be created or updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PostLearningStandards(LearningStandard body) 
        {
            var request = new RestRequest("/learningStandards", Method.POST);
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
        public IRestResponse<LearningStandard> GetLearningStandardsById(string id, string IfNoneMatch= null) 
        {
            var request = new RestRequest("/learningStandards/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("If-None-Match", IfNoneMatch);
            var response = client.Execute<LearningStandard>(request);

            return response;
        }
        /// <summary>
        /// Updates or creates a resource based on the resource identifier. The PUT operation is used to update or create a resource by identifier.  If the resource doesn't exist, the resource will be created using that identifier.  Additionally, natural key values cannot be changed using this operation, and will not be modified in the database.  If the resource &quot;id&quot; is provided in the JSON body, it will be ignored as well.
        /// </summary>
        /// <param name="id">A resource identifier specifying the resource to be updated.</param>
        /// <param name="IfMatch">The ETag header value used to prevent the PUT from updating a resource modified by another consumer.</param>
        /// <param name="body">The JSON representation of the &quot;learningStandard&quot; resource to be updated.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse PutLearningStandard(string id, string IfMatch, LearningStandard body) 
        {
            var request = new RestRequest("/learningStandards/{id}", Method.PUT);
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
        public IRestResponse DeleteLearningStandardById(string id, string IfMatch= null) 
        {
            var request = new RestRequest("/learningStandards/{id}", Method.DELETE);
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

