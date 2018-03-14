using System.Collections.Generic;

namespace TranscribeMe.API.Data.Recordings
{
    public class RecordingsBatchOperationModel
    {
        public RecordingsBatchOperationModel()
        {
            Ids = new List<string>();
        }

        public IList<string> Ids { get; set; }
    }
}