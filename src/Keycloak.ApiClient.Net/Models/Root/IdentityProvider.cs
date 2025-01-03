using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class IdentityProvider
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public IdentityProviderProviders Providers { get; set; }
    }
}