﻿using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.ApiClient.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Theory]
        [InlineData("test", "insurance-test")]
        public async Task GetRolesForClientAsync(string realm, string clientId)
        {
            var clients = await _client.GetClientsAsync(realm).ConfigureAwait(false);
            string clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
            if (clientsId != null)
            {
                var result = await _client.GetRolesAsync(realm, clientsId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("test", "insurance-test")]
        public async Task GetRoleByNameForClientAsync(string realm, string clientId)
        {
            var clients = await _client.GetClientsAsync(realm).ConfigureAwait(false);
            string clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
            if (clientsId != null)
            {
                var roles = await _client.GetRolesAsync(realm, clientsId).ConfigureAwait(false);
                string roleName = roles.FirstOrDefault()?.Name;
                if (roleName != null)
                {
                    var result = await _client.GetRoleByNameAsync(realm, clientsId, roleName).ConfigureAwait(false);
                    Assert.NotNull(result);
                }
            }
        }

        [Theory]
        [InlineData("test", "insurance-test")]
        public async Task GetRoleCompositesForClientAsync(string realm, string clientId)
        {
            var clients = await _client.GetClientsAsync(realm).ConfigureAwait(false);
            string clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
            if (clientsId != null)
            {
                var roles = await _client.GetRolesAsync(realm, clientsId).ConfigureAwait(false);
                string roleName = roles.FirstOrDefault()?.Name;
                if (roleName != null)
                {
                    var result = await _client.GetRoleCompositesAsync(realm, clientsId, roleName).ConfigureAwait(false);
                    Assert.NotNull(result);
                }
            }
        }

        [Theory]
        [InlineData("test", "insurance-test")]
        public async Task GetApplicationRolesForCompositeForClientAsync(string realm, string clientId)
        {
            var clients = await _client.GetClientsAsync(realm).ConfigureAwait(false);
            string clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
            if (clientsId != null)
            {
                var roles = await _client.GetRolesAsync(realm, clientsId).ConfigureAwait(false);
                string roleName = roles.FirstOrDefault()?.Name;
                if (roleName != null)
                {
                    var result = await _client.GetApplicationRolesForCompositeAsync(realm, clientsId, roleName, clientsId).ConfigureAwait(false);
                    Assert.NotNull(result);
                }
            }
        }

        [Theory]
        [InlineData("test", "insurance-test")]
        public async Task GetRealmRolesForCompositeForClientAsync(string realm, string clientId)
        {
            var clients = await _client.GetClientsAsync(realm).ConfigureAwait(false);
            string clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
            if (clientsId != null)
            {
                var roles = await _client.GetRolesAsync(realm, clientsId).ConfigureAwait(false);
                string roleName = roles.FirstOrDefault()?.Name;
                if (roleName != null)
                {
                    var result = await _client.GetRealmRolesForCompositeAsync(realm, clientsId, roleName).ConfigureAwait(false);
                    Assert.NotNull(result);
                }
            }
        }

        [Theory(Skip = "Not working yet")]
        [InlineData("test", "insurance-test")]
        public async Task GetGroupsWithRoleNameForClientAsync(string realm, string clientId)
        {
            var clients = await _client.GetClientsAsync(realm).ConfigureAwait(false);
            string clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
            if (clientsId != null)
            {
                var roles = await _client.GetRolesAsync(realm, clientsId).ConfigureAwait(false);
                string roleName = roles.FirstOrDefault()?.Name;
                if (roleName != null)
                {
                    var result = await _client.GetGroupsWithRoleNameAsync(realm, clientsId, roleName).ConfigureAwait(false);
                    Assert.NotNull(result);
                }
            }
        }

        [Theory(Skip = "501 Not implemented")]
        [InlineData("test", "insurance-test")]
        public async Task GetRoleAuthorizationPermissionsInitializedForClientAsync(string realm, string clientId)
        {
            var clients = await _client.GetClientsAsync(realm).ConfigureAwait(false);
            string clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
            if (clientsId != null)
            {
                var roles = await _client.GetRolesAsync(realm, clientsId).ConfigureAwait(false);
                string roleName = roles.FirstOrDefault()?.Name;
                if (roleName != null)
                {
                    var result = await _client.GetRoleAuthorizationPermissionsInitializedAsync(realm, clientsId, roleName).ConfigureAwait(false);
                    Assert.NotNull(result);
                }
            }
        }

        [Theory]
        [InlineData("test", "insurance-test")]
        public async Task GetUsersWithRoleNameForClientAsync(string realm, string clientId)
        {
            var clients = await _client.GetClientsAsync(realm).ConfigureAwait(false);
            string clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
            if (clientsId != null)
            {
                var roles = await _client.GetRolesAsync(realm, clientsId).ConfigureAwait(false);
                string roleName = roles.FirstOrDefault()?.Name;
                if (roleName != null)
                {
                    var result = await _client.GetUsersWithRoleNameAsync(realm, clientsId, roleName).ConfigureAwait(false);
                    Assert.NotNull(result);
                }
            }
        }

        [Theory]
        [InlineData("test")]
        public async Task GetRolesForRealmAsync(string realm)
        {
            var result = await _client.GetRolesAsync(realm).ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("test")]
        public async Task GetRoleByNameForRealmAsync(string realm)
        {
            var roles = await _client.GetRolesAsync(realm).ConfigureAwait(false);
            string roleName = roles.FirstOrDefault()?.Name;
            if (roleName != null)
            {
                var result = await _client.GetRoleByNameAsync(realm, roleName).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("test")]
        public async Task GetRoleCompositesForRealmAsync(string realm)
        {
            var roles = await _client.GetRolesAsync(realm).ConfigureAwait(false);
            string roleName = roles.FirstOrDefault()?.Name;
            if (roleName != null)
            {
                var result = await _client.GetRoleCompositesAsync(realm, roleName).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("test", "insurance-test")]
        public async Task GetApplicationRolesForCompositeForRealmAsync(string realm, string clientId)
        {
            var clients = await _client.GetClientsAsync(realm).ConfigureAwait(false);
            string clientsId = clients.FirstOrDefault(x => x.ClientId == clientId)?.Id;
            if (clientsId != null)
            {
                var roles = await _client.GetRolesAsync(realm).ConfigureAwait(false);
                string roleName = roles.FirstOrDefault()?.Name;
                if (roleName != null)
                {
                    var result = await _client.GetApplicationRolesForCompositeAsync(realm, roleName, clientsId).ConfigureAwait(false);
                    Assert.NotNull(result);
                }
            }
        }

        [Theory]
        [InlineData("test")]
        public async Task GetRealmRolesForCompositeForRealmAsync(string realm)
        {
            var roles = await _client.GetRolesAsync(realm).ConfigureAwait(false);
            string roleName = roles.FirstOrDefault()?.Name;
            if (roleName != null)
            {
                var result = await _client.GetRealmRolesForCompositeAsync(realm, roleName).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory(Skip = "Not working yet")]
        [InlineData("test")]
        public async Task GetGroupsWithRoleNameForRealmAsync(string realm)
        {
            var roles = await _client.GetRolesAsync(realm).ConfigureAwait(false);
            string roleName = roles.FirstOrDefault()?.Name;
            if (roleName != null)
            {
                var result = await _client.GetGroupsWithRoleNameAsync(realm, roleName).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory(Skip = "501 Not Implemented")]
        [InlineData("test")]
        public async Task GetRoleAuthorizationPermissionsInitializedForRealmAsync(string realm)
        {
            var roles = await _client.GetRolesAsync(realm).ConfigureAwait(false);
            string roleName = roles.FirstOrDefault()?.Name;
            if (roleName != null)
            {
                var result = await _client.GetRoleAuthorizationPermissionsInitializedAsync(realm, roleName).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("test")]
        public async Task GetUsersWithRoleNameForRealmAsync(string realm)
        {
            var roles = await _client.GetRolesAsync(realm).ConfigureAwait(false);
            string roleName = roles.FirstOrDefault()?.Name;
            if (roleName != null)
            {
                var result = await _client.GetUsersWithRoleNameAsync(realm, roleName).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }
    }
}
