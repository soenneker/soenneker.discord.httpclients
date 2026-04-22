using Soenneker.Discord.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Discord.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class DiscordOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IDiscordOpenApiHttpClient _httpclient;

    public DiscordOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IDiscordOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
