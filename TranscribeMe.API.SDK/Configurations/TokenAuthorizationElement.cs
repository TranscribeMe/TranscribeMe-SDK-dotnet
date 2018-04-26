using System.Configuration;

namespace TranscribeMe.API.SDK.Configurations
{
    public class TokenAuthorizationElement : ConfigurationElement
    {
        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get => (string)this["value"];
            set => this["value"] = value;
        }
    }
}