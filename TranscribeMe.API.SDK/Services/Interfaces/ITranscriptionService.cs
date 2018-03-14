using System;
using System.Threading.Tasks;

using TranscribeMe.API.Data;

namespace TranscribeMe.API.SDK.Services.Interfaces
{
    public interface ITranscriptionService
    {
        Task<TranscriptionWorkModel> Next();

        Task<DateTime> Extend(string workItemId);

        Task Cancel(string workItemId);
    }
}