﻿using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class CredentialProviders
    {
        [JsonProperty("keycloak-otp")]
        public HasOrder KeycloakOtp { get; set; }

        [JsonProperty("keycloak-password")]
        public HasOrder KeycloakPassword { get; set; }
    }
}