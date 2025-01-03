using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class ConnectionsJpaUpdaterProviders
    {
        [JsonProperty("liquibase")]
        public HasOrder Liquibase { get; set; }
    }
}