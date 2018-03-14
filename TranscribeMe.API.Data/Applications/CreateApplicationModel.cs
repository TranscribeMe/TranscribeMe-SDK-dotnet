namespace TranscribeMe.API.Data.Applications
{
    public class CreateApplicationModel : ApplicationModel
    {
        public string Secret { get; set; }

        public string OwnerId { get; set; }
    }
}