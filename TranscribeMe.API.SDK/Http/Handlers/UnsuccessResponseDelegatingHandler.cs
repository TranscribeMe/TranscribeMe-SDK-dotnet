using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using TranscribeMe.API.SDK.Extensions;

namespace TranscribeMe.API.SDK.Http.Handlers
{
    public class UnsuccessResponseDelegatingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                     CancellationToken cancellationToken)
        {
            return await base.SendAsync(request, cancellationToken)
                             .ContinueWith(task =>
                                               {
                                                   task.Result.EnsureSuccessResponse();
                                                   return task.Result;
                                               },
                                           cancellationToken);
        }
    }
}