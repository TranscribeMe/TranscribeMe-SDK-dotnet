using System;
using System.Net.Http;

namespace TranscribeMe.API.SDK.Http
{
    public class TmHttpClientFactory : ITmHttpClientFactory 
    {
        private readonly DelegatingHandler[] _handlers;

        public TmHttpClientFactory(DelegatingHandler[] handlers)
        {
            _handlers = handlers;
        }

        public HttpClient CreateHttpClient(string apiUrl)
        {
            var client = HttpClientFactory.Create(_handlers);
            client.BaseAddress = new Uri(apiUrl);
            client.Timeout = TimeSpan.FromMinutes(5);
            return client;
        }
    }
}