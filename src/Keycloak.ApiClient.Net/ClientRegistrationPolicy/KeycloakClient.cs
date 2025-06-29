﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.ApiClient.Net.Models.Components;

namespace Keycloak.ApiClient.Net
{
    public partial class KeycloakClient
    {
        public async Task<IEnumerable<ComponentType>> GetRetrieveProvidersBasePathAsync(string realm) => await GetBaseUrl(realm, true)
            .AppendPathSegment($"/admin/realms/{realm}/client-registration-policy/providers")
            .GetJsonAsync<IEnumerable<ComponentType>>()
            .ConfigureAwait(false);
    }
}
