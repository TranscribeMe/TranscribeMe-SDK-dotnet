using System.Threading.Tasks;

namespace TranscribeMe.API.SDK.Services.Interfaces.Crud
{
    public interface ICreateService<TResult> where TResult : class
    {
        Task<TResult> Create(TResult instance);
    }
}