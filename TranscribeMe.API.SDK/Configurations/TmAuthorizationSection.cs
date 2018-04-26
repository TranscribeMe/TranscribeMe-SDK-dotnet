using System.Configuration;

using TranscribeMe.API.SDK.Services;

namespace TranscribeMe.API.SDK.Configurations
{
    public class TmAuthorizationSection : ConfigurationSection
    {
        [ConfigurationProperty("application", IsRequired = true)]
        public ApplicationAuthorizationElement Application
        {
            get => (ApplicationAuthorizationElement)this["application"];
            set => this["application"] = value;
        }

        [ConfigurationProperty("credentials", IsRequired = false)]
        public PasswordAuthorizationElement Credentials
        {
            get => (PasswordAuthorizationElement)this["credentials"];
            set => this["credentials"] = value;
        }

        [ConfigurationProperty("token", IsRequired = false)]
        public TokenAuthorizationElement Token
        {
            get => (TokenAuthorizationElement)this["token"];
            set => this["token"] = value;
        }

        [ConfigurationProperty("apiConfigType", DefaultValue =  Config.Sandbox, IsRequired = true)]
        public Config ApiConfigType
        {
            get => (Config)this["apiConfigType"];
            set => this["apiConfigType"] = value;
        }
    }
}