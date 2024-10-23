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
}
