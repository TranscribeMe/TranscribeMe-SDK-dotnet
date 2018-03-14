using System.Net.Http;
using System.Threading.Tasks;

using TranscribeMe.API.SDK.Responses;

namespace TranscribeMe.API.SDK.Auth.Flows
{
    public class FacebookAuthorizationCodeFlow : AuthorizationCodeFlowBase
    {
        private readonly string _authToken;
        private readonly string _userRole;

        private readonly string _providerName = "Facebook";

        public FacebookAuthorizationCodeFlow(string authToken, string userRole, FlowInitializer initializer) 
            : base(initializer)
        {
            _authToken = authToken;
            _userRole = userRole;
        }

        public override async Task<TokenResponse> GetToken(string clientId, string clientSecret)
        {
            var response = await Client.PostAsync("token", new StringContent($"grant_type=externaltoken&authtoken={_authToken}&provider={_providerName}&role={_userRole}&client_id={clientId}&client_secret={clientSecret}"));
            return await response.Content.ReadAsAsync<TokenResponse>();
        }
    }
}