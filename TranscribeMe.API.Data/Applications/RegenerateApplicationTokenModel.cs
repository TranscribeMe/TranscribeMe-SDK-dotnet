using System.ComponentModel;

namespace TranscribeMe.API.Data.Applications
{
    public class RegenerateApplicationTokenModel
    {
        [Description("Current application retrieved from x-api-key header will be used in case none is provided")]
        public string ApplicationId { get; set; }
    }
}