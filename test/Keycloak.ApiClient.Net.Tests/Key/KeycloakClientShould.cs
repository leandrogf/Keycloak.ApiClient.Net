using System.Threading.Tasks;
using Xunit;

namespace Keycloak.ApiClient.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Theory]
        [InlineData("master")]
        public async Task GetKeysAsync(string realm)
        {
            var result = await _client.GetKeysAsync(realm).ConfigureAwait(false);
            Assert.NotNull(result);
        }
    }
}
