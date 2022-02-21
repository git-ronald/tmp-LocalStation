using LocalStation.Models;
using LocalStation.Settings;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace LocalStation
{
    internal class HubClient : IHubClient
    {
        private readonly HubSettings _settings;
        private readonly Dictionary<string, string> _tokenPostData;
        private readonly Dictionary<string, string> _refreshPostData;
        private readonly HubConnection _connection;

        private TokenInfo _tokenInfo = new();

        public HubClient(IOptions<HubSettings> options)
        {
            _settings = options.Value;
            _tokenPostData = BuildTokenPostData();
            _refreshPostData = BuildBasicRefreshPostData();

            IHubConnectionBuilder connectionBuilder = new HubConnectionBuilder().WithUrl(_settings.HubUrl, options =>
            {
                options.AccessTokenProvider = GetToken;
            });

            _connection = connectionBuilder.Build();

            _connection.On<string>("GetIt", message =>
            {
                Console.WriteLine($"Got message from hub: {message}");
            });
        }

        private Dictionary<string, string> BuildTokenPostData()
        {
            return new Dictionary<string, string>()
            {
                { "username", _settings.Username },
                { "password", _settings.Password },
                { "grant_type", "password" },
                { "scope", $"openid {_settings.ClientId} offline_access" },
                { "client_id", _settings.ClientId },
                { "response_type", "token id_token" }
            };
        }

        private Dictionary<string, string> BuildBasicRefreshPostData()
        {
            return new Dictionary<string, string>()
            {
                { "grant_type", "refresh_token" },
                { "response_type", "id_token" },
                { "client_id", _settings.ClientId },
                { "resource", _settings.ClientId }
            };
        }

        public Task Start()
        {
            return _connection.StartAsync();
        }

        public Task Test()
        {
            return _connection.InvokeAsync("DoIt", "Little Pony");
        }

        private async Task<string?> GetToken()
        {
            bool test = false;
            if (test)
            {
                _tokenInfo = await RefreshToken();
                return _tokenInfo.AccessToken;
            }

            if (_tokenInfo.Expiration > DateTime.Now.AddMinutes(-3))
            {
                return _tokenInfo.AccessToken;
            }

            _tokenInfo = await GetNewToken();
            return _tokenInfo.AccessToken;
        }

        private async Task<TokenInfo> GetNewToken()
        {
            FormUrlEncodedContent content = new(_tokenPostData);

            using HttpClient client = new();
            HttpResponseMessage response = await client.PostAsync(_settings.TokenUrl, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failure calling token end-point.");
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            var responseDict = JsonSerializer.Deserialize<Dictionary<string, string>>(responseContent) ?? new Dictionary<string, string>();

            return responseDict.ToTokenInfo();
        }

        private async Task<TokenInfo> RefreshToken()
        {
            Console.WriteLine("Refreshing token...");

            FormUrlEncodedContent content = new(_refreshPostData.Concat(new Dictionary<string, string>
            {
                { "refresh_token", _tokenInfo.RefreshToken }
            }));

            using HttpClient client = new();
            HttpResponseMessage response = await client.PostAsync(_settings.TokenUrl, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failure calling refresh token end-point");
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            var responseDict = JsonSerializer.Deserialize<Dictionary<string, string>>(responseContent) ?? new Dictionary<string, string>();

            // TODO NOW: what if refresh token expires? Pbly login again
            return responseDict.ToTokenInfo();
        }

        public async ValueTask DisposeAsync()
        {
            await _connection.StopAsync();
            await _connection.DisposeAsync();
        }
    }
}
