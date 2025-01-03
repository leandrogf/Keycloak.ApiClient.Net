using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class AuthorizationPersister
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public AuthorizationPersisterProviders Providers { get; set; }
    }
}