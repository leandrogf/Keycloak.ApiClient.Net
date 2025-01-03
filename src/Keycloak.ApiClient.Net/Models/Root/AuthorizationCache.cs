using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class AuthorizationCache
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public HasDefault Providers { get; set; }
    }
}