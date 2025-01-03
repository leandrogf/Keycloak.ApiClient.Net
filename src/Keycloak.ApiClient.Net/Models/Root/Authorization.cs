using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class Authorization
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public AuthorizationProviders Providers { get; set; }
    }
}