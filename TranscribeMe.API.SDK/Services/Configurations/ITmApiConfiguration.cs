namespace TranscribeMe.API.SDK.Services.Configurations
{
    public interface ITmApiConfiguration
    {
        string ApiUrl { get; }

        string ApiKeyHeaderName { get; }
    }
}