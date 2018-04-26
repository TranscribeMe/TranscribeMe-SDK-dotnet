using TranscribeMe.API.SDK.Services;

namespace TranscribeMe.API.SDK.Configurations
{
    public class ServiceConfigurationFactory : IServiceConfigurationFactory
    {
        public ServiceConfigurationFactory(Config mode)
        {
            ServiceMode = mode;
        }

        public Config ServiceMode { get; }

        public ITmApiConfiguration CreateConfiguration()
        {
            switch (ServiceMode)
            { 
                case Config.Sandbox:
                    return new SandboxConfiguration();
                default:
                    return new StagingConfiguration();
            }
        }
    }
}