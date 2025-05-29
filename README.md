
# Keycloak.ApiClient.Net 2.0.0

**.NET client for integrating with the Keycloak Admin REST API.**  
This project provides a fluent and resource-oriented interface for managing Keycloak's administrative features.

---

##  Installation

Available via **NuGet**:

```bash
dotnet add package Keycloak.ApiClient.Net --version 2.0.0
```

Or via **Package Manager Console** in Visual Studio:

```powershell
Install-Package Keycloak.ApiClient.Net -Version 2.0.0
```

---

## ️ Requirements

- .NET 9.0 or higher  
- Keycloak 17 or higher (with Admin REST API support)

---

##  Project Structure

- `src/Keycloak.ApiClient.Net`: Core source code for the client  
- `test/Keycloak.ApiClient.Net.Tests`: Unit and integration tests  
- `build/`: Build and test automation scripts (`build.ps1`, `test.ps1`)

---

##  Supported Features

The client covers a wide range of Keycloak administrative resources:

- Authentication and Authorization  
- Users and Groups  
- Realms and Clients  
- Components, Roles, and Mappings  
- User Storage Providers  
- OpenID Configuration  
- Client Scopes, Protocol Mappers, and more

Each feature is encapsulated in its respective folder with a dedicated `KeycloakClient.cs`, allowing for organized extensions and maintenance.

---

##  Usage Example

```csharp
using Keycloak.ApiClient.Net;

var client = new KeycloakClient("https://keycloak.example.com", "admin", "password");

// List users in a realm
var users = await client.GetUsersAsync("master");
foreach (var user in users)
{
    Console.WriteLine($"User: {user.Username}");
}
```

---

##  Testing

To run the tests:

```powershell
.\build\test.ps1
```

---

##  Security

- Certificates are managed via `ClientAttributeCertificate`  
- Supports token-based authentication, introspection, and permission configuration  
- Enhanced OAuth2 flow handling with secure token management

---

##  Documentation

Detailed documentation is available in the source code and test cases.  
Key features and examples are also documented in this README.

For full API reference:  
**[Keycloak Admin REST API Documentation](https://www.keycloak.org/docs-api/)**

---

##  New in 2.0.0

- **Improved Authentication**: `GetBaseUrl` now supports an optional `withAuthentication` parameter to handle endpoints without token concatenation.
- **Robust Models**: `User.cs` updated with `List<string>` for `DisableableCredentialTypes` and `RequiredActions`; fixed `Credentials`, aligned with `UserRepresentation`.
- **New Models**: `CountResponse`, `ManagementPermissionReference`, `ComponentTypeRepresentation`, `ConfigPropertyRepresentation`.
- **Error Handling**: Improved support for HTTP status codes like `501 Not Implemented`.
- **NuGet Dependencies**: Updated to `Flurl.Http 4.0.2`, `Flurl.Http.Newtonsoft`, `Newtonsoft.Json 13.0.3`.

---

##  Contributing

Contributions are welcome! To contribute:

1. Fork the repository  
2. Create a branch:  
   ```bash
   git checkout -b feature/NewFeature
   ```
3. Commit your changes:  
   ```bash
   git commit -am 'Add new feature'
   ```
4. Submit a pull request

**Please make sure all tests pass and follow the existing coding style.**

---

##  License

MIT

---

##  References

- [Keycloak Admin REST API Documentation](https://www.keycloak.org/docs-api/)  
- [Keycloak Server Documentation](https://www.keycloak.org/documentation.html)

---

##  Changelog

**Version 2.0.0**

- Enhanced `GetBaseUrl` in `KeycloakClient.cs` with optional `withAuthentication` parameter  
- Updated API calls to use `IFlurlResponse` for compatibility with `Flurl.Http 4.0`  
- Replaced `dynamic` with `CountResponse` in methods like `GetClientOfflineSessionCountAsync`  
- Fixed `User.cs` by aligning with `UserRepresentation` and resolving deserialization issues  
- Added models: `CountResponse`, `ManagementPermissionReference`, `ComponentTypeRepresentation`, `ConfigPropertyRepresentation`  
- Adjusted tests in `KeycloakClientShould.cs` for authentication changes and error handling  
- Updated NuGet packages and improved documentation with new features and examples
