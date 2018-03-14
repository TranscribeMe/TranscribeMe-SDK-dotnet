using System.Threading.Tasks;

using TranscribeMe.API.Data.Queries;

namespace TranscribeMe.API.SDK.Services.Interfaces.Crud
{
    public interface IQueryService<TQuery, TResult> where TQuery : IFilterQuery<TResult>
    {
        Task<TResult> Get(TQuery query);
    }
}