using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Common
{
    public class ManagementPermission
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("resource")]
        public string Resource { get; set; }

        [JsonProperty("scopePermissions")]
        public Dictionary<string, string> ScopePermissions { get; set; }
    }
}
