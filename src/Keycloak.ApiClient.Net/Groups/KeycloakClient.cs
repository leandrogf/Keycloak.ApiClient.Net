﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.ApiClient.Net.Common.Extensions;
using Keycloak.ApiClient.Net.Models;
using Keycloak.ApiClient.Net.Models.Common;
using Keycloak.ApiClient.Net.Models.Groups;
using Keycloak.ApiClient.Net.Models.Users;

namespace Keycloak.ApiClient.Net
{
    public partial class KeycloakClient
    {
        public async Task<bool> CreateGroupAsync(string realm, Group group)
        {
            var response = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/groups")
                .PostJsonAsync(group)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Group>> GetGroupHierarchyAsync(string realm, int? first = null, int? max = null, string search = null)
        {
            var queryParams = new Dictionary<string, object>
            {
                [nameof(first)] = first,
                [nameof(max)] = max,
                [nameof(search)] = search,
                ["briefRepresentation"] = false
            };

            return await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/groups")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<Group>>()
                .ConfigureAwait(false);
        }

        public async Task<long> GetGroupsCountAsync(string realm, string search = null, bool? top = null)
        {
            var queryParams = new Dictionary<string, object>
            {
                [nameof(search)] = search,
                [nameof(top)] = top
            };

            var result = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/groups/count")
                .SetQueryParams(queryParams)
                .GetJsonAsync<CountResponse>()
                .ConfigureAwait(false);

            return result.Count;
        }

        public async Task<Group> GetGroupAsync(string realm, string groupId)
        {
            var result = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}")
                .GetJsonAsync<Group>()
                .ConfigureAwait(false);

            return result;
        }

        public async Task<bool> UpdateGroupAsync(string realm, string groupId, Group group)
        {
            var response = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}")
                .PutJsonAsync(group)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteGroupAsync(string realm, string groupId)
        {
            var response = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> SetOrCreateGroupChildAsync(string realm, string groupId, Group group)
        {
            var response = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/children")
                .PostJsonAsync(group)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<ManagementPermission> GetGroupClientAuthorizationPermissionsInitializedAsync(string realm, string groupId) => await GetBaseUrl(realm, true)
            .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/management/permissions")
            .GetJsonAsync<ManagementPermission>()
            .ConfigureAwait(false);

        public async Task<ManagementPermission> SetGroupClientAuthorizationPermissionsInitializedAsync(string realm, string groupId, ManagementPermission managementPermission) =>
            await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/management/permissions")
                .PutJsonAsync(managementPermission)
                .ReceiveJson<ManagementPermission>()
                .ConfigureAwait(false);

        public async Task<IEnumerable<User>> GetGroupUsersAsync(string realm, string groupId, int? first = null, int? max = null) 
        {
            var queryParams = new Dictionary<string, object>
            {
                [nameof(first)] = first,
                [nameof(max)] = max
            };

            return await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/groups/{groupId}/members")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<User>>()
                .ConfigureAwait(false);
        }
    }
}
