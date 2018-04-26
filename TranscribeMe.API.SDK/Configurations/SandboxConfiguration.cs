namespace TranscribeMe.API.SDK.Configurations
{
    public class SandboxConfiguration : ITmApiConfiguration
    {
        public string ApiUrl { get; } = "https://rest-api-testing.transcribeme.com/api/v1/";

        public string ApiKeyHeaderName { get; } = "X-API-Key";
    }
}