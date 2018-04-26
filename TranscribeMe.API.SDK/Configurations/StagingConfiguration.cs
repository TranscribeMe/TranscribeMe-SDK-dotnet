namespace TranscribeMe.API.SDK.Configurations
{
    public class StagingConfiguration : ITmApiConfiguration
    {
        public string ApiUrl { get; } = "https://rest-api.transcribeme.com/api/v1/";

        public string ApiKeyHeaderName { get; } = "X-API-Key";
    }
}