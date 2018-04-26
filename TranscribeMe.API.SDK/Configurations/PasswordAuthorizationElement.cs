using System.Configuration;

namespace TranscribeMe.API.SDK.Configurations
{
    public class PasswordAuthorizationElement : ConfigurationElement
    {
        [ConfigurationProperty("userName", IsRequired = true)]
        public string UserName
        {
            get => (string)this["userName"];
            set => this["userName"] = value;
        }

        [ConfigurationProperty("password", IsRequired = true)]
        public string Password
        {
            get => (string)this["password"];
            set => this["password"] = value;
        }
    }
}