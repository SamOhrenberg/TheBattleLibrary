using TheBattleLibrary.Data.Entities;

namespace TheBattleLibrary.Services.Abstractions
{
    public interface IUserAuthenticationService
    {
        Task<UserAccount> RegisterUserAsync(string username, string password);
        Task<string> AttemptLoginAsync(string username, string password);

        Task LogoutAsync(string token);

    }
}