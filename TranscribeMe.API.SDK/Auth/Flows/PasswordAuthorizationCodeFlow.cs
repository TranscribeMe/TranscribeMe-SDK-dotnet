using System.Net.Http;
using System.Threading.Tasks;

using TranscribeMe.API.SDK.Responses;

namespace TranscribeMe.API.SDK.Auth.Flows
{
    public class PasswordAuthorizationCodeFlow : AuthorizationCodeFlowBase
    {
        private readonly string _userName;
        private readonly string _password;

        public PasswordAuthorizationCodeFlow(string userName, string password, FlowInitializer initializer) 
            : base(initializer)
        {
            _userName = userName;
            _password = password;
        }

        public override async Task<TokenResponse> GetToken(string clientId, string clientSecret)
        {
            Client.DefaultRequestHeaders.Add(Configuration.ApiKeyHeaderName, clientId);

            var response = await Client.PostAsync("token",
                                                  new StringContent($"grant_type=password&username={_userName}&password={_password}&client_id={clientId}&client_secret={clientSecret}"));
            return await response.Content.ReadAsAsync<TokenResponse>();
        }
    }
}