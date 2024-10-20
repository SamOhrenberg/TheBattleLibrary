
using Moq;
using Xunit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;

namespace TheBattleLibrary.Data.Tests;

public class StartupTests
{
    [Fact]
    public void ConfigureServices_ShouldRegisterSqliteDbContext_WhenDatabaseTypeIsSqlite()
    {
        // Arrange
        var services = new ServiceCollection();
        var inMemorySettings = new Dictionary<string, string> {
            {"DatabaseType", "sqlite"},
            {"ConnectionStrings:sqlite", "DataSource=mydb.db"},
        };

        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();


        // Act
        Startup.ConfigureServices(services, configuration);

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var dbContext = serviceProvider.GetService<IApplicationDbContext>();
        Assert.NotNull(dbContext); // Ensure the DbContext is registered
    }

    [Fact]
    public void ConfigureServices_ShouldThrowException_WhenDatabaseTypeIsUnsupported()
    {
        // Arrange
        var services = new ServiceCollection();
        var inMemorySettings = new Dictionary<string, string> {
            {"DatabaseType", "oracle"},
            {"ConnectionStrings:oracle", "DataSource=mydb.db"},
        };

        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Startup.ConfigureServices(services, configuration));
    }

    [Fact]
    public void ConfigureServices_ShouldNotRegisterDbContext_WhenDatabaseTypeIsEmpty()
    {
        // Arrange
        var services = new ServiceCollection();
        var inMemorySettings = new Dictionary<string, string> {
            {"DatabaseType", ""},
        };

        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Startup.ConfigureServices(services, configuration));
    }
}