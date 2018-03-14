using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using TranscribeMe.API.Data.Upload;
using TranscribeMe.API.SDK.Services.Interfaces;

namespace TranscribeMe.API.SDK.Services
{
    public class UploadService : BaseService, IUploadService
    {
        private readonly string _serviceUrl = "uploads";

        public UploadService(Initializer initializer)
            : base(initializer)
        {
        }

        public async Task<UploadRedirectModel> GetUploadUrl(string fileName, bool isAsync = false)
        {
            var url = $"{_serviceUrl}/url?fileName={fileName}&isAsync={isAsync}";

            var response = await Client.GetAsync(url);
            return await response.Content.ReadAsAsync<UploadRedirectModel>();
        }

        public async Task<HttpStatusCode> UploadChunk(string uploadId, string recordingId, int chunkNumber, Stream stream)
        {
            var url =
                $"{_serviceUrl}/async?uploadId={uploadId}&recordingId={recordingId}&chunkNumber={chunkNumber}";

            var content = new StreamContent(stream);

            var response = await Client.PostAsync(url, content);

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> CommitAsyncUpload(string uploadId, string recordingId)
        {
            var url =
                $"{_serviceUrl}/async/commit?uploadId={uploadId}&recordingId={recordingId}";

            var response = await Client.PostAsync(url, new StringContent(string.Empty));

            return response.StatusCode;
        }
    }
}