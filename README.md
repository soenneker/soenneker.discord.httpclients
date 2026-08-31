[![](https://img.shields.io/nuget/v/soenneker.discord.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.discord.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.discord.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.discord.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.discord.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.discord.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.discord.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.discord.httpclients/actions/workflows/codeql.yml)

# Soenneker.Discord.HttpClients

Provides a cached `HttpClient` configured for Discord's API with bot-token authentication.

## Installation

```bash
dotnet add package Soenneker.Discord.HttpClients
```

## Configuration

```json
{
  "Discord": {
    "ApiKey": "your-bot-token"
  }
}
```

The client targets `https://discord.com/api/v10/` and sends `Authorization: Bot <ApiKey>`. For OAuth access tokens, set `Discord:AuthHeaderValueTemplate` to `Bearer {token}`. `Discord:ClientBaseUrl` and `Discord:AuthHeaderName` can also override the base address and header name.

## Registration and usage

```csharp
using Soenneker.Discord.HttpClients.Abstract;
using Soenneker.Discord.HttpClients.Registrars;

services.AddDiscordOpenApiHttpClientAsSingleton();

public sealed class DiscordUserReader(IDiscordOpenApiHttpClient clients)
{
    public async Task<HttpResponseMessage> GetCurrentUser(CancellationToken cancellationToken)
    {
        HttpClient client = await clients.Get(cancellationToken);
        return await client.GetAsync("users/@me", cancellationToken);
    }
}
```

The provider owns the returned client. Prefer singleton registration for normal application use. Scoped registration creates a separately owned cache entry per scope, so disposing one provider cannot remove another provider's client.
