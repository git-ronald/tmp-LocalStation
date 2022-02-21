﻿namespace LocalStation.Models
{
    internal class TokenInfo
    {
        public string AccessToken { get; set; } = "";
        public string RefreshToken { get; set; } = "";
        public DateTime Expiration { get; set; } = DateTime.MinValue;
    }
}