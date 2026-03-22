using Soenneker.Discord.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Discord.HttpClients.Tests;

[Collection("Collection")]
public sealed class DiscordOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly IDiscordOpenApiHttpClient _httpclient;

    public DiscordOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IDiscordOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
