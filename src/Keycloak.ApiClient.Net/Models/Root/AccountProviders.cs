using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class AccountProviders
    {
        [JsonProperty("freemarker")]
        public HasOrder Freemarker { get; set; }
    }
}