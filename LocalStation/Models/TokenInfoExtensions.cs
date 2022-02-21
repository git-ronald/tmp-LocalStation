using LocalStation.Helpers;

namespace LocalStation.Models
{
    static internal class TokenInfoExtensions
    {
        public static TokenInfo ToTokenInfo(this Dictionary<string, object> tokenDict)
        {
            DateTime now = DateTime.Now;

            var b = tokenDict.GetOrDefault("refresh_token_expires_in", "").ToString().ForceParseToInt();
            TokenInfo tokenInfo = new()
            {
                AccessToken = tokenDict.GetOrThrow("access_token").ForceToString(),
                RefreshToken = tokenDict.GetOrThrow("refresh_token").ForceToString(),
                AccessTokenExpiration = now.AddSeconds(Int32.Parse(tokenDict.GetOrThrow("expires_in").ForceToString())),
                RefreshTokenExpiration = now.AddSeconds(tokenDict.GetOrDefault("refresh_token_expires_in", "").ToString().ForceParseToInt())
            };

            return tokenInfo;
        }
    }
}
