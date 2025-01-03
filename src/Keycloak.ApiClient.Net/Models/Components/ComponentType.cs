﻿using System.Collections.Generic;
using Keycloak.ApiClient.Net.Models.Common;
using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Components
{
    public class ComponentType
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("helpText")]
        public string HelpText { get; set; }
        [JsonProperty("properties")]
        public IEnumerable<ConfigProperty> Properties { get; set; }
        [JsonProperty("metadata")]
        public IDictionary<string, object> Metadata { get; set; }
    }
}
