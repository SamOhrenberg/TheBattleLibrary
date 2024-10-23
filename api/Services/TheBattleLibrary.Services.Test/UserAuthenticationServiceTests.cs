using Microsoft.AspNetCore.Identity;
using Moq;
using TheBattleLibrary.Data.Entities;
using TheBattleLibrary.Services;
using TheBattleLibrary.Data;
using TheBattleLibrary.Services.Errors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TheBattleLibrary.Services.Abstractions;
using TheBattleLibrary.Services.Security;
using Microsoft.Extensions.Configuration;

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
            var loggerMock = new Mock<ILogger<UserAuthenticationService>>();

            // Set up the in-memory database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _dbContext = new ApplicationDbContext(options);
            
            // set up the in memory configuration
            var inMemorySettings = new Dictionary<string, string?> {
                {"Security:Key", "Test123467890qwertyuioop[]asdfghjkl;'zxcvbnm,./"},
                {"Security:Issuer", "https://tests"},
                {"Security:Audience", "https://tests"},
                //...populate as needed for the test
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            var tokenGeneratorMock = new Mock<TokenGenerator>(new Mock<ILogger<TokenGenerator>>().Object, configuration);



            _authService = new UserAuthenticationService(_dbContext, loggerMock.Object, tokenGeneratorMock.Object);
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
        public async Task AttemptLoginAsync_InvalidPassword_ThrowsFailedLoginException()
        {
            // Arrange
            var username = "testuser";
            var invalidPassword = "123"; // invalid according to ValidatePasswordRequirements

            // Act & Assert
            var exception = await Assert.ThrowsAsync<FailedLoginException>(() => _authService.AttemptLoginAsync(username, invalidPassword));
            Assert.Equal(FailedLoginException.IncorrectUsernameOrPassword, exception);
        }

        [Fact]
        public async Task AttemptLoginAsync_UnregisteredUser_ThrowsFailedLoginException()
        {
            // Arrange
            var username = "nonexistentuser";
            var password = "ValidPassword123!";

            // Act & Assert
            var exception = await Assert.ThrowsAsync<FailedLoginException>(() => _authService.AttemptLoginAsync(username, password));
            Assert.Equal(FailedLoginException.IncorrectUsernameOrPassword, exception);
        }

        [Fact]
        public async Task AttemptLoginAsync_IncorrectPassword_ThrowsFailedLoginException()
        {
            // Arrange
            var username = "AttemptLoginAsync_IncorrectPassword_ThrowsFailedLoginException";
            var password = "WrongPassword123!";

            await _authService.RegisterUserAsync(username, password);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<FailedLoginException>(() => _authService.AttemptLoginAsync(username, "NotTheRightPassword@1234"));
            Assert.Equal(FailedLoginException.IncorrectUsernameOrPassword, exception);
        }

        [Fact]
        public async Task AttemptLoginAsync_ValidCredentials_ReturnsToken()
        {
            // Arrange
            var username = "AttemptLoginAsync_ValidCredentials_ReturnsToken";
            var password = "ValidPassword123!";

            await _authService.RegisterUserAsync(username, password);

            // Act
            var result = await _authService.AttemptLoginAsync(username, password);

            // Assert
            Assert.True(!string.IsNullOrEmpty(result));
        }
    }
}
