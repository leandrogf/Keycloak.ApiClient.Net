using System.IO;
using Microsoft.Extensions.Configuration;
using static System.Net.WebRequestMethods;

namespace Keycloak.ApiClient.Net.Tests
{
    public partial class KeycloakClientShould
    {
        private readonly KeycloakClient _client;

        public KeycloakClientShould()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            //var client = new KeycloakClient(new KeycloakOptions
            //{
            //    BaseUrl = "https://keycloak.meureino.com",
            //    Realm = "master",
            //    ClientId = "admin-cli",
            //    Username = "admin",
            //    Password = "senha123"
            //});

            string url = configuration["MLA:BaseUrl"] ?? "https://accounts.mliberty.com.br/";
            string userName = configuration["MLA:AdminUsername"] ?? "test";
            string password = configuration["MLA:AdminPassword"] ?? "usuario_para_teste";
            string clientSecret = configuration["MLA:ClientSecret"] ?? string.Empty;

            _client = new KeycloakClient(url, userName, password);
        }
    }
}
