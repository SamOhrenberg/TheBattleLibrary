using TheBattleLibrary.Data.Entities;

namespace TheBattleLibrary.Services.Abstractions
{
    public interface IUserAuthenticationService
    {
        Task<UserAccount> RegisterUserAsync(string username, string password);
        bool ValidateUser(string hashedPassword, string password);
    }
}