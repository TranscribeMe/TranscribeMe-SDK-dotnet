namespace TranscribeMe.API.SDK.Configurations
{
    public interface ITmApiConfiguration
    {
        string ApiUrl { get; }

        string ApiKeyHeaderName { get; }
    }
}