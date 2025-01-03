using System.Collections.Generic;
using Keycloak.ApiClient.Net.Models.Common;
using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.AuthenticationManagement
{
    public class AuthenticatorConfigInfo
    {
        [JsonProperty("helpText")]
        public string HelpText { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("properties")]
        public IEnumerable<ConfigProperty> Properties { get; set; }
        [JsonProperty("providerId")]
        public string ProviderId { get; set; }
    }
}
