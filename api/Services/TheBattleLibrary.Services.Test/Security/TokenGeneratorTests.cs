using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using TheBattleLibrary.Services.Security;

namespace TheBattleLibrary.Services.Test.Security;

public class TokenGeneratorTests
{
    [Fact]
    public void GenerateTokenReturnsValidToken()
    {
        var loggerMock = new Mock<ILogger<TokenGenerator>>();
        var inMemorySettings = new Dictionary<string, string> {
            {"Security:Key", "supersecretkey12345kjfdjnhfusdhfioudshfiousdhfiusdhfiuosdhfiuosdhifusdhiufds"},
            {"Security:Issuer", "testIssuer"},
            {"Security:Audience", "testAudience"},
            {"Security:JwtTimeoutSeconds", "3600"}
        };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();
        var tokenGenerator = new TokenGenerator(loggerMock.Object, configuration);
        var response = tokenGenerator.GenerateToken(Guid.NewGuid(), "testuser");

        Assert.NotNull(response.Token);
        Assert.True(response.ExpiresAt > DateTime.UtcNow);
    }

    [Fact]
    public void GenerateTokenThrowsExceptionForInvalidConfiguration()
    {
        var loggerMock = new Mock<ILogger<TokenGenerator>>();
        var inMemorySettings = new Dictionary<string, string> {
            {"Security:Key", ""},
        };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();
        
        Assert.Throws<KeyNotFoundException>(() => new TokenGenerator(loggerMock.Object, configuration));
    }

    [Fact]
    public void GenerateTokenLogsWarningWhenJwtTimeoutNotConfigured()
    {
        var loggerMock = new Mock<ILogger<TokenGenerator>>();
        var inMemorySettings = new Dictionary<string, string> {
            {"Security:Key", "knjfdjsnfijdsnfoidsnfijsdnisdnhsdihugdfhiougr7894u9g89h7578h9g5h8g7erh8"},
            {"Security:Issuer", "testIssuer"},
            {"Security:Audience", "testAudience"},
        };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();
        
        var tokenGenerator = new TokenGenerator(loggerMock.Object, configuration);

        loggerMock.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) =>
                    v.ToString().Contains("Security:JwtTimeoutSeconds not configured. Defaulting to one day.")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }
}