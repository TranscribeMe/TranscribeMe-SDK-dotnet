using TranscribeMe.API.SDK.Auth;

namespace TranscribeMe.API.SDK.Sample
{
    public class AuthorizeWithFacebook
    {
        public static void Sample()
        {
            ApplicationCredentials secret = new ApplicationCredentials("", "");
            var credentials = TmApiWebAuthorizationBroker.AuthorizeAsync(secret, "Facebook", "", "", Services.Config.Sandbox).Result;
        }
    }
}
