using System.Threading.Tasks;
using Xunit;

namespace Keycloak.ApiClient.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Theory]
        [InlineData("test")]
        public async Task GetClientInitialAccessAsync(string realm)
        {
            var result = await _client.GetClientInitialAccessAsync(realm).ConfigureAwait(false);
            Assert.NotNull(result);
        }
    }
}
