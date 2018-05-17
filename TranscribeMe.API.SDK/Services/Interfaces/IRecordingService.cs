using System.IO;
using System.Threading.Tasks;

using TranscribeMe.API.SDK.Services.Interfaces.Crud;
using TranscribeMe.API.Data.Queries;
using TranscribeMe.API.Data.Recordings;

namespace TranscribeMe.API.SDK.Services.Interfaces
{
    public interface IRecordingService : IQueryService<RecordingsQuery, ObjectsList<RecordingListItemModel>>
    {
        Task<int> GetStatus(string recordingId);

        Task<Stream> GetResult(string recordingId, string format);

        Task GetResult(string recordingId, string format, string outputPath);

        Task GetResult(string recordingId, string format, Stream outputStream);
    }
}