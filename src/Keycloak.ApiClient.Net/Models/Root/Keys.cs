using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class Keys
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public KeysProviders Providers { get; set; }
    }
}