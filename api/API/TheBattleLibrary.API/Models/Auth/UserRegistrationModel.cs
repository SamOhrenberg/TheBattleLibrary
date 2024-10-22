using System.ComponentModel.DataAnnotations;

namespace TheBattleLibrary.API.Models.Auth;

public class UserRegistrationModel
{
    [Required, StringLength(255)]
    public string Username { get; init; }

    [Required, StringLength(255)]
    public string Password { get; init; }

    public UserRegistrationModel(string username, string password)
    {
        Username = username;
        Password = password;
    }
}
