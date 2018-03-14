namespace TranscribeMe.API.SDK.Services.Configurations
{
    public class ServiceConfigurationFactory : IServiceConfigurationFactory
    {

        public ServiceConfigurationFactory(Config mode)
        {
            ServiceMode = mode;
        }

        public Config ServiceMode
        {
            get;
            private set;
        }

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
