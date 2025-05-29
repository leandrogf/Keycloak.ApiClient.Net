# Keycloak.ApiClient.Net

Cliente .NET para integração com a API do Keycloak. Este projeto facilita o consumo das funcionalidades administrativas do Keycloak por meio de uma interface fluente e orientada a recursos.

![.NET](https://img.shields.io/badge/.NET-6.0%2B-blue)
![Keycloak](https://img.shields.io/badge/Keycloak-API-green)
![Build](https://img.shields.io/appveyor/build/username/Keycloak.ApiClient.Net)

## 📦 Instalação

Disponível via [NuGet](https://www.nuget.org/):

```bash
dotnet add package Keycloak.ApiClient.Net
```

## ⚙️ Requisitos

- .NET 6.0 ou superior
- Keycloak 17 ou superior (com suporte ao Admin REST API)

## 📁 Estrutura do Projeto

- `src/Keycloak.ApiClient.Net`: Código-fonte principal do cliente
- `test/Keycloak.ApiClient.Net.Tests`: Testes unitários e de integração
- `build/`: Scripts para automação de build e testes (`build.ps1`, `test.ps1`)

## 🔧 Funcionalidades Suportadas

Este cliente cobre grande parte dos recursos administrativos do Keycloak:

- 🔐 **Autenticação e Autorização**
- 👤 **Usuários e Grupos**
- 🧑‍🤝‍🧑 **Realms e Clientes**
- 🔑 **Componentes, Roles, Mapeamentos**
- 🗝️ **Providers de Armazenamento**
- 📜 **OpenID Configuration**
- 📂 **Client Scopes, Protocol Mappers e mais**

Cada recurso é encapsulado em sua própria pasta com o respectivo `KeycloakClient.cs`, permitindo extensões e manutenção organizadas.

## 🚀 Exemplo de Uso

```csharp
var client = new KeycloakClient(new KeycloakOptions {
    BaseUrl = "https://keycloak.meureino.com",
    Realm = "master",
    ClientId = "admin-cli",
    Username = "admin",
    Password = "senha123"
});

// Listar usuários
var users = await client.Users.GetUsersAsync();
```

## 🧪 Testes

Para rodar os testes:

```bash
.uild	est.ps1
```

## 🔐 Segurança

- Certificados podem ser gerenciados via `ClientAttributeCertificate`
- Suporte a tokens, introspecção e configuração de permissões

## 📖 Documentação

A documentação detalhada será adicionada em breve. Por ora, consulte os exemplos nos testes e no código-fonte.

## 🧑‍💻 Contribuindo

Pull requests são bem-vindos! Para contribuir:

1. Fork o repositório
2. Crie uma branch: `git checkout -b feature/NovaFuncionalidade`
3. Commit suas mudanças: `git commit -am 'Adiciona nova funcionalidade'`
4. Envie um PR

## 📄 Licença

[MIT](LICENSE)

---

## 🏷️ Referências

- [Keycloak Admin REST API Docs](https://www.keycloak.org/docs-api/)
- [Keycloak Server Docs](https://www.keycloak.org/documentation)