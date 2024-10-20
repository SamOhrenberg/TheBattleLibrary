using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheBattleLibrary.API.Models.Auth;
using TheBattleLibrary.Services;
using TheBattleLibrary.Services.Errors;

namespace TheBattleLibrary.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserAuthenticationService _userAuthenticationService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(UserAuthenticationService userAuthenticationService, ILogger<AuthController> logger)
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
            return BadRequest(new
            {
                Message = "An invalid password was presented",
                Errors = ex.Errors
            });
        }
        catch (UsernameTakenException)
        {
            return BadRequest(new
            {
                Message = $"An account with username '{model.Username}' already exists. Please select a new username."
            });
        }

        return Ok();
    }
}
