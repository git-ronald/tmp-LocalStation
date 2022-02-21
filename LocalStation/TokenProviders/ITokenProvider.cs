namespace LocalStation.TokenProviders
{
    internal interface ITokenProvider
    {
        Task<string?> GetToken();
    }
}
