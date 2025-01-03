﻿using Keycloak.ApiClient.Net.Models.Roles;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Keycloak.ApiClient.Net.Models.Common
{
    public class ClientRoleMapping
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("client")]
        public string Client { get; set; }
        [JsonProperty("mappings")]
        public List<Role> Mappings { get; set; }
    }
}
