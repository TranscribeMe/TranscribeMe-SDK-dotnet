using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;

using TranscribeMe.API.SDK.Responses;

namespace TranscribeMe.API.SDK.Http.Handlers
{
    public class ServiceResponseDelegatingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                     CancellationToken cancellationToken)
        {
            return await base.SendAsync(request, cancellationToken)
                             .ContinueWith(task =>
                                               {
                                                   var result = new HttpResponseMessage(task.Result.StatusCode);
                                                   var responseObject = new ServiceResponse<object>(task.Result);
                                                   result.Content = new ObjectContent<ServiceResponse<object>>(responseObject, new JsonMediaTypeFormatter());
                                                   return result;
                                               },
                                           cancellationToken);
        }
    }
}