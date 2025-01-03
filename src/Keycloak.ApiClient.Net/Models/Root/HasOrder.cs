using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class HasOrder
    {
        [JsonProperty("order")]
        public long Order { get; set; }
    }
}