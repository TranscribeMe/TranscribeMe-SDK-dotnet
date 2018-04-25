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
            var url = $"{_serviceUrl}?{query.GetQueryString()}";

            var response = await Client.GetAsync(url).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<ObjectsList<RecordingListItemModel>>();
        }

        public async Task<int> GetStatus(string recordingId)
        {
            var url = $"{_serviceUrl}/{recordingId}/status";

            var response = await Client.GetAsync(url).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<int>();
        }
    }
}