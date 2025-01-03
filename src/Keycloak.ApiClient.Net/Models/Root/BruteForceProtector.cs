using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class BruteForceProtector
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public BruteForceProtectorProviders Providers { get; set; }
    }
}