﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.ApiClient.Net.Models.ClientInitialAccess;

namespace Keycloak.ApiClient.Net
{
    public partial class KeycloakClient
    {
        public async Task<ClientInitialAccessPresentation> CreateInitialAccessTokenAsync(string realm, ClientInitialAccessCreatePresentation create) => await GetBaseUrl(realm, true)
            .AppendPathSegment($"/admin/realms/{realm}/clients-initial-access")
            .PostJsonAsync(create)
            .ReceiveJson<ClientInitialAccessPresentation>()
            .ConfigureAwait(false);

        public async Task<IEnumerable<ClientInitialAccessPresentation>> GetClientInitialAccessAsync(string realm) => await GetBaseUrl(realm, true)
            .AppendPathSegment($"/admin/realms/{realm}/clients-initial-access")
            .GetJsonAsync<IEnumerable<ClientInitialAccessPresentation>>()
            .ConfigureAwait(false);

        public async Task<bool> DeleteInitialAccessTokenAsync(string realm, string clientInitialAccessTokenId)
        {
            var response = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/clients-initial-access/{clientInitialAccessTokenId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }
    }
}
