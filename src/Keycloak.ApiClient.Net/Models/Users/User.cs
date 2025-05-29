using System.Collections.Generic;
using Keycloak.ApiClient.Net.Models.Roles;
using Newtonsoft.Json;

namespace Keycloak.ApiClient.Net.Models.Users
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdTimestamp")]
        public long CreatedTimestamp { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("totp")]
        public bool? Totp { get; set; }

        [JsonProperty("emailVerified")]
        public bool? EmailVerified { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("disableableCredentialTypes")]
        public List<string> DisableableCredentialTypes { get; set; } // Alterado de ReadOnlyCollection

        [JsonProperty("requiredActions")]
        public List<string> RequiredActions { get; set; } // Alterado de ReadOnlyCollection

        [JsonProperty("notBefore")]
        public long? NotBefore { get; set; }

        [JsonProperty("access")]
        public Dictionary<string, bool> Access { get; set; }

        [JsonProperty("attributes")]
        public Dictionary<string, List<string>> Attributes { get; set; }

        [JsonProperty("clientConsents")]
        public List<UserConsent> ClientConsents { get; set; }

        [JsonProperty("clientRoles")]
        public Dictionary<string, List<Role>> ClientRoles { get; set; }

        [JsonProperty("credentials")]
        public List<Credentials> Credentials { get; set; }

        [JsonProperty("federatedIdentities")]
        public List<FederatedIdentity> FederatedIdentities { get; set; }

        [JsonProperty("federationLink")]
        public string FederationLink { get; set; }

        [JsonProperty("groups")]
        public List<string> Groups { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("realmRoles")]
        public List<string> RealmRoles { get; set; }

        [JsonProperty("self")]
        public string Self { get; set; }

        [JsonProperty("serviceAccountClientId")]
        public string ServiceAccountClientId { get; set; }
    }
}