using Microsoft.AspNet.Identity;

namespace TheBattleLibrary.Services.Test;

public class UserAuthenticationServiceTests
{
    private readonly UserAuthenticationService _authService;
    private readonly PasswordHasher _passwordHasher;

    public UserAuthenticationServiceTests()
    {
        // Initialize the PasswordHasher
        _passwordHasher = new PasswordHasher();
        _authService = new UserAuthenticationService();
    }

    [Fact]
    public void RegisterUser_ShouldReturnUserAccount_WithHashedPassword()
    {
        // Arrange
        var username = "testUser";
        var password = "testPassword";

        // Act
        var result = _authService.RegisterUser(username, password);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(username, result.Username);
        Assert.NotNull(result.PasswordHash);

        // Verify that the password hash is valid
        var verificationResult = _passwordHasher.VerifyHashedPassword(result.PasswordHash, password);
        Assert.Equal(PasswordVerificationResult.Success, verificationResult);
    }

    [Fact]
    public void ValidateUser_ShouldReturnTrue_WhenPasswordIsCorrect()
    {
        // Arrange
        var password = "testPassword";
        var hashedPassword = _passwordHasher.HashPassword(password);

        // Act
        var result = _authService.ValidateUser(hashedPassword, password);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ValidateUser_ShouldReturnFalse_WhenPasswordIsIncorrect()
    {
        // Arrange
        var hashedPassword = _passwordHasher.HashPassword("testPassword");
        var incorrectPassword = "wrongPassword";

        // Act
        var result = _authService.ValidateUser(hashedPassword, incorrectPassword);

        // Assert
        Assert.False(result);
    }
}