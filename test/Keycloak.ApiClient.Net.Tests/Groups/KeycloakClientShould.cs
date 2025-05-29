using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.ApiClient.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Theory]
        [InlineData("test")]
        public async Task GetGroupHierarchyAsync(string realm)
        {
            var result = await _client.GetGroupHierarchyAsync(realm).ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("test")]
        public async Task GetGroupsCountAsync(string realm)
        {
            long result = await _client.GetGroupsCountAsync(realm);
            Assert.True(result >= 0);
        }

        [Theory]
        [InlineData("test")]
        public async Task GetGroupAsync(string realm)
        {
            var groups = await _client.GetGroupHierarchyAsync(realm).ConfigureAwait(false);
            string groupId = groups.FirstOrDefault()?.Id;
            if (groupId != null)
            {
                var result = await _client.GetGroupAsync(realm, groupId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }
        
        [Theory]
        [InlineData("test")]
        public async Task GetGroupClientAuthorizationPermissionsInitializedAsync(string realm)
        {
            var groups = await _client.GetGroupHierarchyAsync(realm).ConfigureAwait(false);
            string groupId = groups.FirstOrDefault()?.Id;
            if (groupId != null)
            {
                var result = await _client.GetGroupClientAuthorizationPermissionsInitializedAsync(realm, groupId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("test")]
        public async Task GetGroupUsersAsync(string realm)
        {
            var groups = await _client.GetGroupHierarchyAsync(realm).ConfigureAwait(false);
            string groupId = groups.FirstOrDefault()?.Id;
            if (groupId != null)
            {
                var result = await _client.GetGroupUsersAsync(realm, groupId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }
    }
}
