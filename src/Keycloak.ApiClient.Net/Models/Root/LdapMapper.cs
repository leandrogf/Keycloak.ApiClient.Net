using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class LdapMapper
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public LdapMapperProviders Providers { get; set; }
    }
}