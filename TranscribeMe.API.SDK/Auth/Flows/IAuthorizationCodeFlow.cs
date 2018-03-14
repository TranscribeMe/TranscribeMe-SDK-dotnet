using System.Threading.Tasks;

using TranscribeMe.API.SDK.Responses;

namespace TranscribeMe.API.SDK.Auth.Flows
{
    public interface IAuthorizationCodeFlow
    {
        Task<TokenResponse> GetToken(string clientId, string clientSecret);

        Task<TokenResponse> RefreshToken(string refreshToken, string clientId, string clientSecret);
    }
}