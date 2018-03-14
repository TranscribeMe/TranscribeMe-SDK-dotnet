using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using TranscribeMe.API.SDK.Extensions;
using TranscribeMe.API.SDK.Auth;
using TranscribeMe.API.SDK.Responses;
using TranscribeMe.API.Data;
using TranscribeMe.API.SDK.Services.Interfaces;

namespace TranscribeMe.API.SDK.Services
{
    public class UploadLinksService : BaseService, IUploadLinksService
    {
        private readonly string _serviceUrl = "uploadlinks";

        public UploadLinksService(BaseService.Initializer initializer)
            : base(initializer)
        {
        }
        public async Task<Uri> GenerateUploadUri(UploadLinkRequestModel uploadLinkRequest)
        {
            var response = await Client.PostAsJsonAsync<UploadLinkRequestModel>(_serviceUrl, uploadLinkRequest);
            return await response.Content.ReadAsAsync<Uri>();
        }
    }
}
