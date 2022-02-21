using LocalStation.Settings;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace LocalStation
{
    internal class HubClient : IHubClient
    {
        private readonly HubSettings _settings;
        private readonly HttpContent _tokenPostData;
        private readonly HubConnection _connection;

        public HubClient(IOptions<HubSettings> options)
        {
            _settings = options.Value;
            _tokenPostData = BuildTokenPostData();

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

        private HttpContent BuildTokenPostData()
        {
            Dictionary<string, string> values = new()
            {
                { "username", _settings.Username },
                { "password", _settings.Password },
                { "grant_type", "password" },
                { "scope", $"openid {_settings.ClientId} offline_access" },
                { "client_id", _settings.ClientId },
                { "response_type", "token id_token" }
            };
            return new FormUrlEncodedContent(values);
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
            using HttpClient client = new();
            HttpResponseMessage response = await client.PostAsync(_settings.TokenUrl, _tokenPostData);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failure calling token end-point.");
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            var responseDict = JsonSerializer.Deserialize<Dictionary<string, string>>(responseContent) ?? new Dictionary<string, string>();

            // TODO NOW: other items: expires_in, refresh_token

            // TODO NOW: what if token expires?

            if (!responseDict.TryGetValue("access_token", out string? accessToken))
            {
                accessToken = null;
            }
            if (String.IsNullOrEmpty(accessToken))
            {
                throw new Exception("Failed to retrieve access-token.");
            }

            return accessToken;
        }

        public async ValueTask DisposeAsync()
        {
            await _connection.StopAsync();
            await _connection.DisposeAsync();
        }
    }
}
