﻿using Newtonsoft.Json;
using POGOProtos.Networking.Envelopes;
using PokemonGo.RocketAPI.Enums;
using System;

namespace PokemonGoAPI.Session
{
    /// <summary>
    /// Data used to access to current session
    /// </summary>
    public class AccessToken
    {
        [JsonIgnore]
        public string Uid => $"{Username}-{AuthType}";

        [JsonProperty("username", Required = Required.Always)]
        public string Username { get; internal set; }

        [JsonProperty("token", Required = Required.Always)]
        public string Token { get; internal set; }

        [JsonProperty("expiry", Required = Required.Always)]
        public DateTime Expiry { get; internal set; }

        [JsonProperty("auth_type", Required = Required.Always)]
        public AuthType AuthType { get; internal set; }

        [JsonIgnore]
        public bool IsExpired => Expiry.AddSeconds(-60) <= DateTime.UtcNow;

        [JsonIgnore]
        public AuthTicket AuthTicket { get; internal set; }

        public void Expire()
        {
            Expiry = DateTime.UtcNow.AddSeconds(-60);
            AuthTicket = null;
        }
    }
}
