using System.Collections.Generic;

namespace TranscribeMe.API.Data.Recordings
{
    public class SharedRecordingDetailsModel
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public double Duration { get; set; }

        public string Url { get; set; }

        public List<DictionaryItemModel> Output { get; set; }
    }
}