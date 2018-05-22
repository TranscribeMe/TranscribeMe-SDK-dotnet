using System.Threading.Tasks;

using TranscribeMe.API.Data.Upload;

namespace TranscribeMe.API.SDK.Services.Interfaces
{
    public interface IUploadService
    {
        Task<string> Upload(string filePath);

        Task<UploadRedirectModel> GetUploadUrl(string fileName, bool isAsync = false);
    }
}