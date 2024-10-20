using Microsoft.AspNetCore.Identity;
using TheBattleLibrary.Data;
using TheBattleLibrary.Data.Entities;
using TheBattleLibrary.Services.Errors;

namespace TheBattleLibrary.Services;

public class UserAuthenticationService
{
    private readonly PasswordHasher<UserAccount> _passwordHasher;
    private readonly IApplicationDbContext _dbContext;

    public UserAuthenticationService(IApplicationDbContext dbContext)
    {
        _passwordHasher = new PasswordHasher<UserAccount>();
        _dbContext = dbContext;
    }

    public UserAccount RegisterUser(string username, string password)
    {
        var userAccount = _dbContext.Users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.CurrentCultureIgnoreCase));

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

    public bool ValidateUser(string hashedPassword, string password)
    {
        // Verify password
        var verificationResult = _passwordHasher.VerifyHashedPassword(null!, hashedPassword, password);

        return verificationResult == PasswordVerificationResult.Success;
    }
}
