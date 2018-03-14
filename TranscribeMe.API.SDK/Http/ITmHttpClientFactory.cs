using System.Net.Http;

namespace TranscribeMe.API.SDK.Http
{
    public interface ITmHttpClientFactory 
    {
        /// <summary>Creates a new configurable HTTP client.</summary>
        HttpClient CreateHttpClient(string apiUrl);
    }
}