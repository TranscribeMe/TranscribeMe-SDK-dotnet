using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

using TranscribeMe.API.Data.Upload;
using TranscribeMe.API.SDK.Exceptions;
using TranscribeMe.API.SDK.Services.Interfaces;

namespace TranscribeMe.API.SDK.Services
{
    public class UploadService : BaseService, IUploadService
    {
        private const int UploadChunkSize = 5242880;

        private readonly string _serviceUrl = "uploads";

        public UploadService(Initializer initializer)
            : base(initializer)
        {
        }

        public async Task<string> Upload(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path), "Path parameter should be passed.");
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Unable to find provided file", path);
            }

            var fileName = Path.GetFileName(path);

            using (var fileStream = File.OpenRead(path))
            {
                var isAsync = false; //fileStream.Length > UploadChunkSize;

                var model = await GetUploadUrl(fileName, isAsync).ConfigureAwait(false);

                if (model == null || model.Url == null || string.IsNullOrWhiteSpace(model.Url.ToString()))
                {
                    throw new TmSdkServiceException("Upload initialization error");
                }

                var queryDictionary = HttpUtility.ParseQueryString(model.Url.Query);

                var recordingId = queryDictionary["recordingId"];
                var uploadId = queryDictionary["uploadId"];

                if (isAsync)
                {
                    await ProcessAsyncUpload(uploadId, recordingId, fileName, fileStream);
                }
                else
                {
                    await ProcessSyncUpload(recordingId, fileName, fileStream);
                }

                return recordingId;
            }
        }

        public async Task<UploadRedirectModel> GetUploadUrl(string fileName, bool isAsync = false)
        {
            var url = $"{_serviceUrl}/url?fileName={fileName}&isAsync={isAsync}";

            var response = await Client.GetAsync(url).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<UploadRedirectModel>();
        }

        private async Task<HttpStatusCode> UploadChunk(string uploadId, string recordingId, int chunkNumber, Stream stream)
        {
            var url =
                $"{_serviceUrl}/async?uploadId={uploadId}&recordingId={recordingId}&chunkNumber={chunkNumber}";

            var content = new StreamContent(stream);

            var response = await Client.PostAsync(url, content).ConfigureAwait(false);

            return response.StatusCode;
        }

        private async Task<HttpStatusCode> CommitAsyncUpload(string uploadId, string recordingId)
        {
            var url =
                $"{_serviceUrl}/async/commit?uploadId={uploadId}&recordingId={recordingId}";

            var response = await Client.PostAsync(url, new StringContent(string.Empty)).ConfigureAwait(false);

            return response.StatusCode;
        }

        private async Task<HttpStatusCode> CommitSyncUpload(string recordingId, HttpContent content)
        {
            var url = $"{_serviceUrl}/sync?recordingId={recordingId}";

            var response = await Client.PostAsync(url, content).ConfigureAwait(false);

            return response.StatusCode;
        }

        private async Task ProcessAsyncUpload(string uploadId,
                                              string recordingId,
                                              string fileName,
                                              Stream fileStream)
        {
            var chunksCount = (int)Math.Ceiling(fileStream.Length / (double)UploadChunkSize);
            for (var i = 0; i < chunksCount; i++)
            {
                using (var inputStream = new MemoryStream())
                {
                    var bufferSize = i < chunksCount - 1
                                         ? UploadChunkSize
                                         : fileStream.Length - UploadChunkSize * (chunksCount - 1);
                    var buffer = new byte[bufferSize];

                    fileStream.Read(buffer, 0, buffer.Length);

                    inputStream.Write(buffer, 0, buffer.Length);
                    inputStream.Seek(0, SeekOrigin.Begin);

                    var chunkUploadResult = await UploadChunk(uploadId,
                                                              recordingId,
                                                              UploadChunkSize,
                                                              inputStream).ConfigureAwait(false);
                    if (chunkUploadResult != HttpStatusCode.OK)
                    {
                        throw new TmSdkServiceException($"Error during upload! File: {fileName}");
                    }
                }
            }

            var commitResult = await CommitAsyncUpload(uploadId, recordingId).ConfigureAwait(false);
            if (commitResult != HttpStatusCode.OK)
            {
                throw new TmSdkServiceException($"Error during upload! File: {fileName}");
            }
        }

        private async Task ProcessSyncUpload(string recordingId, string fileName, Stream fileStream)
        {
            using (var content = new MultipartFormDataContent(fileName))
            {
                content.Add(new StreamContent(fileStream), fileName, fileName);

                var commitResult = await CommitSyncUpload(recordingId, content).ConfigureAwait(false);
                if (commitResult != HttpStatusCode.OK)
                {
                    throw new TmSdkServiceException($"Error during upload! File: {fileName}");
                }
            }
        }
    }
}