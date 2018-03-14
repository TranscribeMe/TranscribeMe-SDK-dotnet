using TranscribeMe.API.Data.Queries;
using TranscribeMe.API.SDK.Auth;
using TranscribeMe.API.SDK.Services;

namespace TranscribeMe.API.SDK.Sample
{
    public class GetCustomerRecordings
    {
        public static void Sample()
        {
            var secret = new ApplicationCredentials("", "");
            var credentials = TmApiWebAuthorizationBroker.AuthorizeAsync(secret, "", "", Config.Sandbox).Result;
            var recordingsService = new RecordingsService(new BaseService.Initializer(credentials));
            var recordings = recordingsService.Get(new RecordingsQuery()).Result;
        }
    }
}
