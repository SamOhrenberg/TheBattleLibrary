
using Moq;
using Xunit;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheBattleLibrary.Services;
using TheBattleLibrary.API.Controllers;
using TheBattleLibrary.API.Models.Auth;
using TheBattleLibrary.Data.Entities;
using TheBattleLibrary.Services.Errors;
using TheBattleLibrary.Services.Abstractions;
using TheBattleLibrary.API.Models;

namespace TheBattleLibrary.API.Tests.Controllers;

public class AuthControllerTests
{
    private readonly Mock<IUserAuthenticationService> _mockAuthService;
    private readonly Mock<ILogger<AuthController>> _mockLogger;
    private readonly AuthController _authController;

    public AuthControllerTests()
    {
        _mockAuthService = new Mock<IUserAuthenticationService>();
        _mockLogger = new Mock<ILogger<AuthController>>();
        _authController = new AuthController(_mockAuthService.Object, _mockLogger.Object);
    }

    [Fact]
    public async Task RegisterAsync_ReturnsOk_WhenRegistrationIsSuccessful()
    {
        // Arrange
        var model = new UserRegistrationModel("testUser", "testPassword123");
        _mockAuthService.Setup(service => service.RegisterUserAsync(It.IsAny<string>(), It.IsAny<string>()))
                        .Returns(Task.FromResult(new UserAccount(model.Username, model.Password)));

        // Act
        var result = await _authController.RegisterAsync(model);

        // Assert
        var okResult = Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task RegisterAsync_ReturnsBadRequest_WhenInvalidPasswordExceptionIsThrown()
    {
        // Arrange
        var model = new UserRegistrationModel("testUser", "test");
        _mockAuthService.Setup(service => service.RegisterUserAsync(It.IsAny<string>(), It.IsAny<string>()))
                        .ThrowsAsync(new InvalidPasswordException() { Errors = new List<string> { "Password too weak" } });

        // Act
        var result = await _authController.RegisterAsync(model);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        var value = Assert.IsType<ValidationError>(badRequestResult.Value);
        Assert.Equal("An invalid password was presented", value.Message);
        Assert.Contains("Password too weak", value.Errors);
    }

    [Fact]
    public async Task RegisterAsync_ReturnsBadRequest_WhenUsernameTakenExceptionIsThrown()
    {
        // Arrange
        var model = new UserRegistrationModel("existinguser", "TestPassword123!");
        _mockAuthService.Setup(service => service.RegisterUserAsync(It.IsAny<string>(), It.IsAny<string>()))
                        .ThrowsAsync(new UsernameTakenException(model.Username));

        // Act
        var result = await _authController.RegisterAsync(model);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        var value = Assert.IsType<Error>(badRequestResult.Value);
        Assert.Equal($"An account with username '{model.Username}' already exists. Please select a new username.", value.Message);
    }


    [Fact]
    public async Task LoginAsync_ReturnsOk_WhenLoginIsSuccessful()
    {
        // Arrange
        var model = new UserLoginModel("testUser", "WrongPassword123!");

        var generatedToken = "test_jwt_token";

        // Mock successful login with a generated token
        _mockAuthService.Setup(service => service.AttemptLoginAsync(It.IsAny<string>(), It.IsAny<string>()))
                        .ReturnsAsync(generatedToken);

        // Act
        var result = await _authController.LoginAsync(model);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(generatedToken, okResult.Value);
    }

    [Fact]
    public async Task LoginAsync_ReturnsBadRequest_WhenLoginFails()
    {
        // Arrange
        var model = new UserLoginModel("testUser", "WrongPassword123!");

        // Mock failed login
        _mockAuthService.Setup(service => service.AttemptLoginAsync(It.IsAny<string>(), It.IsAny<string>()))
                        .ThrowsAsync(new FailedLoginException("Incorrect username or password"));

        // Act
        var result = await _authController.LoginAsync(model);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        var error = Assert.IsType<Error>(badRequestResult.Value);
        Assert.Equal(nameof(FailedLoginException), error.Code);
        Assert.Equal("Incorrect username or password", error.Message);
    }

}
