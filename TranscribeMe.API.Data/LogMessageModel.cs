using System.ComponentModel.DataAnnotations;

namespace TranscribeMe.API.Data
{
    public class LogMessageModel
    {
        public string ClientAppId { get; set; }

        [Required(ErrorMessage = "Log message is required")]
        public string Message { get; set; }
    }
}