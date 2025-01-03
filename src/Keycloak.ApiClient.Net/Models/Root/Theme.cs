using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class Theme
    {
        [JsonProperty("internal")]
        public bool? Internal { get; set; }

        [JsonProperty("providers")]
        public ThemeProviders Providers { get; set; }
    }
}