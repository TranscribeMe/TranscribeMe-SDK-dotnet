using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

using TranscribeMe.API.SDK.Auth;

namespace TranscribeMe.API.SDK.Http.Handlers
{
    public class AuthHeaderDelegatingHandler : DelegatingHandler
    {
        private readonly UserCredentials _credentials;

        public AuthHeaderDelegatingHandler(UserCredentials credentials)
        {
            _credentials = credentials;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                     CancellationToken cancellationToken)
        {
            if (_credentials != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _credentials.Token);
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}