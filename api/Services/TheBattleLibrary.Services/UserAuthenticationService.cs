using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TheBattleLibrary.Data;
using TheBattleLibrary.Data.Entities;
using TheBattleLibrary.Services.Abstractions;
using TheBattleLibrary.Services.Errors;
using TheBattleLibrary.Services.Security;

namespace TheBattleLibrary.Services;

public class UserAuthenticationService : IUserAuthenticationService
{
    private readonly PasswordHasher<UserAccount> _passwordHasher;
    private readonly IApplicationDbContext _dbContext;
    private readonly ILogger<UserAuthenticationService> _logger;
    private readonly TokenGenerator _tokenGenerator;

    public UserAuthenticationService(IApplicationDbContext dbContext, ILogger<UserAuthenticationService> logger, TokenGenerator tokenGenerator)
    {
        _passwordHasher = new PasswordHasher<UserAccount>();
        _dbContext = dbContext;
        _logger = logger;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<UserAccount> RegisterUserAsync(string username, string password)
    {
        username = username.ToLower();
        var userAccount = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);

        // verify that the user does not already exist
        if (userAccount is not null)
        {
            throw new UsernameTakenException(username);
        }

        ValidatePasswordRequirements(password);

        userAccount = new UserAccount(username, string.Empty);
        _dbContext.Users.Add(userAccount);

        // Hash the password
        userAccount.PasswordHash = _passwordHasher.HashPassword(userAccount, password);


        _dbContext.SaveChanges();
        return userAccount;
    }

    public async Task<string> AttemptLoginAsync(string username, string password)
    {
        // check the password is valid first to save a DB call
        try
        {
            ValidatePasswordRequirements(password);
        }
        catch (InvalidPasswordException)
        {
            _logger.LogDebug("Invalid password provided for {username}", username);
            throw FailedLoginException.IncorrectUsernameOrPassword;
        }

        username = username.ToLower();
        var userAccount = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);

        // verify that the user exists
        if (userAccount is null)
        {
            _logger.LogDebug("Login attempt for unregistered user {username}", username);
            throw FailedLoginException.IncorrectUsernameOrPassword;
        }

        // validate the provided password
        if (!ValidateUser(userAccount.PasswordHash, password))
        {
            _logger.LogDebug("Incorrect password provided for {username}", username);
            throw FailedLoginException.IncorrectUsernameOrPassword;
        }


        // get a JWT now
        var tokenResponse = _tokenGenerator.GenerateToken(userAccount.Id, userAccount.Username);
        
        // store the token with its expiration date
        _dbContext.UserTokens.Add(new UserToken
        {
            ExpiresAt = tokenResponse.ExpiresAt,
            Token = tokenResponse.Token
        });
        _dbContext.SaveChanges();
        
        return tokenResponse.Token;
    }

    public async Task LogoutAsync(string token)
    {
        var tokenDb = await _dbContext.UserTokens.FirstOrDefaultAsync(a => a.Token == token);
        if (tokenDb is not null)
        {
            tokenDb.IsRevoked = true;
            _dbContext.SaveChanges();
        }
    }

    private void ValidatePasswordRequirements(string password)
    {
        InvalidPasswordException? invalidPasswordException = null;
        if (password.Length < 6)
        {
            invalidPasswordException ??= new InvalidPasswordException();
            invalidPasswordException.Errors.Add("Password must be at least six characters long");
        }

        if (invalidPasswordException is not null)
        {
            throw invalidPasswordException;
        }
    }

    private bool ValidateUser(string hashedPassword, string password)
    {
        // Verify password
        var verificationResult = _passwordHasher.VerifyHashedPassword(null!, hashedPassword, password);

        return verificationResult == PasswordVerificationResult.Success;
    }
}
