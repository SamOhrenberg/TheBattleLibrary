using Microsoft.AspNet.Identity;
using TheBattleLibrary.Data.Entities;

namespace TheBattleLibrary.Services;

public class UserAuthenticationService
{
    private readonly PasswordHasher _passwordHasher;

    public UserAuthenticationService()
    {
        _passwordHasher = new PasswordHasher();
    }

    public UserAccount RegisterUser(string username, string password)
    {
        // Hash the password
        string passwordHash = _passwordHasher.HashPassword(password);

        var user = new UserAccount(username, passwordHash);

        return user;
    }

    public bool ValidateUser(string hashedPassword, string password)
    {
        // Verify password
        var verificationResult = _passwordHasher.VerifyHashedPassword(hashedPassword, password);

        return verificationResult == PasswordVerificationResult.Success;
    }
}
