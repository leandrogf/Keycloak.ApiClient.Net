using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class AuthorizationProviders
    {
        [JsonProperty("authorization")]
        public HasOrder Authorization { get; set; }
    }
}