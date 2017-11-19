using System.Collections.Generic;
using RestSharp;
using System;
using System.Linq;

namespace EdFi.OdsApi.Sdk
{
    public class IdentitiesApi 
    {
        private readonly IRestClient client;

        public IdentitiesApi(IRestClient client)
        {
            this.client = client;
        }
      
        /// <summary>
        /// Lookup an existing Unique Id for a person, or suggest possible matches Returns a list of potential matches for the provided identity resource
        /// </summary>
        public IRestResponse<List<Identity>> IdentitiesV1_GetByExample(Identity identity) 
        {
            // verify required params are set
            if (identity == null)
            {
                throw new ArgumentException("API method call is missing required parameters");
            }

            var request = new RestRequest("/identities", Method.GET);
            request.RequestFormat = DataFormat.Json;

            if (!string.IsNullOrEmpty(identity.familyNames))
                request.AddParameter("familyNames", identity.familyNames);

            if (!string.IsNullOrEmpty(identity.givenNames))
                request.AddParameter("givenNames", identity.givenNames);

            if (!string.IsNullOrEmpty(identity.birthGender))
                request.AddParameter("birthGender", identity.birthGender);

            if (!string.IsNullOrEmpty(identity.birthDate))
                request.AddParameter("birthDate", identity.birthDate);

            return client.Execute<List<Identity>>(request);

        }
        /// <summary>
        /// Creates a new Unique Id for the given Identity information. 
        /// Assumption here is that the user has verified that possible matches are not correct matches. Returns the created identity information along with the assigned Unique Id
        /// </summary>
        /// <param name="body">Identity object to be created</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<Identity> IdentitiesV1_Post(Identity body) 
        {
            // verify required params are set
            if (body == null)
            {
                throw new ArgumentException("API method call is missing required parameters");
            }

            var request = new RestRequest("/identities", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(body);

            return client.Execute<Identity>(request);
        }

        /// <summary>
        /// Retrieve a single person record from their Unique Id. Returns either a single Identity or 404 and no data
        /// </summary>
        /// <param name="id">Unique Id of the person to be retrieved</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<Identity> IdentitiesV1_GetById(string id) 
        {
            // verify required params are set
            if (id == null)
            {
                throw new ArgumentException("API method call is missing required parameters");
            }

            var request = new RestRequest("/identities/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddUrlSegment("id", id);

            return client.Execute<Identity>(request);
        }
        /// <summary>
        /// Creates a new Unique Id for the given Identity information. Assumption here is that the user has verified that possible matches are not correct matches. Returns the created identity information along with the assigned Unique Id.
        /// </summary>
        /// <param name="body">Identity object to be created.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse IdentitiesV2_Create(IdentityCreateRequest body) 
        {
            var request = new RestRequest("/identities/v2.0", Method.POST);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (body == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddBody(body);
            request.AddHeader("Accept", "application/json, text/json");
            request.Parameters.First(param => param.Type == ParameterType.RequestBody).Name = "application/json, text/json";
            var response = client.Execute(request);

            var location = response.Headers.FirstOrDefault(x => x.Name == "Location");

            return response;
        }
        /// <summary>
        /// Retrieve a single person record from their Unique Id. Returns either a single identity or 404 and no data
        /// </summary>
        /// <param name="id">Unique Id of the identity to be retrieved</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<IdentityResponse> IdentitiesV2_GetById(string id) 
        {
            var request = new RestRequest("/identities/v2.0/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("Accept", "application/json, text/json");
            var response = client.Execute<IdentityResponse>(request);

            return response;
        }
        /// <summary>
        /// Retrieve a multiple person records from their Unique Ids. 
        /// </summary>
        /// <param name="body">Unique Ids of the persons to be retrieved.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<IdentitySearchResponse> IdentitiesV2_Find(List<string> body) 
        {
            var request = new RestRequest("/identities/v2.0/find", Method.POST);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (body == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddBody(body);
            request.AddHeader("Accept", "application/json, text/json");
            request.Parameters.First(param => param.Type == ParameterType.RequestBody).Name = "application/json, text/json";
            var response = client.Execute<IdentitySearchResponse>(request);

            var location = response.Headers.FirstOrDefault(x => x.Name == "Location");

            return response;
        }
        /// <summary>
        /// Retrieve asynchronous search results from a previously created request. 
        /// </summary>
        /// <param name="id">The search token provided by a Find or Search request.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<IdentitySearchResponse> IdentitiesV2_Result(string id) 
        {
            var request = new RestRequest("/identities/v2.0/results/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddHeader("Accept", "application/json, text/json");
            var response = client.Execute<IdentitySearchResponse>(request);

            return response;
        }
        /// <summary>
        /// Lookup existing Unique Ids for a persons, or suggest possible matches. 
        /// </summary>
        /// <param name="body">One or more identity search request objects.</param>
        /// <returns>A RestSharp <see cref="IRestResponse"/> instance containing the API response details.</returns>
        public IRestResponse<IdentitySearchResponse> IdentitiesV2_Search(List<IdentitySearchRequest> body) 
        {
            var request = new RestRequest("/identities/v2.0/search", Method.POST);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (body == null ) 
               throw new ArgumentException("API method call is missing required parameters");
            request.AddBody(body);
            request.AddHeader("Accept", "application/json, text/json");
            request.Parameters.First(param => param.Type == ParameterType.RequestBody).Name = "application/json, text/json";
            var response = client.Execute<IdentitySearchResponse>(request);

            var location = response.Headers.FirstOrDefault(x => x.Name == "Location");

            return response;
        }
    }
}
