namespace TranscribeMe.API.SDK.Services.Configurations
{
    public class StagingConfiguration : ITmApiConfiguration
    {
        public string ApiUrl { get; } = "http://tmhub.cloudapp.net:8081/api/v1/";

        public string ApiKeyHeaderName { get; } = "X-API-Key";
    }
}