using Keycloak.ApiClient.Net.Common.Converters;
using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    [JsonConverter(typeof(ProtocolConverter))]
    public enum Protocol
    {
        DockerV2, 
        OpenIdConnect, 
        Saml
    }
}