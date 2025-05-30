using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.ApiClient.Net.Tests
{
    public partial class KeycloakClientShould
    {

        [Theory]
        [InlineData("test")]
        public async Task GetUsersAsync(string realm)
        {
            var result = await _client.GetUsersAsync(realm).ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("test")]
        public async Task GetUsersCountAsync(string realm)
        {
            int? result = await _client.GetUsersCountAsync(realm);
            Assert.True(result >= 0);
        }

        [Theory]
        [InlineData("test")]
        public async Task GetUserAsync(string realm)
        {
            var users = await _client.GetUsersAsync(realm).ConfigureAwait(false);
            string userId = users.FirstOrDefault()?.Id;
            if (userId != null)
            {
                var result = await _client.GetUserAsync(realm, userId).ConfigureAwait(false);
                Assert.NotNull(result);
                Assert.Equal(userId, result.Id);
            }
        }

        [Theory]
        [InlineData("test", "vermeulen")]
        public async Task GetUserSocialLoginsAsync(string realm, string search)
        {
            var users = await _client.GetUsersAsync(realm, search: search).ConfigureAwait(false);
            string userId = users.FirstOrDefault()?.Id;
            if (userId != null)
            {
                var result = await _client.GetUserSocialLoginsAsync(realm, userId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("test", "vermeulen")]
        public async Task GetUserGroupsAsync(string realm, string search)
        {
            var users = await _client.GetUsersAsync(realm, search: search).ConfigureAwait(false);
            string userId = users.FirstOrDefault()?.Id;
            if (userId != null)
            {
                var result = await _client.GetUserGroupsAsync(realm, userId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("test", "vermeulen")]
        public async Task GetUserGroupsCountAsync(string realm, string search)
        {
            var users = await _client.GetUsersAsync(realm, search: search).ConfigureAwait(false);
            string userId = users.FirstOrDefault()?.Id;
            if (userId != null)
            {
                long result = await _client.GetUserGroupsCountAsync(realm, userId);
                Assert.True(result >= 0);
            }
        }

        [Theory]
        [InlineData("test", "vermeulen")]
        public async Task GetUserSessionsAsync(string realm, string search)
        {
            var users = await _client.GetUsersAsync(realm, search: search).ConfigureAwait(false);
            string userId = users.FirstOrDefault()?.Id;
            if (userId != null)
            {
                var result = await _client.GetUserSessionsAsync(realm, userId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }
        [Theory]
        [InlineData("test", "user", "email@email.com")]
        public async Task CreateUserAsync_ShouldCreateUser(string realm, string username, string email)
        {
            var user = new Models.Users.User
            {
                Username = username,
                Email = email,
                Enabled = true,
                FirstName = "First Name",
                LastName = "Last Name",
                Credentials = new System.Collections.Generic.List<Models.Users.Credentials>
                {
                    new Models.Users.Credentials
                    {
                        Type = "password",
                        Value = "secret_password",
                        Temporary = false // Defina como false se não quiser que a senha seja temporária
                    }
                },
            };

            var response = await _client.CreateUserAsync(realm, user).ConfigureAwait(false);
            Assert.NotNull(response);

            // Cleanup: remover o usuário criado (opcional, se houver método disponível)
            var users = await _client.GetUsersAsync(realm, search: username).ConfigureAwait(false);
            var createdUser = users.FirstOrDefault(u => u.Username == username);
            if (createdUser != null)
            {
                await _client.DeleteUserAsync(realm, createdUser.Id).ConfigureAwait(false);
            }
        }
    }
}
