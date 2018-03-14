using TranscribeMe.API.SDK.Auth;
using TranscribeMe.API.SDK.Services;

namespace TranscribeMe.API.SDK.Sample
{
    public class AuthorizeWithUserLogin
    {
        public static void Sample()
        {
            ApplicationCredentials secret = new ApplicationCredentials("", "");
            var credentials = TmApiWebAuthorizationBroker.AuthorizeAsync(secret, "", "", Config.Sandbox).Result;
        }
    }
}
