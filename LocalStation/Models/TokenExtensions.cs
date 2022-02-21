using LocalStation.Helpers;

namespace LocalStation.Models
{
    static internal class TokenExtensions
    {
        public static TokenInfo ToTokenInfo(this Dictionary<string, string> tokenDict)
        {
            TokenInfo tokenInfo = new()
            {
                AccessToken = tokenDict.GetOrThrow("access_token"),
                RefreshToken = tokenDict.GetOrThrow("refresh_token"),
                Expiration = DateTime.Now.AddSeconds(Int32.Parse(tokenDict.GetOrThrow("expires_in")))
            };

            return tokenInfo;
        }
    }
}
