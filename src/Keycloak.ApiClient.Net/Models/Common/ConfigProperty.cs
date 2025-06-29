﻿using System.Collections.Generic;
using Keycloak.ApiClient.Net.Models.Root;
using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Common
{
    public class ConfigProperty
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("defaultValue")]
        public object DefaultValue { get; set; }

        [JsonProperty("options")]
        public List<string> Options { get; set; }

        [JsonProperty("helpText")]
        public string HelpText { get; set; }

        [JsonProperty("secret")]
        public bool Secret { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }
    }
}
