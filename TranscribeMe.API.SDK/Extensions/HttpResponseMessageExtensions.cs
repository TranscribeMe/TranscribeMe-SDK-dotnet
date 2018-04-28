using System.Linq;
using System.Net.Http;

using Newtonsoft.Json.Linq;

using TranscribeMe.API.Data.Errors;
using TranscribeMe.API.SDK.Exceptions;

namespace TranscribeMe.API.SDK.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static void EnsureSuccessResponse(this HttpResponseMessage response)
        {
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                var content = response.Content.ReadAsAsync<JObject>().Result;

                if (content.Value<string>("error") != null &&
                    content.Value<string>("error_description") != null)
                {
                    throw new TmApiException(response.StatusCode,
                                             new[] { content.Value<string>("error_description") },
                                             content.Value<string>("error"));
                }
                else
                {
                    var errorObj = content.ToObject<UnsuccessResponse>();
                    if (errorObj.Messages != null)
                    {
                        throw new TmApiException(response.StatusCode,
                                                 errorObj.Messages.Select(item => item.Message).ToArray(),
                                                 "Web Api error(s)");
                    }
                }
                throw new TmApiException(response.StatusCode,
                                         new[] { content.ToString() },
                                         "Unknown Api error");
            }
            finally
            {
                if (!response.IsSuccessStatusCode)
                {
                    response.Content?.Dispose();
                }
            }
        }
    }
}