using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class Truststore
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public TruststoreProviders Providers { get; set; }
    }
}