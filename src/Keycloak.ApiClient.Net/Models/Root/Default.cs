﻿using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class Default
    {
        [JsonProperty("order")]
        public long Order { get; set; }

        [JsonProperty("operationalInfo")]
        public OperationalInfo OperationalInfo { get; set; }
    }
}