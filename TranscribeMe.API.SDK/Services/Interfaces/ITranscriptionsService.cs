using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranscribeMe.API.SDK.Services.Interfaces.Crud;
using TranscribeMe.API.Data;

namespace TranscribeMe.API.SDK.Services.Interfaces
{
    public interface ITranscriptionsService 
    {
        Task<TranscriptionWorkModel> Next();
        Task<DateTime> Extend(string workItemId);
        Task Cancel(string workItemId);
    }
}
