using System.Threading.Tasks;

namespace TranscribeMe.API.SDK.Services.Interfaces.Crud
{
    public interface IUpdateService<TResult> where TResult : class
    {
        Task<TResult> Update(TResult instance) ;
    }
}