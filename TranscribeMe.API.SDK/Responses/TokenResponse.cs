using System;

using Newtonsoft.Json;

namespace TranscribeMe.API.SDK.Responses
{
    public class TokenResponse
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty(PropertyName = ".expires")]
        public DateTime ExpiresUtc { get; set; }
    }
}