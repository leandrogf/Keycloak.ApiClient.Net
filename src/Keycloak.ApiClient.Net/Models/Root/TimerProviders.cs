﻿using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class TimerProviders
    {
        [JsonProperty("basic")]
        public HasOrder Basic { get; set; }
    }
}