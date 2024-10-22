using Microsoft.AspNetCore.Identity;
using Moq;
using TheBattleLibrary.Data.Entities;
using TheBattleLibrary.Services;
using TheBattleLibrary.Data;
using TheBattleLibrary.Services.Errors;
using Microsoft.EntityFrameworkCore;

namespace TheBattleLibrary.Services.Test
{
    public class UserAuthenticationServiceTests
    {
        private readonly UserAuthenticationService _authService;
        private readonly PasswordHasher<UserAccount> _passwordHasher;
        private readonly IApplicationDbContext _dbContext;

        public UserAuthenticationServiceTests()
        {
            // Initialize the PasswordHasher
            _passwordHasher = new PasswordHasher<UserAccount>();
            // Set up the in-memory database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _dbContext = new ApplicationDbContext(options);
            
            _authService = new UserAuthenticationService(_dbContext);
        }

        [Fact]
        public async void RegisterUser_ShouldThrowInvalidPasswordException_WithShortPassword()
        {
            // Arrange
            var username = "testUser-" + Guid.NewGuid().ToString();
            var password = "test";

            // act and assert
            var error = await Assert.ThrowsAsync<InvalidPasswordException>(async () => 
            {
                await _authService.RegisterUserAsync(username, password);
            });
            Assert.Single(error.Errors);
        }

        [Fact]
        public async void RegisterUser_ShouldReturnUserAccount_WithHashedPassword()
        {
            // Arrange
            var username = "testUser-" + Guid.NewGuid().ToString();
            var password = "testPassword";

            // Act
            var result = await _authService.RegisterUserAsync(username, password);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(username, result.Username, ignoreCase: true);
            Assert.NotNull(result.PasswordHash);

            // Verify that the password hash is valid
            var verificationResult = _passwordHasher.VerifyHashedPassword(result, result.PasswordHash, password);
            Assert.Equal(PasswordVerificationResult.Success, verificationResult);
        }

        [Fact]
        public async void RegisterUser_ShouldThrowUsernameTakenException_WhenUserAlreadyExists()
        {
            // Arrange
            var username = "existingUser";
            var password = "testPassword";
            var existingUser = new UserAccount(username, "existingPasswordHash");

            // Act & Assert
            await _authService.RegisterUserAsync(username, password);
            await Assert.ThrowsAsync<UsernameTakenException>(async () => await _authService.RegisterUserAsync(username, password));
        }

        [Fact]
        public void ValidateUser_ShouldReturnTrue_WhenPasswordIsCorrect()
        {
            // Arrange
            var password = "testPassword";
            var hashedPassword = _passwordHasher.HashPassword(null!, password);

            // Act
            var result = _authService.ValidateUser(hashedPassword, password);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ValidateUser_ShouldReturnFalse_WhenPasswordIsIncorrect()
        {
            // Arrange
            var hashedPassword = _passwordHasher.HashPassword(null!, "testPassword");
            var incorrectPassword = "wrongPassword";

            // Act
            var result = _authService.ValidateUser(hashedPassword, incorrectPassword);

            // Assert
            Assert.False(result);
        }
    }
}
