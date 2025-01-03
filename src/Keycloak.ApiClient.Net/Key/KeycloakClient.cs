using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.ApiClient.Net.Models.Key;

namespace Keycloak.ApiClient.Net
{
    public partial class KeycloakClient
    {
        public async Task<KeysMetadata> GetKeysAsync(string realm) => await GetBaseUrl(realm)
            .AppendPathSegment($"/admin/realms/{realm}/keys")
            .GetJsonAsync<KeysMetadata>()
            .ConfigureAwait(false);
    }
}
