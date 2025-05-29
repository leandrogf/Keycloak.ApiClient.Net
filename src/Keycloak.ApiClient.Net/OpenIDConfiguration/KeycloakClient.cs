using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.ApiClient.Net.Models.OpenIDConfiguration;

namespace Keycloak.ApiClient.Net
{
    public partial class KeycloakClient
    {
        public async Task<OpenIDConfiguration> GetOpenIDConfigurationAsync(string realm) => await GetBaseUrl(realm, false)
            .AppendPathSegment($"/realms/{realm}/.well-known/openid-configuration")
            .GetJsonAsync<OpenIDConfiguration>()
            .ConfigureAwait(false);
    }
}
