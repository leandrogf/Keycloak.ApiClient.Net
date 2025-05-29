using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Keycloak.ApiClient.Net.Models.OpenIDConfiguration;
using Newtonsoft.Json;
using Xunit;

namespace Keycloak.ApiClient.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Theory]
        [InlineData("test")]
        public async Task CheckConfiguration(string realm)
        {
            var openIDConfiguration = await _client.GetOpenIDConfigurationAsync(realm).ConfigureAwait(false);
            Assert.NotNull(openIDConfiguration);
        }
    }
}
