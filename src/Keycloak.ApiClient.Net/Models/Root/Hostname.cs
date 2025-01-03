using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class Hostname
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public HostnameProviders Providers { get; set; }
    }
}