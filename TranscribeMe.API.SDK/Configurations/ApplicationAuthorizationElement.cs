using System.Configuration;

namespace TranscribeMe.API.SDK.Configurations
{
    public class ApplicationAuthorizationElement : ConfigurationElement
    {
        [ConfigurationProperty("clientId", IsRequired = true)]
        public string ClientId
        {
            get => (string)this["clientId"];
            set => this["clientId"] = value;
        }

        [ConfigurationProperty("secret", IsRequired = true)]
        public string ClientSecret
        {
            get => (string)this["secret"];
            set => this["secret"] = value;
        }
    }
}