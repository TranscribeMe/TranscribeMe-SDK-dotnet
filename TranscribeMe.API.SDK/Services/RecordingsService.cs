using System;
using System.IO;
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

        public async Task<Stream> GetResult(string recordingId, string format)
        {
            var url = $"{_serviceUrl}/{recordingId}/transcription/{format}";

            var response = await Client.GetAsync(url).ConfigureAwait(false);
            var result = await response.Content.ReadAsStreamAsync();

            if (result != null && result.CanSeek)
            {
                result.Seek(0, SeekOrigin.Begin);
            }

            return result;
        }

        public async Task GetResult(string recordingId, string format, Stream outputStream)
        {
            if (outputStream == null)
            {
                throw new ArgumentNullException(nameof(outputStream));
            }
            var stream = await GetResult(recordingId, format);
            if (stream != null)
            {
                if (outputStream.CanSeek)
                {
                    outputStream.Seek(0, SeekOrigin.Begin);
                }

                await stream.CopyToAsync(outputStream);
            }
        }

        public async Task GetResult(string recordingId, string format, string outputPath)
        {
            using (var outputStream = File.OpenWrite(outputPath))
            {
                await GetResult(recordingId, format, outputStream);
            }
        }
    }
}