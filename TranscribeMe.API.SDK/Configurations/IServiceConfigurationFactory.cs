namespace TranscribeMe.API.SDK.Configurations
{
    public interface IServiceConfigurationFactory
    {
        ITmApiConfiguration CreateConfiguration();
    }
}