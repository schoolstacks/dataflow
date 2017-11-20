using System.Net;
using System.Security.Authentication;
using RestSharp;

namespace DataFlow.EdFi.Sdk
{
    public class TokenRetriever : ITokenRetriever
    {
        private string oauthUrl;
        private string clientKey;
        private string clientSecret;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oauthUrl"></param>
        /// <param name="clientKey"></param>
        /// <param name="clientSecret"></param>
        public TokenRetriever(string oauthUrl, string clientKey, string clientSecret)
        {
            this.oauthUrl = oauthUrl;
            this.clientKey = clientKey;
            this.clientSecret = clientSecret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ObtainNewBearerToken()
        {
            var oauthClient = new RestClient(oauthUrl);
            var accessCode = GetAccessCode(oauthClient);
            return GetBearerToken(oauthClient, accessCode);
        }

        private string GetAccessCode(IRestClient oauthClient)
        {
            var accessCodeRequest = new RestRequest("oauth/authorize", Method.POST);
            accessCodeRequest.AddParameter("Client_id", clientKey);
            accessCodeRequest.AddParameter("Response_type", "code");

            var accessCodeResponse = oauthClient.Execute<AccessCodeResponse>(accessCodeRequest);
            if (accessCodeResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new AuthenticationException("Unable to retrieve an authorization code. Error message: " +
                                                  accessCodeResponse.ErrorMessage);
            }
            if (accessCodeResponse.Data.Error != null)
            {
                throw new AuthenticationException(
                    "Unable to retrieve an authorization code. Please verify that your application key is correct. Alternately, the service address may not be correct: " +
                    oauthUrl);
            }

            return accessCodeResponse.Data.Code;
        }

        private string GetBearerToken(IRestClient oauthClient, string accessCode)
        {
            var bearerTokenRequest = new RestRequest("oauth/token", Method.POST);
            bearerTokenRequest.AddParameter("Client_id", clientKey);
            bearerTokenRequest.AddParameter("Client_secret", clientSecret);
            bearerTokenRequest.AddParameter("Code", accessCode);
            bearerTokenRequest.AddParameter("Grant_type", "authorization_code");

            var bearerTokenResponse = oauthClient.Execute<BearerTokenResponse>(bearerTokenRequest);
            if (bearerTokenResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new AuthenticationException("Unable to retrieve an access token. Error message: " +
                                                  bearerTokenResponse.ErrorMessage);
            }

            if (bearerTokenResponse.Data.Error != null || bearerTokenResponse.Data.Token_type != "bearer")
            {
                throw new AuthenticationException(
                    "Unable to retrieve an access token. Please verify that your application secret is correct.");
            }

            return bearerTokenResponse.Data.Access_token;
        }
    }

    internal class AccessCodeResponse
    {
        public string Code { get; set; }
        public string State { get; set; }
        public string Error { get; set; }
    }

    internal class BearerTokenResponse
    {
        public string Access_token { get; set; }
        public string Expires_in { get; set; }
        public string Token_type { get; set; }
        public string Error { get; set; }
    }
}

