namespace TranscribeMe.API.Data
{
    public class DownloadFileModel
    {
        public string Id { get; set; }

        public string Status { get; set; }

        public string FileName { get; set; }

        public string Extension { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsAdmin { get; set; }
    }
}