using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class JtaLookupProviders
    {
        [JsonProperty("jboss")]
        public HasOrder Jboss { get; set; }
    }
}