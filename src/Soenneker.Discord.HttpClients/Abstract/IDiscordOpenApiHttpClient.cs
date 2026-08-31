using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Discord.HttpClients.Abstract;

/// <summary>
/// Provides a cached, authenticated <see cref="HttpClient"/> for Discord's API.
/// </summary>
public interface IDiscordOpenApiHttpClient: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the client owned by this provider.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The configured Discord client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
