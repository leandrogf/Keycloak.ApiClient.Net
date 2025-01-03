using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class HostnameProviders
    {
        [JsonProperty("request")]
        public HasOrder Request { get; set; }
    }
}