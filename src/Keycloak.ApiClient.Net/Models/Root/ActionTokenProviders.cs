using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    public class ActionTokenProviders
    {
        [JsonProperty("infinispan")]
        public HasOrder Infinispan { get; set; }
    }
}