using System;
using System.Net.Http;
using System.Threading.Tasks;

using TranscribeMe.API.SDK.Configurations;
using TranscribeMe.API.SDK.Responses;

namespace TranscribeMe.API.SDK.Auth.Flows
{
    public abstract class AuthorizationCodeFlowBase : IAuthorizationCodeFlow, IDisposable
    {
        private readonly FlowInitializer _initializer;

        private ITmApiConfiguration _configuration;

        private HttpClient _client;

        protected AuthorizationCodeFlowBase(FlowInitializer initializer)
        {
            _initializer = initializer;
        }

        protected ITmApiConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    if (_initializer?.ConfigurationFactory == null)
                    {
                        throw new Exception("Authorization flow wasn't properly initialized");
                    }

                    _configuration = _initializer.ConfigurationFactory.CreateConfiguration();
                }

                return _configuration;
            }
        }

        protected HttpClient Client
        {
            get
            {
                if (_client == null)
                {
                    if (_initializer?.ClientFactory == null)
                    {
                        throw new Exception("Authorization flow wasn't properly initialized");
                    }

                    _client = _initializer.ClientFactory.CreateHttpClient(Configuration.ApiUrl);
                }

                return _client;
            }
        }

        public abstract Task<TokenResponse> GetToken(string clientId, string clientSecret);

        public virtual async Task<TokenResponse> RefreshToken(string refreshToken, string clientId, string clientSecret)
        {
            Client.DefaultRequestHeaders.Add(Configuration.ApiKeyHeaderName, clientId);

            var response = await Client.PostAsync("token",
                                                  new StringContent($"grant_type=refresh_token&refresh_token={refreshToken}&client_id={clientId}&client_secret={clientSecret}"));
            return await response.Content.ReadAsAsync<TokenResponse>();
        }

        public void Dispose()
        {
            Client?.Dispose();
        }
    }
}