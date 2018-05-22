using System.Net.Http;

using TranscribeMe.API.SDK.Http;
using TranscribeMe.API.SDK.Http.Handlers;
using TranscribeMe.API.SDK.Auth;
using TranscribeMe.API.SDK.Configurations;

namespace TranscribeMe.API.SDK.Services
{
    public class BaseService
    {
        #region Initializer

        public class Initializer
        {
            public UserCredentials Credentials { get; private set; }

            public ITmApiConfiguration Configuration { get; set; }
            public ITmHttpClientFactory ClientFactory { get; private set; }

            public Initializer(UserCredentials credentials)
            {
                ClientFactory =
                    new TmHttpClientFactory(new DelegatingHandler[]
                                                {
                                                    new UnsuccessResponseDelegatingHandler(),
                                                    new AuthHeaderDelegatingHandler(credentials),
                                                    new RefreshTokenDelegatingHandler(credentials)
                                                });
                Configuration = credentials.ApiConfig;

                Credentials = credentials;
            }
        }

        #endregion

        private readonly UserCredentials _credentials;

        private static volatile HttpClient _client;

        private static object syncRoot = new object();

        protected static HttpClient Client => _client;

        public BaseService(Initializer initializer)
        {
            _credentials = initializer.Credentials;

            if (_client == null)
            {
                lock (syncRoot)
                {
                    _client = initializer.ClientFactory.CreateHttpClient(initializer.Configuration.ApiUrl);

                    var headerName = initializer.Configuration.ApiKeyHeaderName;
                    var headerValue = _credentials.Application.ClientId;

                    _client.DefaultRequestHeaders.Add(headerName, headerValue);
                }
            }
        }
    }
}