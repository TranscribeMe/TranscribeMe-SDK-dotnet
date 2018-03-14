namespace TranscribeMe.API.Data.Recordings
{
    public class RecordingDetailsModel : RecordingListItemModel
    {
        public string Description { get; set; }

        public string Url { get; set; }

        public string PublicKey { get; set; }
    }
}