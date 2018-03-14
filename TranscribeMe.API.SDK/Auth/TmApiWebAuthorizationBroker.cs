using System;
using System.Threading.Tasks;

using TranscribeMe.API.SDK.Auth.Flows;
using TranscribeMe.API.SDK.Http;
using TranscribeMe.API.SDK.Http.Handlers;
using TranscribeMe.API.SDK.Services;
using TranscribeMe.API.SDK.Services.Configurations;

namespace TranscribeMe.API.SDK.Auth
{
    public static class TmApiWebAuthorizationBroker
    {
        public static async Task<UserCredentials> AuthorizeAsync(ApplicationCredentials secret, string userName, string password, Config configuration)
        {
            IAuthorizationCodeFlow flow =
                new PasswordAuthorizationCodeFlow(userName, password,
                                                  new FlowInitializer(new ServiceConfigurationFactory(configuration),
                                                                      new TmHttpClientFactory(new[] { new UnsuccessResponseDelegatingHandler() })));
            var credentials = new UserCredentials(new UserCredentials.Initializer(flow, secret, new ServiceConfigurationFactory(configuration)));
            await credentials.GetTokenAsync();
            return credentials;
        }

        public static async Task<UserCredentials> AuthorizeAsync(ApplicationCredentials secret, string provider, string externalToken, string role, Config configuration)
        {
            IAuthorizationCodeFlow flow;
            switch (provider)
            {
                case "Facebook":
                    flow = new FacebookAuthorizationCodeFlow(externalToken,
                                                             role,
                                                             new FlowInitializer(new ServiceConfigurationFactory(configuration),
                                                                                 new TmHttpClientFactory(new[] { new UnsuccessResponseDelegatingHandler() })));
                    break;
                default:
                    throw new ArgumentException(provider);
            }
            var credentials = new UserCredentials(new UserCredentials.Initializer(flow, secret, new ServiceConfigurationFactory(configuration)));
            await credentials.GetTokenAsync();
            return credentials;
        }

        public static async Task ReauthorizeAsync(UserCredentials userCredentials)
        {
            await userCredentials.RefreshTokenAsync();
        }
    }
}