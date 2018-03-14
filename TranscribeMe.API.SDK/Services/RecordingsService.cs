using System.Net.Http;
using System.Threading.Tasks;

using TranscribeMe.API.Data.Queries;
using TranscribeMe.API.Data.Recordings;
using TranscribeMe.API.SDK.Extensions;
using TranscribeMe.API.SDK.Services.Interfaces;

namespace TranscribeMe.API.SDK.Services
{
    public class RecordingsService : BaseService, IRecordingService
    {
        private readonly string _serviceUrl = "recordings";

        public RecordingsService(Initializer initializer)
            : base(initializer)
        {
        }

        public async Task<ObjectsList<RecordingListItemModel>> Get(RecordingsQuery query)
        {
            //var rM = new HttpRequestMessage(HttpMethod.Get, _serviceUrl)
            //             {
            //                 Content = new ObjectContent<RecordingsQuery>(query, new JsonMediaTypeFormatter())
            //             };

            var response = await Client.GetAsync($"{_serviceUrl}?{query.GetQueryString()}");
            return await response.Content.ReadAsAsync<ObjectsList<RecordingListItemModel>>();
        }
    }
}