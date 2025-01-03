using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.ClientInitialAccess
{
    public class ClientInitialAccessCreatePresentation
    {
        [JsonProperty("count")]
        public int? Count { get; set; }
        [JsonProperty("expiration")]
        public int? Expiration { get; set; }
    }
}
