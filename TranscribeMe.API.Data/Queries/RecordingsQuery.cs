using System;

using TranscribeMe.API.Data.Recordings;

namespace TranscribeMe.API.Data.Queries
{
    public class RecordingsQuery : PageableFilterQueryBase<ObjectsList<RecordingListItemModel>>
    {
        private const string DefaultFolder = "0";

        public string Folder { get; set; }

        public int? Status { get; set; }

        public string User { get; set; }

        public bool IsDefaultFolder => !string.IsNullOrWhiteSpace(Folder) &&
                                       Folder.Equals(DefaultFolder, StringComparison.OrdinalIgnoreCase);
    }
}