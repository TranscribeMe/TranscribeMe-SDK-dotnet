using System;
using System.Net.Http;

using System.Threading;
using System.Threading.Tasks;
using TranscribeMe.API.SDK.Auth;

namespace TranscribeMe.API.SDK.Http.Handlers
{
    public class RefreshTokenDelegatingHandler : DelegatingHandler
    {
        private readonly UserCredentials _credentials;

        public RefreshTokenDelegatingHandler(UserCredentials credentials)
        {
            _credentials = credentials;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                     CancellationToken cancellationToken)
        {
            if (_credentials != null)
            {
                var t = DateTime.UtcNow.AddMinutes(5);
                if (_credentials.TokenExpiredUTC > DateTime.UtcNow && _credentials.TokenExpiredUTC <= t)
                {
                    await _credentials.RefreshTokenAsync();
                }
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}