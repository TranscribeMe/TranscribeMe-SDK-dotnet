using TranscribeMe.API.SDK.Http;
using TranscribeMe.API.SDK.Services.Configurations;

namespace TranscribeMe.API.SDK.Auth.Flows
{
    public class FlowInitializer
    {
        public FlowInitializer(IServiceConfigurationFactory configurationFactory,
                               ITmHttpClientFactory clientFactory)
        {
            ConfigurationFactory = configurationFactory;
            ClientFactory = clientFactory;
        }

        public IServiceConfigurationFactory ConfigurationFactory { get; set; }

        public ITmHttpClientFactory ClientFactory { get; set; }
    }
}