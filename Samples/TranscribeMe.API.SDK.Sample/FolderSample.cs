using TranscribeMe.API.Data;
using TranscribeMe.API.SDK.Auth;
using TranscribeMe.API.SDK.Services;

namespace TranscribeMe.API.SDK.Sample
{
    public class FolderSample
    {
        private readonly FoldersService _service;

        public FolderSample(UserCredentials credentials)
        {
            _service = new FoldersService(new BaseService.Initializer(credentials));
        }

        public FolderModel CreateFolder()
        {
            return _service.Create(new FolderModel
                                       {
                                           Name = "Test Folder 2",
                                           Description = "Some description"
                                       }).Result;
        }

        public void DeleteFolder(FolderModel folder)
        {
            _service.Delete(folder.Id).RunSynchronously();
        }

        public FolderModel UpdateFolder(FolderModel folder)
        {
            return _service.Update(folder).Result;
        }
    }
}