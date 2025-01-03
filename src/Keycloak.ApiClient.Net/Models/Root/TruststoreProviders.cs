using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class TruststoreProviders
    {
        [JsonProperty("file")]
        public HasOrder File { get; set; }
    }
}