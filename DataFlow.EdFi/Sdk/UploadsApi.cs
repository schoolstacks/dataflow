using System;
using RestSharp;

namespace DataFlow.EdFi.Sdk
{
    public class UploadsApi
    {
        private readonly IRestClient client;

        public UploadsApi(IRestClient client)
        {
            this.client = client;
        }

        public IRestResponse<Upload> PostUploads(Upload upload)
        {
            // verify required params are set
            if (upload == null || upload.fileBytes == null)
            {
                throw new ArgumentException("API method call is missing required parameters");
            }

            var request = new RestRequest("/uploads/{uploadId}/chunk", Method.POST);
            
            request.AddUrlSegment("uploadId", upload.id);
            request.AddParameter("offset", upload.offset.ToString(), ParameterType.QueryString);
            request.AddParameter("size", upload.size.ToString(), ParameterType.QueryString);
            request.AddFile(upload.id, upload.fileBytes, upload.id);

            return client.Execute<Upload>(request);
        }

        public IRestResponse<Upload> CommitUploads(Upload upload)
        {
            var request = new RestRequest("/uploads/{uploadId}/commit", Method.POST);

            request.AddUrlSegment("uploadId", upload.id);

            return client.Execute<Upload>(request);
        }
    }
}

