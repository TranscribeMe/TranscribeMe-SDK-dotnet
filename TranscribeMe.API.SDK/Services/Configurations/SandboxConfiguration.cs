namespace TranscribeMe.API.SDK.Services.Configurations
{
    public class SandboxConfiguration : ITmApiConfiguration
    {
        public string ApiUrl { get; } = "http://host.url";

        public string ApiKeyHeaderName { get; } = "X-API-Key";
    }
}