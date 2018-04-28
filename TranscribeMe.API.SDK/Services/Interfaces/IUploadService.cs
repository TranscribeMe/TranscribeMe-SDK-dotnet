using System.IO;
using System.Net;
using System.Threading.Tasks;

using TranscribeMe.API.Data.Upload;

namespace TranscribeMe.API.SDK.Services.Interfaces
{
    public interface IUploadService
    {
        Task<UploadRedirectModel> GetUploadUrl(string fileName, bool isAsync = false);

        Task<HttpStatusCode> UploadChunk(string uploadId, string recordingId, int chunkNumber, Stream stream);

        Task<HttpStatusCode> CommitAsyncUpload(string uploadId, string recordingId);

        Task<string> Upload(string recordingId);
    }
}