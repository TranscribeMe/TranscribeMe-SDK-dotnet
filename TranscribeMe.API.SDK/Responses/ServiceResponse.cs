using System.Net.Http;

namespace TranscribeMe.API.SDK.Responses
{
    public class ServiceResponse<T> where T : class
    {
        public bool Success { get; set; }

        public string[] Messages { get; set; }

        public T Data { get; set; }

        public ServiceResponse()
        {
        }

        public ServiceResponse(HttpResponseMessage httpResponse)
        {
            Success = httpResponse.IsSuccessStatusCode;
            if (httpResponse.Content != null)
            {
                if (httpResponse.IsSuccessStatusCode)
                {
                    Data = httpResponse.Content.ReadAsAsync<T>().Result;
                }
                else
                {
                    // DO THIS !!
                }
            }
        }
    }
}