using TranscribeMe.API.Data;
using TranscribeMe.API.Data.Queries;
using TranscribeMe.API.SDK.Services.Interfaces.Crud;

namespace TranscribeMe.API.SDK.Services.Interfaces
{
    public interface IFolderService : IQueryService<FoldersQuery, ObjectsList<FolderModel>>,
                                      ICreateService<FolderModel>,
                                      IDeleteService,
                                      IUpdateService<FolderModel>
    {
    }
}