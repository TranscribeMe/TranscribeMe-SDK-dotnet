using System;
using System.Collections.Generic;

namespace TranscribeMe.API.Data
{
    public class ArchiveFileModel : DownloadFileModel
    {
        public List<TranscriptFileModel> ArchiveContent { get; set; }

        public string OwnerId { get; set; }

        public DateTime Created { get; set; }

        public bool IsInProcess { get; set; }
    }
}