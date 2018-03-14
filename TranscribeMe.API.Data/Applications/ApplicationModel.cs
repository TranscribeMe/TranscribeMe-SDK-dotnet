using System.ComponentModel.DataAnnotations;

namespace TranscribeMe.API.Data.Applications
{
    public class ApplicationModel : ApplicationListItemModel
    {
        public int ApplicationType { get; set; }

        public string AllowedOrigin { get; set; }

        [MinLength(32, ErrorMessage = "API_KEY_MIN_LENGTH_ERROR"),
         MaxLength(128, ErrorMessage = "API_KEY_MAX_LENGTH_ERROR")]
        public string ApiKey { get; set; }

        public string TechContactEmail { get; set; }

        public string TechContactName { get; set; }

        public string TechContactNotes { get; set; }
    }
}