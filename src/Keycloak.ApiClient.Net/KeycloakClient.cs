using System;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Flurl.Http.Newtonsoft;
using Keycloak.ApiClient.Net.Common.Extensions;
using Keycloak.ApiClient.Net.Models.AuthenticationManagement;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Keycloak.ApiClient.Net
{
    public partial class KeycloakClient
    {
        private ISerializer _serializer = new NewtonsoftJsonSerializer(new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
        });

        private readonly Url _url;
        private readonly string _userName;
        private readonly string _password;
        private readonly string _clientSecret;
        private readonly Func<string> _getToken;

        public static string KeycloakDefaultClientName { get; } = "default";
        public static string KeycloakAuthenticateClientName { get; } = "authentication";

        private KeycloakClient(string url)
        {
            _url = url;

            FlurlHttp.Clients.GetOrAdd(KeycloakDefaultClientName, url, c => c.Settings.JsonSerializer = new NewtonsoftJsonSerializer(new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore 
            }));
        }

        public KeycloakClient(string url, string userName, string password)
            : this(url)
        {
            _userName = userName;
            _password = password;
        }

        public KeycloakClient(string url, string clientSecret)
            : this(url)
        {
            _clientSecret = clientSecret;
        }

        public KeycloakClient(string url, Func<string> getToken)
            : this(url)
        {
            _getToken = getToken;
        }

        public KeycloakClient(string url, string userName, string password, string clientSecret)
            : this(url)
        {
            _userName = userName;
            _password = password;
            _clientSecret = clientSecret;
        }

        public KeycloakClient(string url, string userName, string password, string clientSecret, Func<string> getToken)
            : this(url)
        {
            _userName = userName;
            _password = password;
            _clientSecret = clientSecret;
            _getToken = getToken;
        }

        public void SetSerializer(ISerializer serializer)
        {
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
        }

        private IFlurlRequest GetBaseUrl(string authenticationRealm, string clientName = null)
        {
            return GetBaseUrl(authenticationRealm, withAuthentication: true, clientName);
        }

        // Fix for CS1729: "FlurlRequest" does not contain a constructor that accepts 2 arguments.
        // The error occurs because the `FlurlRequest` class does not have a constructor that accepts both `client` and `url`.
        // Instead, the `Request` method of `IFlurlClient` should be used to create a request.

        private IFlurlRequest GetBaseUrl(string authenticationRealm, bool withAuthentication = true, string clientName = null)
        {
            clientName ??= KeycloakDefaultClientName;
            var client = FlurlHttp.Clients.Get(clientName); // Fix: Use Get method instead of indexer
            var request = client.Request(_url); // Fix: Use the Request method of IFlurlClient to create a FlurlRequest
            if (withAuthentication)
            {
                return request
                    .WithAuthentication(_getToken, _url, authenticationRealm, _userName, _password, _clientSecret);
            }
            return request;
        }
    }
}