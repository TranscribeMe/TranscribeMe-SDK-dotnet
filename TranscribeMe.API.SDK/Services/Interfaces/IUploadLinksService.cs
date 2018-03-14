using System;
using System.Threading.Tasks;
using TranscribeMe.API.Data;
using TranscribeMe.API.SDK.Services.Interfaces.Crud;

namespace TranscribeMe.API.SDK.Services.Interfaces
{
    public interface IUploadLinksService 
    {
        Task<Uri> GenerateUploadUri (UploadLinkRequestModel uploadLinkRequest);
    }
}
