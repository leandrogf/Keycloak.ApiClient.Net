using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class FormAuthenticator
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public FormAuthenticatorProviders Providers { get; set; }
    }
}