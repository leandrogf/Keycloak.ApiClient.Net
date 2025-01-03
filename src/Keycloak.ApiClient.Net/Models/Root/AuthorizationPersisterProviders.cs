using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class AuthorizationPersisterProviders
    {
        [JsonProperty("jpa")]
        public HasOrder Jpa { get; set; }
    }
}