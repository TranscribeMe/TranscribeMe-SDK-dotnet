namespace TranscribeMe.API.SDK.Auth
{
    public class ApplicationCredentials
    {
        public ApplicationCredentials(string clientId, string secret)
        {
            ClientId = clientId;
            Secret = secret;
        }

        public string ClientId { get; private set; }

        public string Secret { get; private set; }
    }
}