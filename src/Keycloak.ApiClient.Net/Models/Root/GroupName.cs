using Keycloak.ApiClient.Net.Common.Converters;
using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    [JsonConverter(typeof(GroupNameConverter))]
    public enum GroupName
    {
        Social, 
        UserDefined
    }
}