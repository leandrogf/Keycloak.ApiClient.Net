using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Common
{
    public class ManagementPermission
    {
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }
    }
}
