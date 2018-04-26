using System;
using System.Configuration;
using System.Threading.Tasks;

using TranscribeMe.API.SDK.Auth.Flows;
using TranscribeMe.API.SDK.Configurations;
using TranscribeMe.API.SDK.Http;
using TranscribeMe.API.SDK.Http.Handlers;
using TranscribeMe.API.SDK.Services;

namespace TranscribeMe.API.SDK.Auth
{
    public static class TmApiWebAuthorizationBroker
    {
        public static async Task<UserCredentials> AuthorizeAsync()
        {
            var config = (TmAuthorizationSection)ConfigurationManager.GetSection("authorizationGroup/tmAuthorization");

            if (config?.Application != null)
            {
                var secret = new ApplicationCredentials(config.Application.ClientId, config.Application.ClientSecret);

                if (config.Token != null &&
                    config.Token.ElementInformation.IsPresent && 
                    !string.IsNullOrWhiteSpace(config.Token.Value))
                {
                    return await AuthorizeAsync(secret, config.Token.Value, config.ApiConfigType);
                }
                if (config.Credentials != null && config.Credentials.ElementInformation.IsPresent)
                {
                    return await AuthorizeAsync(secret, config.Credentials.UserName, config.Credentials.Password, config.ApiConfigType);
                }
            }

            return null;
        }

        public static async Task<UserCredentials> AuthorizeAsync(ApplicationCredentials secret,
                                                                 string applicationToken,
                                                                 Config configuration)
        {
            IAuthorizationCodeFlow flow =
                new ApplicationTokenAuthorizationCodeFlow(applicationToken,
                                                          new FlowInitializer(new ServiceConfigurationFactory(configuration),
                                                                              new TmHttpClientFactory(new[]
                                                                                                          {
                                                                                                              new UnsuccessResponseDelegatingHandler()
                                                                                                          })));
            var credentials = new UserCredentials(new UserCredentials.Initializer(flow, secret, new ServiceConfigurationFactory(configuration)));
            await credentials.GetTokenAsync();
            return credentials;
        }

        public static async Task<UserCredentials> AuthorizeAsync(ApplicationCredentials secret,
                                                                 string userName,
                                                                 string password,
                                                                 Config configuration)
        {
            IAuthorizationCodeFlow flow =
                new PasswordAuthorizationCodeFlow(userName,
                                                  password,
                                                  new FlowInitializer(new ServiceConfigurationFactory(configuration),
                                                                      new TmHttpClientFactory(new[]
                                                                                                  {
                                                                                                      new UnsuccessResponseDelegatingHandler()
                                                                                                  })));
            var credentials = new UserCredentials(new UserCredentials.Initializer(flow, secret, new ServiceConfigurationFactory(configuration)));
            await credentials.GetTokenAsync();
            return credentials;
        }

        public static async Task<UserCredentials> AuthorizeAsync(ApplicationCredentials secret,
                                                                 string provider,
                                                                 string externalToken,
                                                                 string role,
                                                                 Config configuration)
        {
            IAuthorizationCodeFlow flow;
            switch (provider)
            {
                case "Facebook":
                    flow = new FacebookAuthorizationCodeFlow(externalToken,
                                                             role,
                                                             new FlowInitializer(new ServiceConfigurationFactory(configuration),
                                                                                 new TmHttpClientFactory(new[]
                                                                                                             {
                                                                                                                 new UnsuccessResponseDelegatingHandler()
                                                                                                             })));
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