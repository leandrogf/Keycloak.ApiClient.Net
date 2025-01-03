using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class IdentityProviderProviders
    {
        [JsonProperty("saml")]
        public HasOrder Saml { get; set; }

        [JsonProperty("oidc")]
        public HasOrder Oidc { get; set; }

        [JsonProperty("keycloak-oidc")]
        public HasOrder KeycloakOidc { get; set; }
    }
}