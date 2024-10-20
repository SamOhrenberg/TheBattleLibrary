using System.ComponentModel.DataAnnotations;

namespace TheBattleLibrary.Data.Entities;

/// <summary>
/// Represents a single user in the application
/// </summary>
public class UserAccount
{
    [Key]
    public Guid Id { get; init; }

    [MaxLength(100)]
    public string Username { get; set; }

    [MaxLength(255)]
    public string PasswordHash { get; set; }

    public UserAccount(string username, string passwordHash) : this(Guid.NewGuid(), username, passwordHash)
    {
    }

    public UserAccount(Guid id, string username, string passwordHash)
    {
        Id = id;
        Username = username;
        PasswordHash = passwordHash;
    }
}
