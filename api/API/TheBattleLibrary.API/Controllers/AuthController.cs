using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheBattleLibrary.API.Models;
using TheBattleLibrary.API.Models.Auth;
using TheBattleLibrary.Services;
using TheBattleLibrary.Services.Abstractions;
using TheBattleLibrary.Services.Errors;

namespace TheBattleLibrary.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserAuthenticationService _userAuthenticationService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IUserAuthenticationService userAuthenticationService, ILogger<AuthController> logger)
    {
        _userAuthenticationService = userAuthenticationService;
        _logger = logger;
    }

    [HttpPost("register")]
    public async Task<ActionResult> RegisterAsync([FromBody] UserRegistrationModel model)
    {
        try
        {
            await _userAuthenticationService.RegisterUserAsync(model.Username, model.Password);
        }
        catch (InvalidPasswordException ex)
        {
            return BadRequest(new ValidationError
            {
                Code = nameof(InvalidPasswordException),
                Message = "An invalid password was presented",
                Errors = ex.Errors
            });
        }
        catch (UsernameTakenException)
        {
            return BadRequest(new Error
            {
                Code = nameof(UsernameTakenException),
                Message = $"An account with username '{model.Username}' already exists. Please select a new username."
            });
        }

        return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult> LoginAsync([FromBody] UserLoginModel model)
    {
        try
        {
            _logger.LogTrace("Attempting login for {username}", model.Username);
            var token = await _userAuthenticationService.AttemptLoginAsync(model.Username, model.Password);
            _logger.LogInformation("Successful login for {username}", model.Username);
            return Ok(token);
        }
        catch (FailedLoginException)
        {
            _logger.LogInformation("Failed login for {username}", model.Username);
            return BadRequest(new Error
            {
                Code = nameof(FailedLoginException),
                Message = "Incorrect username or password"
            });
        }
    }
    
    [HttpPost("logout")]
    public async Task<ActionResult> LogoutAsync()
    {
        var token = Request.Headers["Authorization"];
        if (string.IsNullOrWhiteSpace(token))
        {
            return BadRequest(new Error
            {
                Code = "NoTokenProvided",
                Message = "No token provided"
            });
        }

        await _userAuthenticationService.LogoutAsync(token!);
        return Ok();
    }
}
