using System.Threading.Tasks;

using TranscribeMe.API.Data;

namespace TranscribeMe.API.SDK.Services.Interfaces
{
    public interface IRegistrationService
    {
        Task Activate(string activationKey);

        Task<bool> Register(UserModel instance);
    }
}