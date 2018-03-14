using System.Net.Http;
using System.Threading.Tasks;

using TranscribeMe.API.Data;
using TranscribeMe.API.SDK.Services.Interfaces;

namespace TranscribeMe.API.SDK.Services
{
    public class CustomersRegistrationService : BaseService, IRegistrationService
    {
        public CustomersRegistrationService(Initializer initializer)
            : base(initializer)
        {
        }

        public async Task<bool> Register(UserModel instance)
        {
            var response = await Client.PostAsJsonAsync("customers", instance);
            var c = await response.Content.ReadAsStringAsync();
            return true;

        }

        public async Task Activate(string activationKey)
        {
            await Client.PutAsync($"users/{activationKey}/actions/activate", null);
        }
    }
}