namespace TranscribeMe.API.Data.Queries
{
    public class FoldersQuery : IFilterQuery<ObjectsList<FolderModel>>
    {
        public string UserId { get; set; }
    }
}