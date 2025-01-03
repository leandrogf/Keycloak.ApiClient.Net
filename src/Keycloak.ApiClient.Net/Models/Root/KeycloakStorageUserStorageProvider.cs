﻿using System.Collections.Generic;
using Keycloak.ApiClient.Net.Models.Common;
using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class KeycloakStorageUserStorageProvider
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("helpText")]
        public string HelpText { get; set; }

        [JsonProperty("properties")]
        public List<ConfigProperty> Properties { get; set; }

        [JsonProperty("metadata")]
        public KeycloakStorageUserStorageProviderMetadata Metadata { get; set; }
    }
}