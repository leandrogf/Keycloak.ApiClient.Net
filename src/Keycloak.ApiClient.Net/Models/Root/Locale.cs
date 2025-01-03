using Keycloak.ApiClient.Net.Common.Converters;
using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Root
{
    [JsonConverter(typeof(LocaleConverter))]
    public enum Locale
    {
        En
    }
}