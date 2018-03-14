using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TranscribeMe.API.SDK.Services.Interfaces.Crud;
using TranscribeMe.API.Data;
using TranscribeMe.API.Data.Queries;

namespace TranscribeMe.API.SDK.Services.Interfaces
{
    public interface IRecordingsService : IQueryService<RecordingsQuery, ObjectsList<RecordingModel>>
    {
    }
}
