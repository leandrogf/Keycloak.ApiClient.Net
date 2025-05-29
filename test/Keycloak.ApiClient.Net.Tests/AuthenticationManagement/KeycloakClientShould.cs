using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.ApiClient.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Theory]
        [InlineData("test")]
        public async Task GetAuthenticatorProvidersAsync(string realm)
        {
            var result = await _client.GetAuthenticatorProvidersAsync(realm).ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("test")]
        public async Task GetClientAuthenticatorProvidersAsync(string realm)
        {
            var result = await _client.GetClientAuthenticatorProvidersAsync(realm).ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("test")]
        public async Task GetAuthenticatorProviderConfigurationDescriptionAsync(string realm)
        {
            var providers = await _client.GetAuthenticatorProvidersAsync(realm).ConfigureAwait(false);
            string providerId = providers.FirstOrDefault()?.FirstOrDefault(x => x.Key == "id").Value.ToString();
            if (providerId != null)
            {
                var result = await _client.GetAuthenticatorProviderConfigurationDescriptionAsync(realm, providerId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("test", "clients")]
        public async Task GetAuthenticationExecutionAsync(string realm, string flowAlias)
        {
            var executions = await _client.GetAuthenticationFlowExecutionsAsync(realm, flowAlias).ConfigureAwait(false);
            string executionId = executions.FirstOrDefault()?.Id;
            if (executionId != null)
            {
                var result = await _client.GetAuthenticationExecutionAsync(realm, executionId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("test")]
        public async Task GetAuthenticationFlowsAsync(string realm)
        {
            var result = await _client.GetAuthenticationFlowsAsync(realm).ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("test", "clients")]
        public async Task GetAuthenticationFlowExecutionsAsync(string realm, string flowAlias)
        {
            var result = await _client.GetAuthenticationFlowExecutionsAsync(realm, flowAlias).ConfigureAwait(false);
            Assert.NotNull(result);

        }

        [Theory]
        [InlineData("test", "clients")]
        public async Task GetAuthenticationFlowByIdAsync(string realm, string flowAlias)
        {
            var flows = await _client.GetAuthenticationFlowsAsync(realm).ConfigureAwait(false);
            string flowId = flows.FirstOrDefault(f => f.Alias.Equals(flowAlias))?.Id;
            if (flowId != null)
            {
                var result = await _client.GetAuthenticationFlowByIdAsync(realm, flowId).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("test")]
        public async Task GetFormActionProvidersAsync(string realm)
        {
            var result = await _client.GetFormActionProvidersAsync(realm).ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("test")]
        public async Task GetFormProvidersAsync(string realm)
        {
            var result = await _client.GetFormProvidersAsync(realm).ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("test")]
        public async Task GetConfigurationDescriptionsForAllClientsAsync(string realm)
        {
            var result = await _client.GetConfigurationDescriptionsForAllClientsAsync(realm).ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("test")]
        public async Task GetRequiredActionsAsync(string realm)
        {
            var result = await _client.GetRequiredActionsAsync(realm).ConfigureAwait(false);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("test")]
        public async Task GetRequiredActionByAliasAsync(string realm)
        {
            var requiredActions = await _client.GetRequiredActionsAsync(realm).ConfigureAwait(false);
            string requiredActionAlias = requiredActions.FirstOrDefault()?.Alias;
            if (requiredActionAlias != null)
            {
                var result = await _client.GetRequiredActionByAliasAsync(realm, requiredActionAlias).ConfigureAwait(false);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("test")]
        public async Task GetUnregisteredRequiredActionsAsync(string realm)
        {
            var result = await _client.GetUnregisteredRequiredActionsAsync(realm).ConfigureAwait(false);
            Assert.NotNull(result);
        }
    }
}
