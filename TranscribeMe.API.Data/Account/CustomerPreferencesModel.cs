namespace TranscribeMe.API.Data.Account
{
    public class CustomerPreferencesModel
    {
        public string EmailLanguage { get; set; }

        public bool AttachTranscription { get; set; }

        public int AttachmentOutput { get; set; }

        public bool AttachAudio { get; set; }
    }
}