using System;
using RestSharp;

namespace EdFi.OdsApi.Sdk
{
    public class BulkOperationsApi
    {
        private readonly IRestClient client;

        public BulkOperationsApi(IRestClient client)
        {
            this.client = client;
        }

        public IRestResponse<BulkOperation> PostBulkOperations(BulkOperation body)
        {
            var request = new RestRequest("/bulkOperations", Method.POST);
            request.RequestFormat = DataFormat.Json;

            // verify required params are set
            if (body == null)
            {
                throw new ArgumentException("API method call is missing required parameters");
            }

            request.AddBody(body);
            return client.Execute<BulkOperation>(request);
        }

        public IRestResponse<BulkOperation> GetBulkOperationsById(string id)
        {
            var request = new RestRequest("/bulkOperations/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddUrlSegment("id", id);
            // verify required params are set
            if (id == null)
            {
                throw new ArgumentException("API method call is missing required parameters");
            }

            return client.Execute<BulkOperation>(request);
        }
    }
}

