using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Moq;
using TheBattleLibrary.API.Middlewares;
using TheBattleLibrary.Services.Abstractions;

namespace TheBattleLibrary.API.Tests.Middlewares;

public class TokenRevocationMiddlewareTests
{
    [Fact]
    public async Task MiddlewareAllowsRequestWhenTokenIsNotRevoked()
    {
        var context = new DefaultHttpContext();
        context.User =
            new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, "user") }, "mock"));
        context.Request.Headers["Authorization"] = "Bearer validtoken";

        var userAuthServiceMock = new Mock<IUserAuthenticationService>();
        userAuthServiceMock.Setup(s => s.CheckToken("validtoken")).ReturnsAsync(false);

        var middleware = new TokenRevocationMiddleware((innerHttpContext) => Task.CompletedTask);

        await middleware.InvokeAsync(context, userAuthServiceMock.Object);

        Assert.Equal(StatusCodes.Status200OK, context.Response.StatusCode);
    }

    [Fact]
    public async Task MiddlewareBlocksRequestWhenTokenIsRevoked()
    {
        var context = new DefaultHttpContext();
        context.User =
            new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, "user") }, "mock"));
        context.Request.Headers["Authorization"] = "Bearer revokedtoken";

        var userAuthServiceMock = new Mock<IUserAuthenticationService>();
        userAuthServiceMock.Setup(s => s.CheckToken("revokedtoken")).ReturnsAsync(true);

        var middleware = new TokenRevocationMiddleware((innerHttpContext) => Task.CompletedTask);

        await middleware.InvokeAsync(context, userAuthServiceMock.Object);

        Assert.Equal(StatusCodes.Status401Unauthorized, context.Response.StatusCode);
    }

    [Fact]
    public async Task MiddlewareAllowsRequestWhenNoTokenProvided()
    {
        var context = new DefaultHttpContext();
        context.User =
            new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, "user") }, "mock"));

        var userAuthServiceMock = new Mock<IUserAuthenticationService>();

        var middleware = new TokenRevocationMiddleware((innerHttpContext) => Task.CompletedTask);

        await middleware.InvokeAsync(context, userAuthServiceMock.Object);

        Assert.Equal(StatusCodes.Status200OK, context.Response.StatusCode);
    }

    [Fact]
    public async Task MiddlewareAllowsRequestWhenUserIsNotAuthenticated()
    {
        var context = new DefaultHttpContext();

        var userAuthServiceMock = new Mock<IUserAuthenticationService>();

        var middleware = new TokenRevocationMiddleware((innerHttpContext) => Task.CompletedTask);

        await middleware.InvokeAsync(context, userAuthServiceMock.Object);

        Assert.Equal(StatusCodes.Status200OK, context.Response.StatusCode);
    }
}