using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class ClientAuthenticator
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public ClientAuthenticatorProviders Providers { get; set; }
    }
}