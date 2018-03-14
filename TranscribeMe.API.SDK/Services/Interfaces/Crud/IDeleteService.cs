using System.Threading.Tasks;

namespace TranscribeMe.API.SDK.Services.Interfaces.Crud
{
    public interface IDeleteService
    {
        Task Delete(string instanceId);
    }
}