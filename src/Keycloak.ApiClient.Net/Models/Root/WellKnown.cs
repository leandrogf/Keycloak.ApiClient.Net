using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class WellKnown
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public WellKnownProviders Providers { get; set; }
    }
}