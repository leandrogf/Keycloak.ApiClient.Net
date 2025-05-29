using System.Threading.Tasks;
using Xunit;

namespace Keycloak.ApiClient.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Theory]
        [InlineData("test")]
        public async Task GetServerInfoAsync(string realm)
        {
            var result = await _client.GetServerInfoAsync(realm).ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("test")]
        public async Task CorsPreflightAsync(string realm)
        {
            bool? result = await _client.CorsPreflightAsync(realm);
            Assert.True(result);
        }
    }
}
