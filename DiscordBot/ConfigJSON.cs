﻿using Newtonsoft.Json;

namespace DiscordBot;

internal struct ConfigJSON
{
    [JsonProperty("token")]
    public string Token { get; private set; }

    [JsonProperty("prefix")]
    public string Prefix { get; private set; }
}
