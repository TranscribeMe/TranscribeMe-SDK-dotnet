namespace TranscribeMe.API.Data.Applications
{
    public class EditApplicationModel
    {
        public string Description { get; set; }

        public string AllowedOrigin { get; set; }

        public string TechContactEmail { get; set; }

        public string TechContactName { get; set; }

        public string TechContactNotes { get; set; }
    }
}