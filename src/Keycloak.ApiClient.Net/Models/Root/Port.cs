using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class Port
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public ExportProviders Providers { get; set; }
    }
}