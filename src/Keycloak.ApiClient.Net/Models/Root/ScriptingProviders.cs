using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class ScriptingProviders
    {
        [JsonProperty("script-based-auth")]
        public HasOrder ScriptBasedAuth { get; set; }
    }
}