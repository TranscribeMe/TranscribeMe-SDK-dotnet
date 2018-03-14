using System.Net.Http;
using System.Threading.Tasks;

using TranscribeMe.API.Data;
using TranscribeMe.API.SDK.Services.Interfaces;

namespace TranscribeMe.API.SDK.Services
{
    public class TranscriptionResultsService : BaseService, ITranscriptionResultsService
    {
        private readonly string _serviceUrl = "workitems/transcriptions/{0}/results";

        public TranscriptionResultsService(Initializer initializer, string workItemId)
            : base(initializer)
        {
            ServiceUrl = string.Format(_serviceUrl, workItemId);
        }

        private string ServiceUrl { get; set; }

        public async Task<TranscriptionWorkResultModel> Create(TranscriptionWorkResultModel instance)
        {
            var response = await Client.PostAsJsonAsync(ServiceUrl, instance);
            return await response.Content.ReadAsAsync<TranscriptionWorkResultModel>();
        }
    }
}