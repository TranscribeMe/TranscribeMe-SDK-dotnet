using System;
using System.Threading.Tasks;

using TranscribeMe.API.SDK.Auth.Flows;
using TranscribeMe.API.SDK.Configurations;

namespace TranscribeMe.API.SDK.Auth
{
    public class UserCredentials
    {
        #region Initializer

        public class Initializer
        {
            public ApplicationCredentials Secret { get; set; }

            public IAuthorizationCodeFlow AuthCodeFlow { get; set; }

            public IServiceConfigurationFactory ConfigurationFactory { get; private set; }

            public Initializer(IAuthorizationCodeFlow authCodeFlow,
                               ApplicationCredentials secret,
                               IServiceConfigurationFactory configurationFactory)
            {
                Secret = secret;
                AuthCodeFlow = authCodeFlow;
                ConfigurationFactory = configurationFactory;
            }
        }

        #endregion 

        public string Token { get; set; }
        public string UserId { get; set; }

        public DateTime TokenExpiredUTC { get; set; }
        public ITmApiConfiguration ApiConfig { get; set; }

        protected string RefreshToken { get; set; }

        private readonly IAuthorizationCodeFlow _flow;

        private readonly ApplicationCredentials _secret;

        public UserCredentials(Initializer initializer)
        {
            _flow = initializer.AuthCodeFlow;
            _secret = initializer.Secret;
            ApiConfig = initializer.ConfigurationFactory.CreateConfiguration();
        }

        public ApplicationCredentials Application => _secret;

        public async Task GetTokenAsync()
        {
            var response = await _flow.GetToken(_secret.ClientId, _secret.Secret);
            Token = response.AccessToken;
            RefreshToken = response.RefreshToken;
            UserId = response.UserId;
            TokenExpiredUTC = response.ExpiresUtc;
        }

        public async Task RefreshTokenAsync()
        {
            var response = await _flow.RefreshToken(RefreshToken, _secret.ClientId, _secret.Secret);
            RefreshToken = response.RefreshToken;
            TokenExpiredUTC = response.ExpiresUtc;
        }
    }
}