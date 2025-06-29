using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.ApiClient.Net.Common.Extensions;
using Keycloak.ApiClient.Net.Models;
using Keycloak.ApiClient.Net.Models.Groups;
using Keycloak.ApiClient.Net.Models.Users;
using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net
{
    public partial class KeycloakClient
    {
        public async Task<bool> CreateUserAsync(string realm, User user)
        {
            var response = await InternalCreateUserAsync(realm, user).ConfigureAwait(false);
            return response.StatusCode >= 200 && response.StatusCode < 300;
        }

        private async Task<IFlurlResponse> InternalCreateUserAsync(string realm, User user) => await GetBaseUrl(realm, true)
            .AppendPathSegment($"/admin/realms/{realm}/users")
            .PostJsonAsync(user)
            .ConfigureAwait(false);

        public async Task<string> CreateAndRetrieveUserIdAsync(string realm, User user)
        {
            var response = await InternalCreateUserAsync(realm, user).ConfigureAwait(false);
            string locationPathAndQuery = response.Headers.FirstOrDefault("Location");
            string userId = (response.StatusCode >= 200 && response.StatusCode < 300 && !string.IsNullOrEmpty(locationPathAndQuery)) ?
                locationPathAndQuery.Substring(locationPathAndQuery.LastIndexOf('/') + 1) : null;
            return userId;
        }

        public async Task<IEnumerable<User>> GetUsersAsync(string realm, bool? briefRepresentation = null, string email = null, int? first = null,
            string firstName = null, string lastName = null, int? max = null, string search = null, string username = null)
        {
            var queryParams = new Dictionary<string, object>
            {
                [nameof(briefRepresentation)] = briefRepresentation,
                [nameof(email)] = email,
                [nameof(first)] = first,
                [nameof(firstName)] = firstName,
                [nameof(lastName)] = lastName,
                [nameof(max)] = max,
                [nameof(search)] = search,
                [nameof(username)] = username
            };

            var x = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/users")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<object>>()
                .ConfigureAwait(false);

            return await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/users")
                .SetQueryParams(queryParams)
                .GetJsonAsync<IEnumerable<User>>()
                .ConfigureAwait(false);
        }

        public async Task<int> GetUsersCountAsync(string realm) => await GetBaseUrl(realm, true)
            .AppendPathSegment($"/admin/realms/{realm}/users/count")
            .GetJsonAsync<int>()
            .ConfigureAwait(false);

        public async Task<User> GetUserAsync(string realm, string userId) => await GetBaseUrl(realm, true)
            .AppendPathSegment($"/admin/realms/{realm}/users/{userId}")
            .GetJsonAsync<User>()
            .ConfigureAwait(false);

        public async Task<bool> UpdateUserAsync(string realm, string userId, User user)
        {
            var response = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}")
                .PutJsonAsync(user)
                .ConfigureAwait(false);
            return response.StatusCode >= 200 && response.StatusCode < 300;
        }

        public async Task<bool> DeleteUserAsync(string realm, string userId)
        {
            var response = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.StatusCode >= 200 && response.StatusCode < 300;
        }

        [Obsolete("Not working yet")]
        public async Task<string> GetUserConsentsAsync(string realm, string userId)
        {
            return await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/consents")
                .GetStringAsync()
                .ConfigureAwait(false);
        }

        public async Task<bool> RevokeUserConsentAndOfflineTokensAsync(string realm, string userId, string clientId)
        {
            var response = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/consents/{clientId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.StatusCode >= 200 && response.StatusCode < 300;
        }

        public async Task<bool> DisableUserCredentialsAsync(string realm, string userId, IEnumerable<string> credentialTypes)
        {
            var response = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/disable-credential-types")
                .PutJsonAsync(credentialTypes)
                .ConfigureAwait(false);
            return response.StatusCode >= 200 && response.StatusCode < 300;
        }

        public async Task<bool> SendUserUpdateAccountEmailAsync(string realm, string userId, IEnumerable<string> requiredActions, string clientId = null, int? lifespan = null, string redirectUri = null)
        {
            var queryParams = new Dictionary<string, object>
            {
                ["client_id"] = clientId,
                [nameof(lifespan)] = lifespan,
                ["redirect_uri"] = redirectUri
            };

            var response = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/execute-actions-email")
                .SetQueryParams(queryParams)
                .PutJsonAsync(requiredActions)
                .ConfigureAwait(false);
            return response.StatusCode >= 200 && response.StatusCode < 300;
        }

        public async Task<IEnumerable<FederatedIdentity>> GetUserSocialLoginsAsync(string realm, string userId) => await GetBaseUrl(realm, true)
            .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/federated-identity")
            .GetJsonAsync<IEnumerable<FederatedIdentity>>()
            .ConfigureAwait(false);

        public async Task<bool> AddUserSocialLoginProviderAsync(string realm, string userId, string provider, FederatedIdentity federatedIdentity)
        {
            var response = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/federated-identity/{provider}")
                .PostJsonAsync(federatedIdentity)
                .ConfigureAwait(false);
            return response.StatusCode >= 200 && response.StatusCode < 300;
        }

        public async Task<bool> RemoveUserSocialLoginProviderAsync(string realm, string userId, string provider)
        {
            var response = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/federated-identity/{provider}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.StatusCode >= 200 && response.StatusCode < 300;
        }

        public async Task<IEnumerable<Group>> GetUserGroupsAsync(string realm, string userId) => await GetBaseUrl(realm, true)
            .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/groups")
            .GetJsonAsync<IEnumerable<Group>>()
            .ConfigureAwait(false);

        public async Task<long> GetUserGroupsCountAsync(string realm, string userId)
        {
            var result = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/groups/count")
                .GetJsonAsync<CountResponse>()
                .ConfigureAwait(false);
            return result.Count;
        }

        public async Task<bool> UpdateUserGroupAsync(string realm, string userId, string groupId, Group group)
        {
            var response = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/groups/{groupId}")
                .PutJsonAsync(group)
                .ConfigureAwait(false);
            return response.StatusCode >= 200 && response.StatusCode < 300;
        }

        public async Task<bool> DeleteUserGroupAsync(string realm, string userId, string groupId)
        {
            var response = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/groups/{groupId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.StatusCode >= 200 && response.StatusCode < 300;
        }

        public async Task<IDictionary<string, object>> ImpersonateUserAsync(string realm, string userId) => await GetBaseUrl(realm, true)
            .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/impersonation")
            .PostAsync(new StringContent(""))
            .ReceiveJson<IDictionary<string, object>>()
            .ConfigureAwait(false);

        public async Task<bool> RemoveUserSessionsAsync(string realm, string userId)
        {
            var response = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/logout")
                .PostAsync(new StringContent(""))
                .ConfigureAwait(false);
            return response.StatusCode >= 200 && response.StatusCode < 300;
        }

        [Obsolete("Not working yet")]
        public async Task<IEnumerable<UserSession>> GetUserOfflineSessionsAsync(string realm, string userId, string clientId) => await GetBaseUrl(realm, true)
            .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/offline-sessions/{clientId}")
            .GetJsonAsync<IEnumerable<UserSession>>()
            .ConfigureAwait(false);

        public async Task<bool> RemoveUserTotpAsync(string realm, string userId)
        {
            var response = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/remove-totp")
                .PutAsync(new StringContent(""))
                .ConfigureAwait(false);
            return response.StatusCode >= 200 && response.StatusCode < 300;
        }

        public async Task<bool> ResetUserPasswordAsync(string realm, string userId, Credentials credentials)
        {
            var response = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/reset-password")
                .PutJsonAsync(credentials)
                .ConfigureAwait(false);
            return response.StatusCode >= 200 && response.StatusCode < 300;
        }

        public async Task<bool> ResetUserPasswordAsync(string realm, string userId, string password, bool temporary = true)
        {
            var response = await InternalResetUserPasswordAsync(realm, userId, password, temporary).ConfigureAwait(false);
            return response.StatusCode >= 200 && response.StatusCode < 300;
        }

        private async Task<IFlurlResponse> InternalResetUserPasswordAsync(string realm, string userId, string password, bool temporary)
        {
            var credentials = new Credentials
            {
                Value = password,
                Temporary = temporary
            };
            var response = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/reset-password")
                .PutJsonAsync(credentials)
                .ConfigureAwait(false);
            return response;
        }

        public async Task<SetPasswordResponse> SetUserPasswordAsync(string realm, string userId, string password)
        {
            var response = await InternalResetUserPasswordAsync(realm, userId, password, false).ConfigureAwait(false);
            if (response.StatusCode >= 200 && response.StatusCode < 300)
                return new SetPasswordResponse { Success = true };

            var jsonString = await response.GetStringAsync();
            return JsonConvert.DeserializeObject<SetPasswordResponse>(jsonString);
        }

        public async Task<bool> VerifyUserEmailAddressAsync(string realm, string userId, string clientId = null, string redirectUri = null)
        {
            var queryParams = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(clientId))
            {
                queryParams.Add("client_id", clientId);
            }

            if (!string.IsNullOrEmpty(redirectUri))
            {
                queryParams.Add("redirect_uri", redirectUri);
            }

            var response = await GetBaseUrl(realm, true)
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/send-verify-email")
                .SetQueryParams(queryParams)
                .PutJsonAsync(null)
                .ConfigureAwait(false);
            return response.StatusCode >= 200 && response.StatusCode < 300;
        }

        public async Task<IEnumerable<UserSession>> GetUserSessionsAsync(string realm, string userId) => await GetBaseUrl(realm, true)
            .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/sessions")
            .GetJsonAsync<IEnumerable<UserSession>>()
            .ConfigureAwait(false);
    }
}