using System;
using System.Threading.Tasks;
using System.Net.Http;

using TranscribeMe.API.Data;
using TranscribeMe.API.SDK.Services.Interfaces;

namespace TranscribeMe.API.SDK.Services
{
    public class TranscriptionsService : BaseService, ITranscriptionService
    {
        private readonly string _serviceUrl = "workitems/transcriptions";

        public TranscriptionsService(Initializer initializer)
            : base(initializer)
        {
        }

        public async Task<TranscriptionWorkModel> Next()
        {
            var response = await Client.GetAsync($"{_serviceUrl}/{"actions/next"}");
            return await response.Content.ReadAsAsync<TranscriptionWorkModel>();
        }

        public async Task<DateTime> Extend(string workItemId)
        {
            var response = await Client.PutAsync($"workitems/transcriptions/{workItemId}/actions/extend", null);
            return await response.Content.ReadAsAsync<DateTime>();
        }

        public async Task Cancel(string workItemId)
        {
            var response = await Client.PutAsync($"workitems/transcriptions/{workItemId}/actions/cancel", null);
        }
    }
}