using System.Net.Http;
using System.Threading.Tasks;

using TranscribeMe.API.SDK.Responses;

namespace TranscribeMe.API.SDK.Auth.Flows
{
    public class ApplicationTokenAuthorizationCodeFlow : AuthorizationCodeFlowBase
    {
        private readonly string _authToken;

        public ApplicationTokenAuthorizationCodeFlow(string authToken, FlowInitializer initializer) 
            : base(initializer)
        {
            _authToken = authToken;
        }

        public override async Task<TokenResponse> GetToken(string clientId, string clientSecret)
        {
            Client.DefaultRequestHeaders.Add(Configuration.ApiKeyHeaderName, clientId);

            var response = await Client.PostAsync("token",
                                                  new StringContent($"grant_type=applicationtoken&authtoken={_authToken}&client_id={clientId}&client_secret={clientSecret}"));
            return await response.Content.ReadAsAsync<TokenResponse>();
        }
    }
}