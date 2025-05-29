using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models
{
    public class CountResponse
    {
        [JsonProperty("count")]
        public long Count { get; set; }
    }
}