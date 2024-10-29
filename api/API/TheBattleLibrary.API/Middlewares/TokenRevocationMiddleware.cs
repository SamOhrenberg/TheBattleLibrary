using TheBattleLibrary.Services.Abstractions;

namespace TheBattleLibrary.API.Middlewares;

public class TokenRevocationMiddleware
{
    private readonly RequestDelegate _next;

    public TokenRevocationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IUserAuthenticationService userAuthenticationService)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (!string.IsNullOrEmpty(token))
            {
                var isRevoked = await userAuthenticationService.CheckToken(token);
                if (isRevoked)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Token has been revoked.");
                    return;
                }
            }
        }

        await _next(context);
    }
}