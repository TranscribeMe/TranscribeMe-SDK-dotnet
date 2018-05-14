using System.Net.Http;
using System.Threading.Tasks;

using TranscribeMe.API.Data;
using TranscribeMe.API.Data.Queries;
using TranscribeMe.API.SDK.Extensions;
using TranscribeMe.API.SDK.Services.Interfaces;

namespace TranscribeMe.API.SDK.Services
{
    public class FoldersService : BaseService, IFolderService
    {
        private readonly string _serviceUrl = "folders";

        public FoldersService(Initializer initializer)
            : base(initializer)
        {
        }

        public async Task<FolderModel> Create(FolderModel instance)
        {
            var response = await Client.PostAsJsonAsync(_serviceUrl, instance);
            return await response.Content.ReadAsAsync<FolderModel>();
        }

        public async Task Delete(string instanceId)
        {
            var url = $"{_serviceUrl}/{instanceId}";

            await Client.DeleteAsync(url);
        }

        public async Task<ObjectsList<FolderModel>> Get(FoldersQuery query)
        {
            var response = await Client.GetAsync($"{_serviceUrl}?{query.GetQueryString()}");
            return await response.Content.ReadAsAsync<ObjectsList<FolderModel>>();
        }

        public async Task<FolderModel> Update(FolderModel instance)
        {
            var response = await Client.PutAsJsonAsync(_serviceUrl, instance);
            return await response.Content.ReadAsAsync<FolderModel>();
        }
    }
}